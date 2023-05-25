using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace MoneyKeeper.EntityFrameworkCore
{
    public static class MoneyKeeperDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<MoneyKeeperDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<MoneyKeeperDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}
