using System;
using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace MoneyKeeper.EntityFrameworkCore
{
    public static class MoneyKeeperDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<MoneyKeeperDbContext> builder, string connectionString)
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
            builder.UseNpgsql(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<MoneyKeeperDbContext> builder, DbConnection connection)
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
            builder.UseNpgsql(connection);
        }
    }
}
