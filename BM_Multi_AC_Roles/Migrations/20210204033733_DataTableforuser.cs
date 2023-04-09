using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BM_Multi_AC_Roles.Migrations
{
    public partial class DataTableforuser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    CompanyId = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    BusinessID = table.Column<string>(nullable: true),
                    BillingAddress = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    Country = table.Column<string>(nullable: true),
                    InvoiceCount = table.Column<int>(nullable: false),
                    OrderCount = table.Column<int>(nullable: false),
                    TotalInvoiceAmount = table.Column<decimal>(nullable: false),
                    PaidInvoiceAmount = table.Column<decimal>(nullable: false),
                    BalanceAmount = table.Column<decimal>(nullable: false),
                    TotalTax = table.Column<decimal>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateLastModified = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    EmailID = table.Column<string>(nullable: true),
                    ContactNumber = table.Column<string>(nullable: true),
                    ContactPerson = table.Column<string>(nullable: true),
                    ContactTitle = table.Column<string>(nullable: true),
                    ExtraColumn1 = table.Column<string>(nullable: true),
                    ExtraColumn2 = table.Column<string>(nullable: true),
                    ExtraColumn3 = table.Column<string>(nullable: true),
                    ExtraColumn4 = table.Column<string>(nullable: true),
                    ExtraColumn5 = table.Column<string>(nullable: true),
                    ExtraColumn6 = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.CompanyId);
                });

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    CountryID = table.Column<string>(nullable: false),
                    CountryCode = table.Column<string>(nullable: true),
                    CountryName = table.Column<string>(nullable: true),
                    Currency = table.Column<string>(nullable: true),
                    CurrencySymbol = table.Column<string>(nullable: true),
                    ExtraColumn1 = table.Column<string>(nullable: true),
                    ExtraColumn2 = table.Column<string>(nullable: true),
                    ExtraColumn3 = table.Column<string>(nullable: true),
                    ExtraColumn4 = table.Column<string>(nullable: true),
                    ExtraColumn5 = table.Column<string>(nullable: true),
                    ExtraColumn6 = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.CountryID);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    EmployeeID = table.Column<string>(nullable: false),
                    EmployeeNumber = table.Column<int>(nullable: false),
                    LastName = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    JobTitle = table.Column<string>(nullable: true),
                    Joblevel = table.Column<string>(nullable: true),
                    TitleOfCourtesy = table.Column<string>(nullable: true),
                    BirthDate = table.Column<DateTime>(nullable: false),
                    HireDate = table.Column<DateTime>(nullable: false),
                    Address = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    Region = table.Column<string>(nullable: true),
                    PostalCode = table.Column<string>(nullable: true),
                    Country = table.Column<string>(nullable: true),
                    HomePhone = table.Column<string>(nullable: true),
                    Extension = table.Column<string>(nullable: true),
                    EmailID = table.Column<string>(nullable: true),
                    ContactNumber = table.Column<string>(nullable: true),
                    Notes = table.Column<string>(nullable: true),
                    ReportsTo = table.Column<string>(nullable: true),
                    PhotoPath = table.Column<string>(nullable: true),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateLastModified = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    ExtraColumn1 = table.Column<string>(nullable: true),
                    ExtraColumn2 = table.Column<string>(nullable: true),
                    ExtraColumn3 = table.Column<string>(nullable: true),
                    ExtraColumn4 = table.Column<string>(nullable: true),
                    ExtraColumn5 = table.Column<string>(nullable: true),
                    ExtraColumn6 = table.Column<string>(nullable: true),
                    EmployeeHeadEmployeeID = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.EmployeeID);
                    table.ForeignKey(
                        name: "FK_Employees_Employees_EmployeeHeadEmployeeID",
                        column: x => x.EmployeeHeadEmployeeID,
                        principalTable: "Employees",
                        principalColumn: "EmployeeID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Suppliers",
                columns: table => new
                {
                    SupplierID = table.Column<string>(nullable: false),
                    SupplierName = table.Column<string>(nullable: true),
                    ContactName = table.Column<string>(nullable: true),
                    ContactTitle = table.Column<string>(nullable: true),
                    EmailID = table.Column<string>(nullable: true),
                    ContactNumber = table.Column<string>(nullable: true),
                    BusinessID = table.Column<string>(nullable: true),
                    BillingAddress = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    Country = table.Column<string>(nullable: true),
                    PurchaseInvoiceCount = table.Column<int>(nullable: false),
                    PurchaseOrderCount = table.Column<int>(nullable: false),
                    TotalPurchaseInvoiceAmount = table.Column<decimal>(nullable: false),
                    PaidPurchaseInvoiceAmount = table.Column<decimal>(nullable: false),
                    BalanceAmount = table.Column<decimal>(nullable: false),
                    TotalTax = table.Column<decimal>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateLastModified = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    ExtraColumn1 = table.Column<string>(nullable: true),
                    ExtraColumn2 = table.Column<string>(nullable: true),
                    ExtraColumn3 = table.Column<string>(nullable: true),
                    ExtraColumn4 = table.Column<string>(nullable: true),
                    ExtraColumn5 = table.Column<string>(nullable: true),
                    ExtraColumn6 = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suppliers", x => x.SupplierID);
                });

            migrationBuilder.CreateTable(
                name: "TaxTypes",
                columns: table => new
                {
                    TaxID = table.Column<string>(nullable: false),
                    CountryID = table.Column<string>(nullable: true),
                    CountryName = table.Column<string>(nullable: true),
                    TaxName = table.Column<string>(nullable: true),
                    Tax = table.Column<decimal>(nullable: false),
                    ExtraColumn1 = table.Column<string>(nullable: true),
                    ExtraColumn2 = table.Column<string>(nullable: true),
                    ExtraColumn3 = table.Column<string>(nullable: true),
                    ExtraColumn4 = table.Column<string>(nullable: true),
                    ExtraColumn5 = table.Column<string>(nullable: true),
                    ExtraColumn6 = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaxTypes", x => x.TaxID);
                    table.ForeignKey(
                        name: "FK_TaxTypes_Countries_CountryID",
                        column: x => x.CountryID,
                        principalTable: "Countries",
                        principalColumn: "CountryID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    OrderID = table.Column<string>(nullable: false),
                    OrderNumber = table.Column<string>(nullable: true),
                    CustomerID = table.Column<string>(nullable: true),
                    CustomerName = table.Column<string>(nullable: true),
                    EmployeeID = table.Column<string>(nullable: true),
                    OrderDate = table.Column<DateTime>(nullable: false),
                    RequiredDate = table.Column<DateTime>(nullable: false),
                    ShippedDate = table.Column<DateTime>(nullable: false),
                    BillingAddress = table.Column<string>(nullable: true),
                    ShippingAddress = table.Column<string>(nullable: true),
                    Condition = table.Column<string>(nullable: true),
                    TotalAmountBeforeTax = table.Column<decimal>(nullable: false),
                    TotalDiscount = table.Column<decimal>(nullable: false),
                    TotalTax = table.Column<decimal>(nullable: false),
                    TotalAmount = table.Column<decimal>(nullable: false),
                    Remarks = table.Column<string>(nullable: true),
                    ExtraColumn1 = table.Column<string>(nullable: true),
                    ExtraColumn2 = table.Column<string>(nullable: true),
                    ExtraColumn3 = table.Column<string>(nullable: true),
                    ExtraColumn4 = table.Column<string>(nullable: true),
                    ExtraColumn5 = table.Column<string>(nullable: true),
                    ExtraColumn6 = table.Column<string>(nullable: true),
                    CompanyId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.OrderID);
                    table.ForeignKey(
                        name: "FK_Orders_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "CompanyId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Orders_Employees_EmployeeID",
                        column: x => x.EmployeeID,
                        principalTable: "Employees",
                        principalColumn: "EmployeeID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SaleInvoices",
                columns: table => new
                {
                    SaleInvoceID = table.Column<string>(nullable: false),
                    SaleInvoceNumber = table.Column<string>(nullable: true),
                    CustomerID = table.Column<string>(nullable: true),
                    CustomerName = table.Column<string>(nullable: true),
                    CustomerBusinessID = table.Column<string>(nullable: true),
                    EmployeeID = table.Column<string>(nullable: true),
                    EmployeeName = table.Column<string>(nullable: true),
                    InvoiceDate = table.Column<DateTime>(nullable: false),
                    RequiredDate = table.Column<DateTime>(nullable: false),
                    ShippedDate = table.Column<DateTime>(nullable: false),
                    BillingAddress = table.Column<string>(nullable: true),
                    ShippingAddress = table.Column<string>(nullable: true),
                    Condition = table.Column<string>(nullable: true),
                    TotalAmountBeforeTax = table.Column<decimal>(nullable: false),
                    TotalDiscount = table.Column<decimal>(nullable: false),
                    TotalTax = table.Column<decimal>(nullable: false),
                    TotalAmount = table.Column<decimal>(nullable: false),
                    Remarks = table.Column<string>(nullable: true),
                    ExtraColumn1 = table.Column<string>(nullable: true),
                    ExtraColumn2 = table.Column<string>(nullable: true),
                    ExtraColumn3 = table.Column<string>(nullable: true),
                    ExtraColumn4 = table.Column<string>(nullable: true),
                    ExtraColumn5 = table.Column<string>(nullable: true),
                    ExtraColumn6 = table.Column<string>(nullable: true),
                    CompanyId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SaleInvoices", x => x.SaleInvoceID);
                    table.ForeignKey(
                        name: "FK_SaleInvoices_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "CompanyId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SaleInvoices_Employees_EmployeeID",
                        column: x => x.EmployeeID,
                        principalTable: "Employees",
                        principalColumn: "EmployeeID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    ItemID = table.Column<string>(nullable: false),
                    ItemName = table.Column<string>(nullable: true),
                    ItemNumber = table.Column<string>(nullable: true),
                    ItemCode = table.Column<string>(nullable: true),
                    ItemHSNCode = table.Column<string>(nullable: true),
                    SupplierID = table.Column<string>(nullable: true),
                    QuantityPerUnit = table.Column<string>(nullable: true),
                    UnitPrice = table.Column<decimal>(nullable: false),
                    UnitsInStock = table.Column<decimal>(nullable: false),
                    UnitsOnOrder = table.Column<decimal>(nullable: false),
                    ReorderLevel = table.Column<decimal>(nullable: false),
                    Discontinued = table.Column<bool>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateLastModified = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    ExtraColumn1 = table.Column<string>(nullable: true),
                    ExtraColumn2 = table.Column<string>(nullable: true),
                    ExtraColumn3 = table.Column<string>(nullable: true),
                    ExtraColumn4 = table.Column<string>(nullable: true),
                    ExtraColumn5 = table.Column<string>(nullable: true),
                    ExtraColumn6 = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.ItemID);
                    table.ForeignKey(
                        name: "FK_Items_Suppliers_SupplierID",
                        column: x => x.SupplierID,
                        principalTable: "Suppliers",
                        principalColumn: "SupplierID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SubTaxes",
                columns: table => new
                {
                    TaxID = table.Column<string>(nullable: false),
                    SubTaxName = table.Column<decimal>(nullable: false),
                    Tax = table.Column<decimal>(nullable: false),
                    ExtraColumn1 = table.Column<string>(nullable: true),
                    ExtraColumn2 = table.Column<string>(nullable: true),
                    ExtraColumn3 = table.Column<string>(nullable: true),
                    ExtraColumn4 = table.Column<string>(nullable: true),
                    ExtraColumn5 = table.Column<string>(nullable: true),
                    ExtraColumn6 = table.Column<string>(nullable: true),
                    TaxTypeTaxID = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubTaxes", x => x.TaxID);
                    table.ForeignKey(
                        name: "FK_SubTaxes_TaxTypes_TaxTypeTaxID",
                        column: x => x.TaxTypeTaxID,
                        principalTable: "TaxTypes",
                        principalColumn: "TaxID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Order_Items",
                columns: table => new
                {
                    OrderItemID = table.Column<string>(nullable: false),
                    OrderID = table.Column<string>(nullable: true),
                    ItemID = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    ItemCode = table.Column<string>(nullable: true),
                    HSNCode = table.Column<string>(nullable: true),
                    UnitPrice = table.Column<decimal>(nullable: false),
                    Quantity = table.Column<decimal>(nullable: false),
                    Discount = table.Column<decimal>(nullable: false),
                    TaxID = table.Column<string>(nullable: true),
                    Tax = table.Column<decimal>(nullable: false),
                    Amount = table.Column<decimal>(nullable: false),
                    TaxAmount = table.Column<decimal>(nullable: false),
                    DiscountAmount = table.Column<decimal>(nullable: false),
                    TaxTypeTaxID = table.Column<string>(nullable: true),
                    ExtraColumn1 = table.Column<string>(nullable: true),
                    ExtraColumn2 = table.Column<string>(nullable: true),
                    ExtraColumn3 = table.Column<string>(nullable: true),
                    ExtraColumn4 = table.Column<string>(nullable: true),
                    ExtraColumn5 = table.Column<string>(nullable: true),
                    ExtraColumn6 = table.Column<string>(nullable: true),
                    ItemsItemID = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order_Items", x => x.OrderItemID);
                    table.ForeignKey(
                        name: "FK_Order_Items_Items_ItemsItemID",
                        column: x => x.ItemsItemID,
                        principalTable: "Items",
                        principalColumn: "ItemID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Order_Items_Orders_OrderID",
                        column: x => x.OrderID,
                        principalTable: "Orders",
                        principalColumn: "OrderID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Order_Items_TaxTypes_TaxTypeTaxID",
                        column: x => x.TaxTypeTaxID,
                        principalTable: "TaxTypes",
                        principalColumn: "TaxID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SaleInvoice_Items",
                columns: table => new
                {
                    SaleInvoiceItemID = table.Column<string>(nullable: false),
                    SalesInvoiceID = table.Column<string>(nullable: true),
                    ItemID = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    ItemCode = table.Column<string>(nullable: true),
                    HSNCode = table.Column<string>(nullable: true),
                    UnitPrice = table.Column<decimal>(nullable: false),
                    Quantity = table.Column<decimal>(nullable: false),
                    Discount = table.Column<decimal>(nullable: false),
                    TaxID = table.Column<string>(nullable: true),
                    Tax = table.Column<decimal>(nullable: false),
                    Amount = table.Column<decimal>(nullable: false),
                    TaxAmount = table.Column<decimal>(nullable: false),
                    DiscountAmount = table.Column<decimal>(nullable: false),
                    TaxTypeTaxID = table.Column<string>(nullable: true),
                    ExtraColumn1 = table.Column<string>(nullable: true),
                    ExtraColumn2 = table.Column<string>(nullable: true),
                    ExtraColumn3 = table.Column<string>(nullable: true),
                    ExtraColumn4 = table.Column<string>(nullable: true),
                    ExtraColumn5 = table.Column<string>(nullable: true),
                    ExtraColumn6 = table.Column<string>(nullable: true),
                    SaleInvoiceSaleInvoceID = table.Column<string>(nullable: true),
                    ItemsItemID = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SaleInvoice_Items", x => x.SaleInvoiceItemID);
                    table.ForeignKey(
                        name: "FK_SaleInvoice_Items_Items_ItemsItemID",
                        column: x => x.ItemsItemID,
                        principalTable: "Items",
                        principalColumn: "ItemID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SaleInvoice_Items_SaleInvoices_SaleInvoiceSaleInvoceID",
                        column: x => x.SaleInvoiceSaleInvoceID,
                        principalTable: "SaleInvoices",
                        principalColumn: "SaleInvoceID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SaleInvoice_Items_TaxTypes_TaxTypeTaxID",
                        column: x => x.TaxTypeTaxID,
                        principalTable: "TaxTypes",
                        principalColumn: "TaxID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employees_EmployeeHeadEmployeeID",
                table: "Employees",
                column: "EmployeeHeadEmployeeID");

            migrationBuilder.CreateIndex(
                name: "IX_Items_SupplierID",
                table: "Items",
                column: "SupplierID");

            migrationBuilder.CreateIndex(
                name: "IX_Order_Items_ItemsItemID",
                table: "Order_Items",
                column: "ItemsItemID");

            migrationBuilder.CreateIndex(
                name: "IX_Order_Items_OrderID",
                table: "Order_Items",
                column: "OrderID");

            migrationBuilder.CreateIndex(
                name: "IX_Order_Items_TaxTypeTaxID",
                table: "Order_Items",
                column: "TaxTypeTaxID");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CompanyId",
                table: "Orders",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_EmployeeID",
                table: "Orders",
                column: "EmployeeID");

            migrationBuilder.CreateIndex(
                name: "IX_SaleInvoice_Items_ItemsItemID",
                table: "SaleInvoice_Items",
                column: "ItemsItemID");

            migrationBuilder.CreateIndex(
                name: "IX_SaleInvoice_Items_SaleInvoiceSaleInvoceID",
                table: "SaleInvoice_Items",
                column: "SaleInvoiceSaleInvoceID");

            migrationBuilder.CreateIndex(
                name: "IX_SaleInvoice_Items_TaxTypeTaxID",
                table: "SaleInvoice_Items",
                column: "TaxTypeTaxID");

            migrationBuilder.CreateIndex(
                name: "IX_SaleInvoices_CompanyId",
                table: "SaleInvoices",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_SaleInvoices_EmployeeID",
                table: "SaleInvoices",
                column: "EmployeeID");

            migrationBuilder.CreateIndex(
                name: "IX_SubTaxes_TaxTypeTaxID",
                table: "SubTaxes",
                column: "TaxTypeTaxID");

            migrationBuilder.CreateIndex(
                name: "IX_TaxTypes_CountryID",
                table: "TaxTypes",
                column: "CountryID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Order_Items");

            migrationBuilder.DropTable(
                name: "SaleInvoice_Items");

            migrationBuilder.DropTable(
                name: "SubTaxes");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropTable(
                name: "SaleInvoices");

            migrationBuilder.DropTable(
                name: "TaxTypes");

            migrationBuilder.DropTable(
                name: "Suppliers");

            migrationBuilder.DropTable(
                name: "Companies");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Countries");
        }
    }
}
