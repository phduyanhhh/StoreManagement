using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using StoreManagement.Services.WarehouresAppService.Dto;

namespace StoreManagement.Services.WarehouresAppService
{
	public interface IWarehouresAppService : IApplicationService
	{
		Task Create(CreateWarehouresInput input);
		Task<PagedResultDto<WarehouresListDto>> GetAll(GetAllWarehouresInput input);
		Task Update(UpdateWarehouresInput input);
		Task Delete(int Id);
	}
}
