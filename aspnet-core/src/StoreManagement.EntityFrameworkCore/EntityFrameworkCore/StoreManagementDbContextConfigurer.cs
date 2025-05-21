using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace StoreManagement.EntityFrameworkCore
{
    public static class StoreManagementDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<StoreManagementDbContext> builder, string connectionString)
        {
            builder.UseNpgsql(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<StoreManagementDbContext> builder, DbConnection connection)
        {
            builder.UseNpgsql(connection);
        }
    }
}
