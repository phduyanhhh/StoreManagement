using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services;
using StoreManagement.Services.OrdersAppService.Dto;

namespace StoreManagement.Services.OrdersAppService
{
	public interface IOrdersAppService : IApplicationService
	{
		Task<int> Create(CreateOrderInput input);
	}
}
