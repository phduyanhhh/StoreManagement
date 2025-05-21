using Abp.AspNetCore.Mvc.Views;
using Abp.Runtime.Session;
using Microsoft.AspNetCore.Mvc.Razor.Internal;

namespace StoreManagement.Web.Views
{
    public abstract class StoreManagementRazorPage<TModel> : AbpRazorPage<TModel>
    {
        [RazorInject]
        public IAbpSession AbpSession { get; set; }

        protected StoreManagementRazorPage()
        {
            LocalizationSourceName = StoreManagementConsts.LocalizationSourceName;
        }
    }
}
