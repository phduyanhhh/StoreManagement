using System.Threading.Tasks;
using Abp.Application.Services;
using StoreManagement.Authorization.Accounts.Dto;

namespace StoreManagement.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}
