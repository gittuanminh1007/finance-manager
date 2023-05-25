using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace MoneyKeeper.Controllers
{
    public abstract class MoneyKeeperControllerBase: AbpController
    {
        protected MoneyKeeperControllerBase()
        {
            LocalizationSourceName = MoneyKeeperConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
