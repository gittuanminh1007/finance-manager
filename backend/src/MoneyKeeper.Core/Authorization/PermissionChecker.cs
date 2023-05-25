using Abp.Authorization;
using MoneyKeeper.Authorization.Roles;
using MoneyKeeper.Authorization.Users;

namespace MoneyKeeper.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
