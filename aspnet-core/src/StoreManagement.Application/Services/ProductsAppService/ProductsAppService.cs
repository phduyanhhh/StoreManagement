using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.Collections.Extensions;
using Abp.Domain.Repositories;
using Abp.Extensions;
using Abp.Linq.Extensions;
using Abp.UI;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StoreManagement.Entities;
using StoreManagement.Services.DistributorsAppService.Dto;
using StoreManagement.Services.ProductsAppService.Dto;

namespace StoreManagement.Services.ProductsAppService
{
	public class ProductsAppService : StoreManagementAppServiceBase, IProductsAppService
	{
		private readonly IRepository<Products> _repositoryProducts;

		public ProductsAppService(IRepository<Products> repositoryProducts)
		{
			_repositoryProducts = repositoryProducts;
		}

		// Get Image
		public async Task<FileContentResult> GetImage(int id)
		{
			var product = await _repositoryProducts.GetAsync(id);

			if (product?.ImageData != null)
			{
				return new FileContentResult(product.ImageData, product.ImageMimeType ?? "image/png");
			}

			throw new UserFriendlyException("Image not found");
		}
		// Create
		public async Task Create([FromForm] CreateProductInput input)
		{
			var product = new Products
			{
				Name = input.Name,
				Price = input.Price,
				Quantity = input.Quantity
			};

			if (input.ImageFile != null)
			{
				using var ms = new MemoryStream();
				await input.ImageFile.CopyToAsync(ms);
				product.ImageData = ms.ToArray();
				product.ImageMimeType = input.ImageFile.ContentType;
			}
			await _repositoryProducts.InsertAsync(product);
		}

		//GET ALL
		public async Task<PagedResultDto<ProductsListDto>> GetAll(GetAllProductsInput input)
		{
			var query = _repositoryProducts.GetAll()
				.WhereIf(!input.Search.IsNullOrWhiteSpace(), x => input.Search.ToLower().Contains(x.Name))
				.OrderByDescending(x => x.CreationTime);
			var Count = query.Count();
			if (input.Sorting.IsNullOrWhiteSpace())
			{
				input.Sorting = "CreationTime DESC";
			}
			var items = await query.PageBy(input).OrderBy(input.Sorting)
				.Select(x => new ProductsListDto
				{
					Id = x.Id,
					Name = x.Name,
					Price = x.Price,
					Quantity = x.Quantity,
					ImageUrl = $"api/services/app/Products/GetImage?id={x.Id}"
				})
				.ToListAsync();
			return new PagedResultDto<ProductsListDto>(Count, items);
		}
		// Edit
		public async Task Update(UpdateProductInput input)
		{
			var existingProduct = await _repositoryProducts.FirstOrDefaultAsync(x => x.Id == input.Id);
			existingProduct.Name = input.Name;
			existingProduct.Price = input.Price;
			existingProduct.Quantity = input.Quantity;
			await _repositoryProducts.UpdateAsync(existingProduct);
		}
		// Delete
		public async Task Delete(int id)
		{
			await _repositoryProducts.DeleteAsync(id);
		}
	}
}
