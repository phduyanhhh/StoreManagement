using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using StoreManagement.Configuration.Dto;

namespace StoreManagement.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : StoreManagementAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}
