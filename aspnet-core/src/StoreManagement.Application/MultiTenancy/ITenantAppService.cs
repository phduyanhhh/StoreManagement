using Abp.Application.Services;
using StoreManagement.MultiTenancy.Dto;

namespace StoreManagement.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedTenantResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}

