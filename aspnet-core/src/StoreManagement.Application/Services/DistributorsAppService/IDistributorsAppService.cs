using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using StoreManagement.Entities;
using StoreManagement.Services.DistributorsAppService.Dto;

namespace StoreManagement.Services.DistributorsAppService
{
	public interface IDistributorsAppService : IApplicationService
	{
		Task Create(CreateDistributorInput input);
		Task<PagedResultDto<DistributorsListDto>> GetAll(GetAllDistributorsInput input);
		Task<DistributorsListDto> GetAnDistributor(int distributorId);
		Task<Distributors> Update(UpdateDistributorInput input);
		Task Delete(int distributorId);
	}
}
