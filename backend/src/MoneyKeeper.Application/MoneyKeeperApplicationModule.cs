using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using MoneyKeeper.Authorization;

namespace MoneyKeeper
{
    [DependsOn(
        typeof(MoneyKeeperCoreModule),
        typeof(AbpAutoMapperModule))]
    public class MoneyKeeperApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<MoneyKeeperAuthorizationProvider>();
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(MoneyKeeperApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddMaps(thisAssembly)
            );
        }
    }
}
