using System;
using System.Threading.Tasks;
using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Abp.Runtime.Session;
using Microsoft.AspNetCore.Identity;
using MoneyKeeper.Authorization.Users;

namespace MoneyKeeper.Controllers
{
    public abstract class MoneyKeeperControllerBase : AbpController
    {
        public UserManager UserManager { get; set; }

        protected MoneyKeeperControllerBase()
        {
            LocalizationSourceName = MoneyKeeperConsts.LocalizationSourceName;
        }

        protected virtual async Task<User> GetCurrentUserAsync()
        {
            var user = await UserManager.FindByIdAsync(AbpSession.GetUserId().ToString());
            if (user == null) throw new Exception("There is no current user!");
            return user;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
