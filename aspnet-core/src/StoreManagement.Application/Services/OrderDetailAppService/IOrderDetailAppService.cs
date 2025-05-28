using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services;
using StoreManagement.Services.OrderDetailAppService.Dto;

namespace StoreManagement.Services.OrderDetailAppService
{
	public interface IOrderDetailAppService : IApplicationService
	{
		Task Create(CreateOrderDetailInput input);
		Task Update(UpdateOrderDetailInput input);
		Task<List<OrderDetailListDto>> GetAllByOrderId(int OrderId);
	}
}
