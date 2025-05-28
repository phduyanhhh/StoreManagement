using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Domain.Repositories;
using StoreManagement.Entities;
using StoreManagement.Services.CustomersAppService;
using StoreManagement.Services.CustomersAppService.Dto;
using StoreManagement.Services.OrdersAppService.Dto;

namespace StoreManagement.Services.OrdersAppService
{
	public class OrdersAppService : StoreManagementAppServiceBase, IOrdersAppService
	{
		private readonly IRepository<Orders> _repositoryOrders;
		private readonly ICustomersAppService _customersAppService;

		public OrdersAppService(
			IRepository<Orders> repositoryOrders,
			ICustomersAppService customersAppService
			)
		{
			_repositoryOrders = repositoryOrders;
			_customersAppService = customersAppService;
		}
		// Create
		public async Task<int> Create(CreateOrderInput input)
		{
			var order = new Orders();
			order.CustomerId = input.CustomerId;
			order.TotalPrice = input.TotalPrice;
			order.PaymentMethod = input.PaymentMethod;

			if (input.CustomerId != null) {
				int id = (int)input.CustomerId;
				var existingCustomer = await _customersAppService.ExistingCustomer(id);
				existingCustomer.Scores += (int)(input.TotalPrice * 0.02);
				var updateScore = new UpdateCustomerInput
				{
					Id = id,
					Username = existingCustomer.Username,
					PhoneNumber = existingCustomer.PhoneNumber,
					Scores = existingCustomer.Scores,
				};
				await _customersAppService.Update(updateScore);
			}
			await _repositoryOrders.InsertAsync( order );
			return order.Id;
		}
	}
}
