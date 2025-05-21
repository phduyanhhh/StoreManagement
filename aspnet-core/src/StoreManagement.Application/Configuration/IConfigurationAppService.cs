using System.Threading.Tasks;
using StoreManagement.Configuration.Dto;

namespace StoreManagement.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
