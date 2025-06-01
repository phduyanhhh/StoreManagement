using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Abp.Extensions;
using Abp.Linq.Extensions;
using Abp.UI;
using Microsoft.EntityFrameworkCore;
using StoreManagement.Entities;
using StoreManagement.Services.ProductsAppService;
using StoreManagement.Services.ProductsAppService.Dto;
using StoreManagement.Services.WarehouresAppService.Dto;

namespace StoreManagement.Services.WarehouresAppService
{
	public class WarehouresAppService : StoreManagementAppServiceBase, IWarehouresAppService
	{
		private IRepository<Warehoures, int> _repositoryWarehoures;
		private IRepository<Products, int> _repositoryProducts;
		private readonly IProductsAppService _productsAppService;
		public WarehouresAppService(
			IRepository<Warehoures, int> repositoryWarehoures,
			IProductsAppService productsAppService,
			IRepository<Products, int> repositoryProducts
			)
		{
			_repositoryWarehoures = repositoryWarehoures;
			_productsAppService = productsAppService;
			_repositoryProducts = repositoryProducts;
		}
		// Create
		public async Task Create(CreateWarehouresInput input)
		{
			var wareHourse = new Warehoures();

			wareHourse.DistributorId = input.DistributorId;
			wareHourse.ProductId = input.ProductId;
			wareHourse.Price = input.Price;
			wareHourse.Quantity = input.Quantity;

			var existingProduct = await _repositoryProducts.FirstOrDefaultAsync(x => x.Id == input.ProductId);

			if (existingProduct == null)
			{
				throw new UserFriendlyException("Không tìm thấy sản phẩm với ID đã chọn.");
			}
			existingProduct.Quantity += input.Quantity;

			await _repositoryWarehoures.InsertAsync(wareHourse);
			await _repositoryProducts.UpdateAsync(existingProduct);
		}
		// GET ALL
		public async Task<PagedResultDto<WarehouresListDto>> GetAll(GetAllWarehouresInput input)
		{
			var query = _repositoryWarehoures
				.GetAll()
				.Include(x => x.Distributor)
				.Include(x => x.Product)
				.OrderByDescending(x => x.CreationTime)
				.WhereIf(!input.Search.IsNullOrWhiteSpace(),
						x => x.Product.Name == input.Search ||
						x.Distributor.Name == input.Search);
			//var query2 = _repositoryWarehoures
			//	.GetAll()
			//	//.Include(x => x.Distributor)
			//	//.Include(x => x.Product)
			//	.OrderByDescending(x => x.CreationTime)
			//	.WhereIf(!input.Search.IsNullOrWhiteSpace(),
			//			x => x.Product.Name == input.Search ||
			//			x.Distributor.Name == input.Search)
			//	.ToList();
			var Count = query.Count();
			if (input.Sorting.IsNullOrWhiteSpace())
			{
				input.Sorting = "CreationTime DESC";
			}
			var items = await query.PageBy(input).OrderBy(input.Sorting)
				.Select(x => new WarehouresListDto
				{
					Id = x.Id,
					DistributorId = x.DistributorId,
					DistributorName = x.Distributor.Name,
					ProductImg = $"api/services/app/Products/GetImage?id={x.ProductId}",
					ProductId = x.ProductId,
					ProductName = x.Product.Name,
					Price = x.Price,
					Quantity = x.Quantity,
					CreationTime = x.CreationTime,
				}).ToListAsync();
			return new PagedResultDto<WarehouresListDto>(Count, items);
		}
		// Update 
		public async Task Update(UpdateWarehouresInput input)
		{
			var existingWarehoures = await _repositoryWarehoures.FirstOrDefaultAsync(x => x.Id == input.Id);
			if (existingWarehoures == null)
			{
				throw new UserFriendlyException("Không tìm thấy bản ghi kho hàng.");
			}
			existingWarehoures.ProductId = input.ProductId;
			existingWarehoures.DistributorId = input.DistributorId;
			existingWarehoures.Price = input.Price;
			existingWarehoures.Quantity = input.Quantity;
			await _repositoryWarehoures.UpdateAsync(existingWarehoures);
		}
		// Get an
		public async Task<WarehouresListDto> GetAnById(int id)
		{
			var existingWarehouses = await _repositoryWarehoures.FirstOrDefaultAsync(x => x.Id == id);
			var warehouse = new WarehouresListDto
			{
				Id = existingWarehouses.Id,
				DistributorId = existingWarehouses.DistributorId,
				ProductImg = $"api/services/app/Products/GetImage?id={id}",
				ProductId = existingWarehouses.ProductId,
				Price = existingWarehouses.Price,
				Quantity = existingWarehouses.Quantity,
				CreationTime = existingWarehouses.CreationTime,
			};
			return warehouse;
		}
		// Delete 
		public async Task Delete(int Id)
		{
			var warehoures = await _repositoryWarehoures.FirstOrDefaultAsync(x => x.Id != Id);
			if (warehoures == null)
			{
				throw new UserFriendlyException("Không tìm thấy bản ghi nào");
			}
			await _repositoryWarehoures.DeleteAsync(warehoures);
		}
	}
}
