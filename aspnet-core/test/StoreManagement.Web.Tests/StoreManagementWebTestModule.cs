using Abp.AspNetCore;
using Abp.AspNetCore.TestBase;
using Abp.Modules;
using Abp.Reflection.Extensions;
using StoreManagement.EntityFrameworkCore;
using StoreManagement.Web.Startup;
using Microsoft.AspNetCore.Mvc.ApplicationParts;

namespace StoreManagement.Web.Tests
{
    [DependsOn(
        typeof(StoreManagementWebMvcModule),
        typeof(AbpAspNetCoreTestBaseModule)
    )]
    public class StoreManagementWebTestModule : AbpModule
    {
        public StoreManagementWebTestModule(StoreManagementEntityFrameworkModule abpProjectNameEntityFrameworkModule)
        {
            abpProjectNameEntityFrameworkModule.SkipDbContextRegistration = true;
        } 
        
        public override void PreInitialize()
        {
            Configuration.UnitOfWork.IsTransactional = false; //EF Core InMemory DB does not support transactions.
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(StoreManagementWebTestModule).GetAssembly());
        }
        
        public override void PostInitialize()
        {
            IocManager.Resolve<ApplicationPartManager>()
                .AddApplicationPartsIfNotAddedBefore(typeof(StoreManagementWebMvcModule).Assembly);
        }
    }
}