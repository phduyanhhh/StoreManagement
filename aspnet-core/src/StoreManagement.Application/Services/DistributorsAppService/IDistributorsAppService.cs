using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services;
using StoreManagement.Entities;
using StoreManagement.Services.DistributorsAppService.Dto;

namespace StoreManagement.Services.DistributorsAppService
{
	public interface IDistributorsAppService : IApplicationService
	{
		Task<Distributors> Create(CreateDistributorInput input);
	}
}
