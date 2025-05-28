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
using StoreManagement.Services.WarehouresAppService.Dto;

namespace StoreManagement.Services.WarehouresAppService
{
	public class WarehouresAppService : StoreManagementAppServiceBase, IWarehouresAppService
	{
		private IRepository<Warehoures, int> _repositoryWarehoures;
		private readonly IProductsAppService _productsAppService;
		public WarehouresAppService(
			IRepository<Warehoures, int> repositoryWarehoures,
			IProductsAppService productsAppService
			)
		{
			_repositoryWarehoures = repositoryWarehoures;
			_productsAppService = productsAppService;
		}
		// Create
		public async Task Create(CreateWarehouresInput input)
		{
			var wareHourse = new Warehoures();
			wareHourse.DistributorId = input.DistributorId;
			wareHourse.ProductId = input.ProductId;
			wareHourse.Price = input.Price;
			wareHourse.Quantity = input.Quantity;
			await _repositoryWarehoures.InsertAsync(wareHourse);
		}
		// GET ALL
		public async Task<PagedResultDto<WarehouresListDto>> GetAll(GetAllWarehouresInput input)
		{
			var query = _repositoryWarehoures
				.GetAll()
				.OrderByDescending(x => x.CreationTime)
				.WhereIf(!input.Search.IsNullOrWhiteSpace(),
						x => x.Product.Name == input.Search ||
						x.Distributor.Name == input.Search);
			var Count = query.Count();
			if(input.Sorting.IsNullOrWhiteSpace())
			{
				input.Sorting = "CreationTime DESC";
			}
			var items = await query.PageBy(input).OrderBy(input.Sorting)
				.Select(x => new WarehouresListDto
				{
					Id = x.Id,
					Distributor = x.Distributor,
					DistributorId = x.DistributorId,
					ProductImg = $"api/services/app/Products/GetImage?id={x.ProductId}",
					Product = x.Product,
					ProductId = x.ProductId,
					Price = x.Price,
					Quantity = x.Quantity,
				}).ToListAsync();
			return new PagedResultDto<WarehouresListDto> (Count, items);
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
