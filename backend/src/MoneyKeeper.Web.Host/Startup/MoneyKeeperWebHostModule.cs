using Abp.Modules;
using Abp.Reflection.Extensions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using MoneyKeeper.Configuration;

namespace MoneyKeeper.Web.Host.Startup
{
    [DependsOn(
       typeof(MoneyKeeperWebCoreModule))]
    public class MoneyKeeperWebHostModule : AbpModule
    {
        private readonly IWebHostEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public MoneyKeeperWebHostModule(IWebHostEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(MoneyKeeperWebHostModule).GetAssembly());
        }
    }
}
