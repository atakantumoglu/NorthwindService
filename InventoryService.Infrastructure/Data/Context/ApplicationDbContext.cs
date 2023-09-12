using NorthwindService.Domain.Entities;
using NorthwindService.Infrastructure.Data.EntityConfigurations;
using Microsoft.EntityFrameworkCore;

namespace NorthwindService.Infrastructure.Data.Context
{
    public class ApplicationDbContext : DbContext 
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<AlphabeticalListOfProduct> AlphabeticalListOfProducts { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<CategorySalesFor1997> CategorySalesFor1997s { get; set; }
        public DbSet<CurrentProductList> CurrentProductLists { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<CustomerAndSuppliersByCity> CustomerAndSuppliersByCities { get; set; }
        public DbSet<CustomerDemographic> CustomerDemographics { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<OrderDetailsExtended> OrderDetailsExtendeds { get; set; }
        public DbSet<OrderSubtotal> OrderSubtotals { get; set; }
        public DbSet<OrdersQry> OrdersQries { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductSalesFor1997> ProductSalesFor1997s { get; set; }
        public DbSet<ProductsAboveAveragePrice> ProductsAboveAveragePrices { get; set; }
        public DbSet<ProductsByCategory> ProductsByCategories { get; set; }
        public DbSet<QuarterlyOrder> QuarterlyOrders { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<SalesByCategory> SalesByCategories { get; set; }
        public DbSet<SalesTotalsByAmount> SalesTotalsByAmounts { get; set; }
        public DbSet<Shipper> Shippers { get; set; }
        public DbSet<SummaryOfSalesByQuarter> SummaryOfSalesByQuarters { get; set; }
        public DbSet<SummaryOfSalesByYear> SummaryOfSalesByYears { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Territory> Territories { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AlphabeticalListOfProductConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            modelBuilder.ApplyConfiguration(new CategorySalesFor1997Configuration());
            modelBuilder.ApplyConfiguration(new CurrentProductListConfiguration());
            modelBuilder.ApplyConfiguration(new CustomerConfiguration());
            modelBuilder.ApplyConfiguration(new CustomerAndSuppliersByCityConfiguration());
            modelBuilder.ApplyConfiguration(new CustomerDemographicConfiguration());
            modelBuilder.ApplyConfiguration(new EmployeeConfiguration());
            modelBuilder.ApplyConfiguration(new InvoiceConfiguration());
            modelBuilder.ApplyConfiguration(new OrderConfiguration());
            modelBuilder.ApplyConfiguration(new OrderDetailConfiguration());
            modelBuilder.ApplyConfiguration(new OrderDetailsExtendedConfiguration());
            modelBuilder.ApplyConfiguration(new OrdersQryConfiguration());
            modelBuilder.ApplyConfiguration(new OrdersSubtotalConfiguraion());
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new ProductsAboveAveragePriceConfiguration());
            modelBuilder.ApplyConfiguration(new ProductSalesFor1997Configuration());
            modelBuilder.ApplyConfiguration(new ProductsByCategoryConfiguration());
            modelBuilder.ApplyConfiguration(new QuarterlyOrderConfiguration());
            modelBuilder.ApplyConfiguration(new RegionConfiguration());
            modelBuilder.ApplyConfiguration(new SalesByCategoryConfiguration());
            modelBuilder.ApplyConfiguration(new SalesTotalsByAmountConfiguraiton());
            modelBuilder.ApplyConfiguration(new ShipperConfiguration());
            modelBuilder.ApplyConfiguration(new SummaryOfSalesByQuarterConfiguration());
            modelBuilder.ApplyConfiguration(new SummaryOfSalesByYearConfiguration());
            modelBuilder.ApplyConfiguration(new SupplierConfiguration());
            modelBuilder.ApplyConfiguration(new TerritoryConfiguration());
        }
    }
}

