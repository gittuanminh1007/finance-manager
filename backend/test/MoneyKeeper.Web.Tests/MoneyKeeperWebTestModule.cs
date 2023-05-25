using Abp.AspNetCore;
using Abp.AspNetCore.TestBase;
using Abp.Modules;
using Abp.Reflection.Extensions;
using MoneyKeeper.EntityFrameworkCore;
using MoneyKeeper.Web.Startup;
using Microsoft.AspNetCore.Mvc.ApplicationParts;

namespace MoneyKeeper.Web.Tests
{
    [DependsOn(
        typeof(MoneyKeeperWebMvcModule),
        typeof(AbpAspNetCoreTestBaseModule)
    )]
    public class MoneyKeeperWebTestModule : AbpModule
    {
        public MoneyKeeperWebTestModule(MoneyKeeperEntityFrameworkModule abpProjectNameEntityFrameworkModule)
        {
            abpProjectNameEntityFrameworkModule.SkipDbContextRegistration = true;
        } 
        
        public override void PreInitialize()
        {
            Configuration.UnitOfWork.IsTransactional = false; //EF Core InMemory DB does not support transactions.
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(MoneyKeeperWebTestModule).GetAssembly());
        }
        
        public override void PostInitialize()
        {
            IocManager.Resolve<ApplicationPartManager>()
                .AddApplicationPartsIfNotAddedBefore(typeof(MoneyKeeperWebMvcModule).Assembly);
        }
    }
}