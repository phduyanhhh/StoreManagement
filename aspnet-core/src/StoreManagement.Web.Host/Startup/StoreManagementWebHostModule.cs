using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using StoreManagement.Configuration;

namespace StoreManagement.Web.Host.Startup
{
    [DependsOn(
       typeof(StoreManagementWebCoreModule))]
    public class StoreManagementWebHostModule: AbpModule
    {
        private readonly IWebHostEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public StoreManagementWebHostModule(IWebHostEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(StoreManagementWebHostModule).GetAssembly());
        }
    }
}
