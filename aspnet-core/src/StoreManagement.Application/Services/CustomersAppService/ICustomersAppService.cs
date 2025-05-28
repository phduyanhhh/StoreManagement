using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using StoreManagement.Services.CustomersAppService.Dto;

namespace StoreManagement.Services.CustomersAppService
{
	public interface ICustomersAppService : IApplicationService
	{
		Task Create(CreateCustomerInput input);
		Task<PagedResultDto<CustomersListDto>> GetAll(GetAllCustomerInput input);
		Task Update(UpdateCustomerInput input);
		Task<CustomersListDto> ExistingCustomer(int Id);
	}
}
