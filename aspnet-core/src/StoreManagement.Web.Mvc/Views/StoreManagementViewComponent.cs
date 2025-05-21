using Abp.AspNetCore.Mvc.ViewComponents;

namespace StoreManagement.Web.Views
{
    public abstract class StoreManagementViewComponent : AbpViewComponent
    {
        protected StoreManagementViewComponent()
        {
            LocalizationSourceName = StoreManagementConsts.LocalizationSourceName;
        }
    }
}
