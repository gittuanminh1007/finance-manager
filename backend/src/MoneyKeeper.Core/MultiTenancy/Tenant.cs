using Abp.MultiTenancy;
using MoneyKeeper.Authorization.Users;

namespace MoneyKeeper.MultiTenancy
{
    public class Tenant : AbpTenant<User>
    {
        public const int DefaultTenantId = 1;

        public Tenant()
        {            
        }

        public Tenant(string tenancyName, string name)
            : base(tenancyName, name)
        {
        }
    }
}
