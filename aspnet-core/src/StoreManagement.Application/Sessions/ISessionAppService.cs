using System.Threading.Tasks;
using Abp.Application.Services;
using StoreManagement.Sessions.Dto;

namespace StoreManagement.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
