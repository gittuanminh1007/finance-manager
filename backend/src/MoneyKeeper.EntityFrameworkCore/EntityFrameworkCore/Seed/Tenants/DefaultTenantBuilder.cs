using System.Linq;
using Microsoft.EntityFrameworkCore;
using Abp.MultiTenancy;
using MoneyKeeper.MultiTenancy;

namespace MoneyKeeper.EntityFrameworkCore.Seed.Tenants
{
    public class DefaultTenantBuilder
    {
        private readonly MoneyKeeperDbContext _context;

        public DefaultTenantBuilder(MoneyKeeperDbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            CreateDefaultTenant();
        }

        private void CreateDefaultTenant()
        {
            // Default tenant

            var defaultTenant = _context.Tenants.IgnoreQueryFilters().FirstOrDefault(t => t.TenancyName == AbpTenantBase.DefaultTenantName);
            if (defaultTenant == null)
            {
                defaultTenant = new Tenant(AbpTenantBase.DefaultTenantName, AbpTenantBase.DefaultTenantName);

                _context.Tenants.Add(defaultTenant);
                _context.SaveChanges();
            }
        }
    }
}
