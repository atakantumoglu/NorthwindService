//namespace InventoryService.Domain.Entities;

//public partial class NorthwindContext : DbContext
//{
//    public NorthwindContext()
//    {
//    }

//    public NorthwindContext(DbContextOptions<NorthwindContext> options)
//        : base(options)
//    {
//    }


//    protected override void OnModelCreating(ModelBuilder modelBuilder)
//    {


//        modelBuilder.Entity<Customer>(builder =>
//        {
//            builder.HasIndex(e => e.City, "City");

//            builder.HasIndex(e => e.CompanyName, "CompanyName");

//            builder.HasIndex(e => e.PostalCode, "PostalCode");

//            builder.HasIndex(e => e.Region, "Region");

//            builder.Property(e => e.CustomerId)
//                .HasMaxLength(5)
//                .IsFixedLength()
//                .HasColumnName("CustomerID");
//            builder.Property(e => e.Address).HasMaxLength(60);
//            builder.Property(e => e.City).HasMaxLength(15);
//            builder.Property(e => e.CompanyName).HasMaxLength(40);
//            builder.Property(e => e.ContactName).HasMaxLength(30);
//            builder.Property(e => e.ContactTitle).HasMaxLength(30);
//            builder.Property(e => e.Country).HasMaxLength(15);
//            builder.Property(e => e.Fax).HasMaxLength(24);
//            builder.Property(e => e.Phone).HasMaxLength(24);
//            builder.Property(e => e.PostalCode).HasMaxLength(10);
//            builder.Property(e => e.Region).HasMaxLength(15);

//            builder.HasMany(d => d.CustomerTypes).WithMany(p => p.Customers)
//                .UsingEntity<Dictionary<string, object>>(
//                    "CustomerCustomerDemo",
//                    r => r.HasOne<CustomerDemographic>().WithMany()
//                        .HasForeignKey("CustomerTypeId")
//                        .OnDelete(DeleteBehavior.ClientSetNull)
//                        .HasConstraintName("FK_CustomerCustomerDemo"),
//                    l => l.HasOne<Customer>().WithMany()
//                        .HasForeignKey("CustomerId")
//                        .OnDelete(DeleteBehavior.ClientSetNull)
//                        .HasConstraintName("FK_CustomerCustomerDemo_Customers"),
//                    j =>
//                    {
//                        j.HasKey("CustomerId", "CustomerTypeId").IsClustered(false);
//                        j.ToTable("CustomerCustomerDemo");
//                        j.IndexerProperty<string>("CustomerId")
//                            .HasMaxLength(5)
//                            .IsFixedLength()
//                            .HasColumnName("CustomerID");
//                        j.IndexerProperty<string>("CustomerTypeId")
//                            .HasMaxLength(10)
//                            .IsFixedLength()
//                            .HasColumnName("CustomerTypeID");
//                    });
//        });

//        modelBuilder.Entity<CustomerAndSuppliersByCity>(builder =>
//        {
//            builder
//                .HasNoKey()
//                .ToView("Customer and Suppliers by City");

//            builder.Property(e => e.City).HasMaxLength(15);
//            builder.Property(e => e.CompanyName).HasMaxLength(40);
//            builder.Property(e => e.ContactName).HasMaxLength(30);
//            builder.Property(e => e.Relationship)
//                .HasMaxLength(9)
//                .IsUnicode(false);
//        });

//        modelBuilder.Entity<CustomerDemographic>(builder =>
//        {
//            builder.HasKey(e => e.CustomerTypeId).IsClustered(false);

//            builder.Property(e => e.CustomerTypeId)
//                .HasMaxLength(10)
//                .IsFixedLength()
//                .HasColumnName("CustomerTypeID");
//            builder.Property(e => e.CustomerDesc).HasColumnType("ntext");
//        });

//        modelBuilder.Entity<Employee>(builder =>
//        {
//            builder.HasIndex(e => e.LastName, "LastName");

//            builder.HasIndex(e => e.PostalCode, "PostalCode");

//            builder.Property(e => e.EmployeeId).HasColumnName("EmployeeID");
//            builder.Property(e => e.Address).HasMaxLength(60);
//            builder.Property(e => e.BirthDate).HasColumnType("datetime");
//            builder.Property(e => e.City).HasMaxLength(15);
//            builder.Property(e => e.Country).HasMaxLength(15);
//            builder.Property(e => e.Extension).HasMaxLength(4);
//            builder.Property(e => e.FirstName).HasMaxLength(10);
//            builder.Property(e => e.HireDate).HasColumnType("datetime");
//            builder.Property(e => e.HomePhone).HasMaxLength(24);
//            builder.Property(e => e.LastName).HasMaxLength(20);
//            builder.Property(e => e.Notes).HasColumnType("ntext");
//            builder.Property(e => e.Photo).HasColumnType("image");
//            builder.Property(e => e.PhotoPath).HasMaxLength(255);
//            builder.Property(e => e.PostalCode).HasMaxLength(10);
//            builder.Property(e => e.Region).HasMaxLength(15);
//            builder.Property(e => e.Title).HasMaxLength(30);
//            builder.Property(e => e.TitleOfCourtesy).HasMaxLength(25);

//            builder.HasOne(d => d.ReportsToNavigation).WithMany(p => p.InverseReportsToNavigation)
//                .HasForeignKey(d => d.ReportsTo)
//                .HasConstraintName("FK_Employees_Employees");

//            builder.HasMany(d => d.Territories).WithMany(p => p.Employees)
//                .UsingEntity<Dictionary<string, object>>(
//                    "EmployeeTerritory",
//                    r => r.HasOne<Territory>().WithMany()
//                        .HasForeignKey("TerritoryId")
//                        .OnDelete(DeleteBehavior.ClientSetNull)
//                        .HasConstraintName("FK_EmployeeTerritories_Territories"),
//                    l => l.HasOne<Employee>().WithMany()
//                        .HasForeignKey("EmployeeId")
//                        .OnDelete(DeleteBehavior.ClientSetNull)
//                        .HasConstraintName("FK_EmployeeTerritories_Employees"),
//                    j =>
//                    {
//                        j.HasKey("EmployeeId", "TerritoryId").IsClustered(false);
//                        j.ToTable("EmployeeTerritories");
//                        j.IndexerProperty<int>("EmployeeId").HasColumnName("EmployeeID");
//                        j.IndexerProperty<string>("TerritoryId")
//                            .HasMaxLength(20)
//                            .HasColumnName("TerritoryID");
//                    });
//        });

//        modelBuilder.Entity<Invoice>(builder =>
//        {
//            builder
//                .HasNoKey()
//                .ToView("Invoices");

//            builder.Property(e => e.Address).HasMaxLength(60);
//            builder.Property(e => e.City).HasMaxLength(15);
//            builder.Property(e => e.Country).HasMaxLength(15);
//            builder.Property(e => e.CustomerId)
//                .HasMaxLength(5)
//                .IsFixedLength()
//                .HasColumnName("CustomerID");
//            builder.Property(e => e.CustomerName).HasMaxLength(40);
//            builder.Property(e => e.ExtendedPrice).HasColumnType("money");
//            builder.Property(e => e.Freight).HasColumnType("money");
//            builder.Property(e => e.OrderDate).HasColumnType("datetime");
//            builder.Property(e => e.OrderId).HasColumnName("OrderID");
//            builder.Property(e => e.PostalCode).HasMaxLength(10);
//            builder.Property(e => e.ProductId).HasColumnName("ProductID");
//            builder.Property(e => e.ProductName).HasMaxLength(40);
//            builder.Property(e => e.Region).HasMaxLength(15);
//            builder.Property(e => e.RequiredDate).HasColumnType("datetime");
//            builder.Property(e => e.Salesperson).HasMaxLength(31);
//            builder.Property(e => e.ShipAddress).HasMaxLength(60);
//            builder.Property(e => e.ShipCity).HasMaxLength(15);
//            builder.Property(e => e.ShipCountry).HasMaxLength(15);
//            builder.Property(e => e.ShipName).HasMaxLength(40);
//            builder.Property(e => e.ShipPostalCode).HasMaxLength(10);
//            builder.Property(e => e.ShipRegion).HasMaxLength(15);
//            builder.Property(e => e.ShippedDate).HasColumnType("datetime");
//            builder.Property(e => e.ShipperName).HasMaxLength(40);
//            builder.Property(e => e.UnitPrice).HasColumnType("money");
//        });

//        modelBuilder.Entity<Order>(builder =>
//        {
//            builder.HasIndex(e => e.CustomerId, "CustomerID");

//            builder.HasIndex(e => e.CustomerId, "CustomersOrders");

//            builder.HasIndex(e => e.EmployeeId, "EmployeeID");

//            builder.HasIndex(e => e.EmployeeId, "EmployeesOrders");

//            builder.HasIndex(e => e.OrderDate, "OrderDate");

//            builder.HasIndex(e => e.ShipPostalCode, "ShipPostalCode");

//            builder.HasIndex(e => e.ShippedDate, "ShippedDate");

//            builder.HasIndex(e => e.ShipVia, "ShippersOrders");

//            builder.Property(e => e.OrderId).HasColumnName("OrderID");
//            builder.Property(e => e.CustomerId)
//                .HasMaxLength(5)
//                .IsFixedLength()
//                .HasColumnName("CustomerID");
//            builder.Property(e => e.EmployeeId).HasColumnName("EmployeeID");
//            builder.Property(e => e.Freight)
//                .HasDefaultValueSql("((0))")
//                .HasColumnType("money");
//            builder.Property(e => e.OrderDate).HasColumnType("datetime");
//            builder.Property(e => e.RequiredDate).HasColumnType("datetime");
//            builder.Property(e => e.ShipAddress).HasMaxLength(60);
//            builder.Property(e => e.ShipCity).HasMaxLength(15);
//            builder.Property(e => e.ShipCountry).HasMaxLength(15);
//            builder.Property(e => e.ShipName).HasMaxLength(40);
//            builder.Property(e => e.ShipPostalCode).HasMaxLength(10);
//            builder.Property(e => e.ShipRegion).HasMaxLength(15);
//            builder.Property(e => e.ShippedDate).HasColumnType("datetime");

//            builder.HasOne(d => d.Customer).WithMany(p => p.Orders)
//                .HasForeignKey(d => d.CustomerId)
//                .HasConstraintName("FK_Orders_Customers");

//            builder.HasOne(d => d.Employee).WithMany(p => p.Orders)
//                .HasForeignKey(d => d.EmployeeId)
//                .HasConstraintName("FK_Orders_Employees");

//            builder.HasOne(d => d.ShipViaNavigation).WithMany(p => p.Orders)
//                .HasForeignKey(d => d.ShipVia)
//                .HasConstraintName("FK_Orders_Shippers");
//        });

//        modelBuilder.Entity<OrderDetail>(builder =>
//        {
//            builder.HasKey(e => new { e.OrderId, e.ProductId }).HasName("PK_Order_Details");

//            builder.ToTable("Order Details");

//            builder.HasIndex(e => e.OrderId, "OrderID");

//            builder.HasIndex(e => e.OrderId, "OrdersOrder_Details");

//            builder.HasIndex(e => e.ProductId, "ProductID");

//            builder.HasIndex(e => e.ProductId, "ProductsOrder_Details");

//            builder.Property(e => e.OrderId).HasColumnName("OrderID");
//            builder.Property(e => e.ProductId).HasColumnName("ProductID");
//            builder.Property(e => e.Quantity).HasDefaultValueSql("((1))");
//            builder.Property(e => e.UnitPrice).HasColumnType("money");

//            builder.HasOne(d => d.Order).WithMany(p => p.OrderDetails)
//                .HasForeignKey(d => d.OrderId)
//                .OnDelete(DeleteBehavior.ClientSetNull)
//                .HasConstraintName("FK_Order_Details_Orders");

//            builder.HasOne(d => d.Product).WithMany(p => p.OrderDetails)
//                .HasForeignKey(d => d.ProductId)
//                .OnDelete(DeleteBehavior.ClientSetNull)
//                .HasConstraintName("FK_Order_Details_Products");
//        });

//        modelBuilder.Entity<OrderDetailsExtended>(builder =>
//        {
//            builder
//                .HasNoKey()
//                .ToView("Order Details Extended");

//            builder.Property(e => e.ExtendedPrice).HasColumnType("money");
//            builder.Property(e => e.OrderId).HasColumnName("OrderID");
//            builder.Property(e => e.ProductId).HasColumnName("ProductID");
//            builder.Property(e => e.ProductName).HasMaxLength(40);
//            builder.Property(e => e.UnitPrice).HasColumnType("money");
//        });

//        modelBuilder.Entity<OrderSubtotal>(builder =>
//        {
//            builder
//                .HasNoKey()
//                .ToView("Order Subtotals");

//            builder.Property(e => e.OrderId).HasColumnName("OrderID");
//            builder.Property(e => e.Subtotal).HasColumnType("money");
//        });

//        modelBuilder.Entity<OrdersQry>(builder =>
//        {
//            builder
//                .HasNoKey()
//                .ToView("Orders Qry");

//            builder.Property(e => e.Address).HasMaxLength(60);
//            builder.Property(e => e.City).HasMaxLength(15);
//            builder.Property(e => e.CompanyName).HasMaxLength(40);
//            builder.Property(e => e.Country).HasMaxLength(15);
//            builder.Property(e => e.CustomerId)
//                .HasMaxLength(5)
//                .IsFixedLength()
//                .HasColumnName("CustomerID");
//            builder.Property(e => e.EmployeeId).HasColumnName("EmployeeID");
//            builder.Property(e => e.Freight).HasColumnType("money");
//            builder.Property(e => e.OrderDate).HasColumnType("datetime");
//            builder.Property(e => e.OrderId).HasColumnName("OrderID");
//            builder.Property(e => e.PostalCode).HasMaxLength(10);
//            builder.Property(e => e.Region).HasMaxLength(15);
//            builder.Property(e => e.RequiredDate).HasColumnType("datetime");
//            builder.Property(e => e.ShipAddress).HasMaxLength(60);
//            builder.Property(e => e.ShipCity).HasMaxLength(15);
//            builder.Property(e => e.ShipCountry).HasMaxLength(15);
//            builder.Property(e => e.ShipName).HasMaxLength(40);
//            builder.Property(e => e.ShipPostalCode).HasMaxLength(10);
//            builder.Property(e => e.ShipRegion).HasMaxLength(15);
//            builder.Property(e => e.ShippedDate).HasColumnType("datetime");
//        });

//        modelBuilder.Entity<Product>(builder =>
//        {
//            builder.HasIndex(e => e.CategoryId, "CategoriesProducts");

//            builder.HasIndex(e => e.CategoryId, "CategoryID");

//            builder.HasIndex(e => e.ProductName, "ProductName");

//            builder.HasIndex(e => e.SupplierId, "SupplierID");

//            builder.HasIndex(e => e.SupplierId, "SuppliersProducts");

//            builder.Property(e => e.ProductId).HasColumnName("ProductID");
//            builder.Property(e => e.CategoryId).HasColumnName("CategoryID");
//            builder.Property(e => e.ProductName).HasMaxLength(40);
//            builder.Property(e => e.QuantityPerUnit).HasMaxLength(20);
//            builder.Property(e => e.ReorderLevel).HasDefaultValueSql("((0))");
//            builder.Property(e => e.SupplierId).HasColumnName("SupplierID");
//            builder.Property(e => e.UnitPrice)
//                .HasDefaultValueSql("((0))")
//                .HasColumnType("money");
//            builder.Property(e => e.UnitsInStock).HasDefaultValueSql("((0))");
//            builder.Property(e => e.UnitsOnOrder).HasDefaultValueSql("((0))");

//            builder.HasOne(d => d.Category).WithMany(p => p.Products)
//                .HasForeignKey(d => d.CategoryId)
//                .HasConstraintName("FK_Products_Categories");

//            builder.HasOne(d => d.Supplier).WithMany(p => p.Products)
//                .HasForeignKey(d => d.SupplierId)
//                .HasConstraintName("FK_Products_Suppliers");
//        });

//        modelBuilder.Entity<ProductSalesFor1997>(builder =>
//        {
//            builder
//                .HasNoKey()
//                .ToView("Product Sales for 1997");

//            builder.Property(e => e.CategoryName).HasMaxLength(15);
//            builder.Property(e => e.ProductName).HasMaxLength(40);
//            builder.Property(e => e.ProductSales).HasColumnType("money");
//        });

//        modelBuilder.Entity<ProductsAboveAveragePrice>(builder =>
//        {
//            builder
//                .HasNoKey()
//                .ToView("Products Above Average Price");

//            builder.Property(e => e.ProductName).HasMaxLength(40);
//            builder.Property(e => e.UnitPrice).HasColumnType("money");
//        });

//        modelBuilder.Entity<ProductsByCategory>(builder =>
//        {
//            builder
//                .HasNoKey()
//                .ToView("Products by Category");

//            builder.Property(e => e.CategoryName).HasMaxLength(15);
//            builder.Property(e => e.ProductName).HasMaxLength(40);
//            builder.Property(e => e.QuantityPerUnit).HasMaxLength(20);
//        });

//        modelBuilder.Entity<QuarterlyOrder>(builder =>
//        {
//            builder
//                .HasNoKey()
//                .ToView("Quarterly Orders");

//            builder.Property(e => e.City).HasMaxLength(15);
//            builder.Property(e => e.CompanyName).HasMaxLength(40);
//            builder.Property(e => e.Country).HasMaxLength(15);
//            builder.Property(e => e.CustomerId)
//                .HasMaxLength(5)
//                .IsFixedLength()
//                .HasColumnName("CustomerID");
//        });

//        modelBuilder.Entity<Region>(builder =>
//        {
//            builder.HasKey(e => e.RegionId).IsClustered(false);

//            builder.ToTable("Region");

//            builder.Property(e => e.RegionId)
//                .ValueGeneratedNever()
//                .HasColumnName("RegionID");
//            builder.Property(e => e.RegionDescription)
//                .HasMaxLength(50)
//                .IsFixedLength();
//        });

//        modelBuilder.Entity<SalesByCategory>(builder =>
//        {
//            builder
//                .HasNoKey()
//                .ToView("Sales by Category");

//            builder.Property(e => e.CategoryId).HasColumnName("CategoryID");
//            builder.Property(e => e.CategoryName).HasMaxLength(15);
//            builder.Property(e => e.ProductName).HasMaxLength(40);
//            builder.Property(e => e.ProductSales).HasColumnType("money");
//        });

//        modelBuilder.Entity<SalesTotalsByAmount>(builder =>
//        {
//            builder
//                .HasNoKey()
//                .ToView("Sales Totals by Amount");

//            builder.Property(e => e.CompanyName).HasMaxLength(40);
//            builder.Property(e => e.OrderId).HasColumnName("OrderID");
//            builder.Property(e => e.SaleAmount).HasColumnType("money");
//            builder.Property(e => e.ShippedDate).HasColumnType("datetime");
//        });

//        modelBuilder.Entity<Shipper>(builder =>
//        {
//            builder.Property(e => e.ShipperId).HasColumnName("ShipperID");
//            builder.Property(e => e.CompanyName).HasMaxLength(40);
//            builder.Property(e => e.Phone).HasMaxLength(24);
//        });

//        modelBuilder.Entity<SummaryOfSalesByQuarter>(builder =>
//        {
//            builder
//                .HasNoKey()
//                .ToView("Summary of Sales by Quarter");

//            builder.Property(e => e.OrderId).HasColumnName("OrderID");
//            builder.Property(e => e.ShippedDate).HasColumnType("datetime");
//            builder.Property(e => e.Subtotal).HasColumnType("money");
//        });

//        modelBuilder.Entity<SummaryOfSalesByYear>(builder =>
//        {
//            builder
//                .HasNoKey()
//                .ToView("Summary of Sales by Year");

//            builder.Property(e => e.OrderId).HasColumnName("OrderID");
//            builder.Property(e => e.ShippedDate).HasColumnType("datetime");
//            builder.Property(e => e.Subtotal).HasColumnType("money");
//        });

//        modelBuilder.Entity<Supplier>(builder =>
//        {
//            builder.HasIndex(e => e.CompanyName, "CompanyName");

//            builder.HasIndex(e => e.PostalCode, "PostalCode");

//            builder.Property(e => e.SupplierId).HasColumnName("SupplierID");
//            builder.Property(e => e.Address).HasMaxLength(60);
//            builder.Property(e => e.City).HasMaxLength(15);
//            builder.Property(e => e.CompanyName).HasMaxLength(40);
//            builder.Property(e => e.ContactName).HasMaxLength(30);
//            builder.Property(e => e.ContactTitle).HasMaxLength(30);
//            builder.Property(e => e.Country).HasMaxLength(15);
//            builder.Property(e => e.Fax).HasMaxLength(24);
//            builder.Property(e => e.HomePage).HasColumnType("ntext");
//            builder.Property(e => e.Phone).HasMaxLength(24);
//            builder.Property(e => e.PostalCode).HasMaxLength(10);
//            builder.Property(e => e.Region).HasMaxLength(15);
//        });

//        modelBuilder.Entity<Territory>(builder =>
//        {
//            builder.HasKey(e => e.TerritoryId).IsClustered(false);

//            builder.Property(e => e.TerritoryId)
//                .HasMaxLength(20)
//                .HasColumnName("TerritoryID");
//            builder.Property(e => e.RegionId).HasColumnName("RegionID");
//            builder.Property(e => e.TerritoryDescription)
//                .HasMaxLength(50)
//                .IsFixedLength();

//            builder.HasOne(d => d.Region).WithMany(p => p.Territories)
//                .HasForeignKey(d => d.RegionId)
//                .OnDelete(DeleteBehavior.ClientSetNull)
//                .HasConstraintName("FK_Territories_Region");
//        });
//    }
//}
