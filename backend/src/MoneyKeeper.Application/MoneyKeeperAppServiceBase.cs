using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Abp.Application.Services;
using Abp.IdentityFramework;
using Abp.Runtime.Session;
using MoneyKeeper.Authorization.Users;

namespace MoneyKeeper
{
    /// <summary>
    /// Derive your application services from this class.
    /// </summary>
    public abstract class MoneyKeeperAppServiceBase : ApplicationService
    {
        public UserManager UserManager { get; set; }

        protected MoneyKeeperAppServiceBase()
        {
            LocalizationSourceName = MoneyKeeperConsts.LocalizationSourceName;
        }

        protected virtual async Task<User> GetCurrentUserAsync()
        {
            var user = await UserManager.FindByIdAsync(AbpSession.GetUserId().ToString());
            if (user == null) throw new Exception("There is no current user!");
            return user;
        }

        protected virtual void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
