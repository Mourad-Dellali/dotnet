using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ActionFilter.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Name", "Price" },
                values: new object[,]
                {
                    { new Guid("4b9e4458-72f9-47d9-9f17-5c65b9fbe11e"), "4K Monitor", 289.00m },
                    { new Guid("65f52a7a-5ed5-4e70-a3f1-94327453d6c8"), "Mechanical Keyboard", 79.50m },
                    { new Guid("6d35f2f3-e2f6-417e-97e8-3f7a56eb0f3f"), "USB-C Hub", 39.00m },
                    { new Guid("a7d5f08e-3d68-4ef8-8fb4-f0ca1a53ed01"), "Wireless Mouse", 24.99m },
                    { new Guid("ce6e0a8e-fad0-4f17-9c4a-908f4f4c8b95"), "Noise-Canceling Headphones", 149.99m },
                    { new Guid("d1e5f2a3-8c6b-4e7a-9f8e-2a3b4c5d6e7f"), "External SSD", 99.99m },
                    { new Guid("e2f6a7b8-9c1d-4f3e-8a7b-5c6d7e8f9a0b"), "Gaming Chair", 199.00m },
                    { new Guid("f90285c8-4f71-4554-b757-ad8fb8ea6cc4"), "Laptop Stand", 31.75m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
