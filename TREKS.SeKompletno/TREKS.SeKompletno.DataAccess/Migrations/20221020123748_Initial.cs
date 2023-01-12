using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TREKS.SeKompletno.DataAccess.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Admins",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Username = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<long>(nullable: false),
                    Logged = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admins", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Username = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<int>(nullable: false),
                    Address = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Manfluencers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameOfManfluencer = table.Column<string>(nullable: true),
                    TypeOfManfluencer = table.Column<int>(nullable: false),
                    AgreedPercentage = table.Column<double>(nullable: false),
                    ProductId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Manfluencers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Price = table.Column<double>(nullable: false),
                    ProductId = table.Column<int>(nullable: false),
                    Size = table.Column<int>(nullable: false),
                    CustomerId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameOfProduct = table.Column<string>(nullable: true),
                    Price = table.Column<double>(nullable: false),
                    Image = table.Column<string>(nullable: true),
                    ProductsLeft = table.Column<int>(nullable: false),
                    InStock = table.Column<bool>(nullable: false),
                    Size = table.Column<int>(nullable: false),
                    Color = table.Column<int>(nullable: false),
                    TypeOfProduct = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    ManufacturerId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Manfluencers_ManufacturerId",
                        column: x => x.ManufacturerId,
                        principalTable: "Manfluencers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SeKompletnoEarnings",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ManfluencerId = table.Column<int>(nullable: false),
                    TotalEarnings = table.Column<double>(nullable: false),
                    AdminId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SeKompletnoEarnings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SeKompletnoEarnings_Admins_AdminId",
                        column: x => x.AdminId,
                        principalTable: "Admins",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SeKompletnoEarnings_Manfluencers_ManfluencerId",
                        column: x => x.ManfluencerId,
                        principalTable: "Manfluencers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductOrder",
                columns: table => new
                {
                    OrderId = table.Column<int>(nullable: false),
                    ProductId = table.Column<int>(nullable: false),
                    Id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductOrder", x => new { x.ProductId, x.OrderId });
                    table.ForeignKey(
                        name: "FK_ProductOrder_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductOrder_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CustomerId",
                table: "Orders",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductOrder_OrderId",
                table: "ProductOrder",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ManufacturerId",
                table: "Products",
                column: "ManufacturerId");

            migrationBuilder.CreateIndex(
                name: "IX_SeKompletnoEarnings_AdminId",
                table: "SeKompletnoEarnings",
                column: "AdminId");

            migrationBuilder.CreateIndex(
                name: "IX_SeKompletnoEarnings_ManfluencerId",
                table: "SeKompletnoEarnings",
                column: "ManfluencerId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductOrder");

            migrationBuilder.DropTable(
                name: "SeKompletnoEarnings");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Admins");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Manfluencers");
        }
    }
}
