﻿using Abp.Modules;
using Abp.Reflection.Extensions;
using Abp.Runtime.Security;
using Abp.Zero;
using Abp.Zero.Configuration;
using MoneyKeeper.Authorization.Roles;
using MoneyKeeper.Authorization.Users;
using MoneyKeeper.Configuration;
using MoneyKeeper.Localization;
using MoneyKeeper.MultiTenancy;

namespace MoneyKeeper
{
    [DependsOn(typeof(AbpZeroCoreModule))]
    public class MoneyKeeperCoreModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Auditing.IsEnabledForAnonymousUsers = true;

            // Declare entity types
            Configuration.Modules.Zero().EntityTypes.Tenant = typeof(Tenant);
            Configuration.Modules.Zero().EntityTypes.Role = typeof(Role);
            Configuration.Modules.Zero().EntityTypes.User = typeof(User);

            MoneyKeeperLocalizationConfigurer.Configure(Configuration.Localization);

            // Configure roles
            AppRoleConfig.Configure(Configuration.Modules.Zero().RoleManagement);

            Configuration.Settings.Providers.Add<AppSettingProvider>();

            Configuration.Settings.SettingEncryptionConfiguration.DefaultPassPhrase = MoneyKeeperConsts.DefaultPassPhrase;
            SimpleStringCipher.DefaultPassPhrase = MoneyKeeperConsts.DefaultPassPhrase;
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(MoneyKeeperCoreModule).GetAssembly());
        }
    }
}
