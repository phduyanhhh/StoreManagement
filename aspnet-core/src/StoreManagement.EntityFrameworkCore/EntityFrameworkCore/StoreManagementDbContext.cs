using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using StoreManagement.Authorization.Roles;
using StoreManagement.Authorization.Users;
using StoreManagement.MultiTenancy;
using System;
using StoreManagement.Entities;
using System.Linq;

namespace StoreManagement.EntityFrameworkCore
{
	public class StoreManagementDbContext : AbpZeroDbContext<Tenant, Role, User, StoreManagementDbContext>
	{
		/* Define a DbSet for each entity of the application */
		public DbSet<Distributors> Distributors { get; set; }
		public DbSet<Products> Products { get; set; }
		public DbSet<Customers> Customers { get; set; }
		public DbSet<Warehoures> Warehoures { get; set; }
		public DbSet<Orders> Orders { get; set; }
		public DbSet<OrderDetails> OrderDetails { get; set; }
		public StoreManagementDbContext(DbContextOptions<StoreManagementDbContext> options)
				: base(options)
		{
			AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
			AppContext.SetSwitch("Npgsql.DisableDateTimeInfinityConversions", true);
		}
		//protected override void OnModelCreating(ModelBuilder modelBuilder)
		//{
		//	base.OnModelCreating(modelBuilder);

		//	foreach (var property in modelBuilder.Model.GetEntityTypes()
		//			.SelectMany(t => t.GetProperties())
		//			.Where(p => p.ClrType == typeof(DateTime) || p.ClrType == typeof(DateTime?)))
		//	{
		//		property.SetColumnType("timestamp without time zone");
		//	}
		//}
	}
}
