using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Warehousing.Domain.Entities;

namespace Warehousing.DataAccess.EF.Context
{
    public class WarehousingDbContext : IdentityDbContext<ApplicationUsers, ApplicationRoles, string>
    {
        public WarehousingDbContext(DbContextOptions<WarehousingDbContext> options) : base(options)
        {
        }

        #region DBSet
        public DbSet<Product> Products { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<FiscalYear> FiscalYears { get; set; }
        public DbSet<Warehouse> Warehouses { get; set; }
        public DbSet<Inventory> Inventories { get; set; }
        public DbSet<ProductPrice> ProductPrices { get; set; }
        public DbSet<ProductLocation> ProductLocations { get; set; }
        public DbSet<UserWarehouse> UserWarehouses { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<InvoiceItem> InvoiceItems { get; set; }

        #endregion DBSet

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //modelBuilder.ApplyConfigurationsFromAssembly(typeof(UserConfiguration).Assembly);
            modelBuilder.Entity<ApplicationUsers>
                (entity =>
                {
                    entity.ToTable(name: "User_Tbl");
                    entity.Property(x => x.Id).HasColumnName("UserId");
                    entity.Property(x => x.Id).ValueGeneratedOnAdd();
                });

            modelBuilder.Entity<ApplicationRoles>
                (entity =>
                {
                    entity.ToTable(name: "Roles_Tbl");
                });
        }
    }
}
