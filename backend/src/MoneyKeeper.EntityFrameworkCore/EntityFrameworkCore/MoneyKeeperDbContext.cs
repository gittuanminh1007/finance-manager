using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using MoneyKeeper.Authorization.Roles;
using MoneyKeeper.Authorization.Users;
using MoneyKeeper.MultiTenancy;

namespace MoneyKeeper.EntityFrameworkCore
{
    public class MoneyKeeperDbContext : AbpZeroDbContext<Tenant, Role, User, MoneyKeeperDbContext>
    {
        /* Define a DbSet for each entity of the application */
        
        public MoneyKeeperDbContext(DbContextOptions<MoneyKeeperDbContext> options)
            : base(options)
        {
        }
    }
}
