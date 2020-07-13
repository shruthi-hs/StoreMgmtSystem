using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StoreManagementSystem.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    ProductId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductName = table.Column<string>(maxLength: 50, nullable: false),
                    Description = table.Column<string>(maxLength: 50, nullable: false),
                    Price = table.Column<decimal>(maxLength: 50, nullable: false),
                    SKU = table.Column<string>(maxLength: 50, nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    CreatedBy = table.Column<string>(maxLength: 50, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdatedBy = table.Column<string>(maxLength: 50, nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.ProductId);
                });

            migrationBuilder.CreateTable(
                name: "Staff",
                columns: table => new
                {
                    StaffId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Firstname = table.Column<string>(maxLength: 50, nullable: false),
                    Lastname = table.Column<string>(maxLength: 50, nullable: false),
                    Email = table.Column<string>(maxLength: 50, nullable: false),
                    Phone = table.Column<string>(maxLength: 50, nullable: false),
                    Department = table.Column<string>(maxLength: 50, nullable: true),
                    CreatedBy = table.Column<string>(maxLength: 50, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdatedBy = table.Column<string>(maxLength: 50, nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Staff", x => x.StaffId);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(maxLength: 50, nullable: false),
                    Password = table.Column<string>(maxLength: 50, nullable: false),
                    IsManager = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Stock",
                columns: table => new
                {
                    StockId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(nullable: false),
                    Quantity = table.Column<decimal>(nullable: false),
                    CreatedBy = table.Column<string>(maxLength: 50, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdatedBy = table.Column<string>(maxLength: 50, nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stock", x => x.StockId);
                    table.ForeignKey(
                        name: "FK_Stocks_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "ProductId", "CreatedBy", "CreatedDate", "Description", "IsActive", "Price", "ProductName", "SKU", "UpdatedBy", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, "test", new DateTime(2020, 7, 13, 14, 19, 32, 415, DateTimeKind.Local).AddTicks(3906), "HP Laptop", true, 30000m, "HP Laptop", "12345", null, null },
                    { 2, "test", new DateTime(2020, 7, 13, 14, 19, 32, 415, DateTimeKind.Local).AddTicks(4675), "Dell Laptop", true, 20000m, "Dell Laptop", "12345", null, null }
                });

            migrationBuilder.InsertData(
                table: "Staff",
                columns: new[] { "StaffId", "CreatedBy", "CreatedDate", "Department", "Email", "Firstname", "Lastname", "Phone", "UpdatedBy", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, "test", new DateTime(2020, 7, 13, 14, 19, 32, 412, DateTimeKind.Local).AddTicks(930), null, "John@gmail.com", "John", "Wick", "1234567889", null, null },
                    { 2, "test", new DateTime(2020, 7, 13, 14, 19, 32, 413, DateTimeKind.Local).AddTicks(3372), null, "James@gmail.com", "James", "Smith", "234353543545", null, null },
                    { 3, "test", new DateTime(2020, 7, 13, 14, 19, 32, 413, DateTimeKind.Local).AddTicks(3445), null, "Joey@gmail.com", "Joey", "west", "5345345435435", null, null }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "UserId", "IsManager", "Password", "UserName" },
                values: new object[,]
                {
                    { 1, true, "Password@123", "manager@test.com" },
                    { 2, false, "Password@123", "shopkeeper@test.com" }
                });

            migrationBuilder.InsertData(
                table: "Stock",
                columns: new[] { "StockId", "CreatedBy", "CreatedDate", "ProductId", "Quantity", "UpdatedBy", "UpdatedDate" },
                values: new object[] { 1, "test", new DateTime(2020, 7, 13, 14, 19, 32, 415, DateTimeKind.Local).AddTicks(7604), 1, 30m, null, null });

            migrationBuilder.InsertData(
                table: "Stock",
                columns: new[] { "StockId", "CreatedBy", "CreatedDate", "ProductId", "Quantity", "UpdatedBy", "UpdatedDate" },
                values: new object[] { 2, "test", new DateTime(2020, 7, 13, 14, 19, 32, 415, DateTimeKind.Local).AddTicks(8284), 2, 20m, null, null });

            migrationBuilder.CreateIndex(
                name: "IX_Stock_ProductId",
                table: "Stock",
                column: "ProductId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Staff");

            migrationBuilder.DropTable(
                name: "Stock");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Product");
        }
    }
}
