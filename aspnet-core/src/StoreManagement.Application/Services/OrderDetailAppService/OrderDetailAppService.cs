using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Text;
using System.Threading.Tasks;
using Abp.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using StoreManagement.Entities;
using StoreManagement.Services.OrderDetailAppService.Dto;

namespace StoreManagement.Services.OrderDetailAppService
{
	public class OrderDetailAppService : StoreManagementAppServiceBase, IOrderDetailAppService
	{
		private readonly IRepository<OrderDetails> _repositoryOrderDetails;

		public OrderDetailAppService(
			IRepository<OrderDetails> repositoryOrderDetails
			)
		{
			_repositoryOrderDetails = repositoryOrderDetails;
		}
		// Create
		public async Task Create(CreateOrderDetailInput input)
		{
			var orderDetail = new OrderDetails
			{
				OrderId = input.OrderId,
				ProductId = input.ProductId,
				Price = input.Price,
				Quantity = input.Quantity,
			};
			await _repositoryOrderDetails.InsertAsync( orderDetail );
		}
		// Update
		public async Task Update(UpdateOrderDetailInput input)
		{
			var existingOrderDetail = await _repositoryOrderDetails.FirstOrDefaultAsync(x => x.Id == input.OrderId);
			existingOrderDetail.ProductId = input.ProductId;
			existingOrderDetail.Price = input.Price;
			existingOrderDetail.Quantity = input.Quantity;
			await _repositoryOrderDetails.UpdateAsync( existingOrderDetail );
		}
		// Find by OrderId
		public async Task<List<OrderDetailListDto>> GetAllByOrderId(int OrderId)
		{
			var findOrderDetailByOrderId = await _repositoryOrderDetails
				.GetAll()
				.Where(x => x.OrderId == OrderId)
				.Select(x => new OrderDetailListDto
				{
					OrderId = x.OrderId,
					ProductId = x.ProductId,
					Price = x.Price,
					Quantity = x.Quantity,
				}).ToListAsync();
			return findOrderDetailByOrderId;
		}

	}
}
