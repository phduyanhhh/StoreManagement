using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using StoreManagement.Authorization;

namespace StoreManagement
{
    [DependsOn(
        typeof(StoreManagementCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class StoreManagementApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<StoreManagementAuthorizationProvider>();
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(StoreManagementApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddMaps(thisAssembly)
            );
        }
    }
}
