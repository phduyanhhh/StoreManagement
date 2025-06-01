using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.Collections.Extensions;
using Abp.Domain.Repositories;
using Abp.Extensions;
using Abp.Linq.Extensions;
using Microsoft.EntityFrameworkCore;
using StoreManagement.Entities;
using StoreManagement.Services.CustomersAppService;
using StoreManagement.Services.CustomersAppService.Dto;
using StoreManagement.Services.DistributorsAppService.Dto;
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
			await CurrentUnitOfWork.SaveChangesAsync();
			return order.Id;
		}
		// Get all 
		public async Task<PagedResultDto<OrdersListDto>> GetAll(GetAllOrdersInput input)
		{
			var query = _repositoryOrders
				.GetAll()
				.Include(x => x.Customer)
				.OrderByDescending(d => d.CreationTime);

			var Count = query.Count();

			if (input.Sorting.IsNullOrWhiteSpace())
			{
				input.Sorting = "CreationTime DESC";
			}

			var items = await query.PageBy(input).OrderBy(input.Sorting)
				.Select(x => new OrdersListDto
				{
					Id = x.Id,
					CustomerId = x.CustomerId,
					TotalPrice = x.TotalPrice,
					PaymentMethod = x.PaymentMethod,
					CustomerName = x.Customer.Username,
					CreationTime = x.CreationTime,
				})
				.ToListAsync();
			return new PagedResultDto<OrdersListDto>(Count, items);
		}
	}
}
