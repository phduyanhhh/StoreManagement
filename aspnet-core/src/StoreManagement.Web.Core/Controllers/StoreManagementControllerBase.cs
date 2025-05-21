using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace StoreManagement.Controllers
{
    public abstract class StoreManagementControllerBase: AbpController
    {
        protected StoreManagementControllerBase()
        {
            LocalizationSourceName = StoreManagementConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
