using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ControllerResfulAPI.Data.Migrations
{
    /// <inheritdoc />
    public partial class IntitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Price = table.Column<decimal>(type: "deciaml(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductReviews",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    ProductId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Reviewer = table.Column<string>(type: "TEXT", nullable: false),
                    Stars = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductReviews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductReviews_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Name", "Price" },
                values: new object[,]
                {
                    { new Guid("0a5af839-5b7d-4e95-9418-0f26062734d3"), "Smart LED Desk Lamp", 42.99m },
                    { new Guid("0ee80519-7c87-4f1b-bf38-15c1a7aa4bb9"), "Wireless Charging Pad", 27.49m },
                    { new Guid("0f6f8d1e-0fd6-4622-8d85-66f3e95b0e21"), "Webcam 1080p", 59.99m },
                    { new Guid("15f2365e-45cd-48d0-a706-a1b0c6dbf831"), "Portable Bluetooth Speaker", 68.25m },
                    { new Guid("31b7c4d1-cb4e-4f61-8fcb-b5e2fc3a6942"), "Ergonomic Chair Cushion", 44.50m },
                    { new Guid("4b9e4458-72f9-47d9-9f17-5c65b9fbe11e"), "4K Monitor", 289.00m },
                    { new Guid("5ea94313-b5ec-44ed-b259-f41ba84f6c5d"), "External SSD 1TB", 109.00m },
                    { new Guid("65f52a7a-5ed5-4e70-a3f1-94327453d6c8"), "Mechanical Keyboard", 79.50m },
                    { new Guid("6d35f2f3-e2f6-417e-97e8-3f7a56eb0f3f"), "USB-C Hub", 39.00m },
                    { new Guid("70ef8a9a-3e8d-4d6b-94ba-7f83d710c3a2"), "Gaming Mouse Pad", 19.95m },
                    { new Guid("a7d5f08e-3d68-4ef8-8fb4-f0ca1a53ed01"), "Wireless Mouse", 24.99m },
                    { new Guid("ce6e0a8e-fad0-4f17-9c4a-908f4f4c8b95"), "Noise-Canceling Headphones", 149.99m },
                    { new Guid("f90285c8-4f71-4554-b757-ad8fb8ea6cc4"), "Laptop Stand", 31.75m },
                    { new Guid("f93aa293-8e10-4fb4-8176-a120744268d1"), "Laptop Cooling Pad", 36.80m },
                    { new Guid("ff0901f9-a6ac-4f07-8ff6-c82f258c8ad2"), "USB Microphone", 84.20m }
                });

            migrationBuilder.InsertData(
                table: "ProductReviews",
                columns: new[] { "Id", "ProductId", "Reviewer", "Stars" },
                values: new object[,]
                {
                    { new Guid("0c9a381e-c1f4-4854-a49c-03d70c7fd8d2"), new Guid("0f6f8d1e-0fd6-4622-8d85-66f3e95b0e21"), "Riya", 4 },
                    { new Guid("14926b53-52aa-41f8-89d1-43f2f116653f"), new Guid("15f2365e-45cd-48d0-a706-a1b0c6dbf831"), "Priya", 5 },
                    { new Guid("1c6785fc-6408-4a23-a1ef-2f6403ac6f89"), new Guid("0a5af839-5b7d-4e95-9418-0f26062734d3"), "Hana", 5 },
                    { new Guid("208d0f06-e713-44fd-bf97-8570eecbf513"), new Guid("ff0901f9-a6ac-4f07-8ff6-c82f258c8ad2"), "Nina", 5 },
                    { new Guid("29e93c35-e424-4520-a4cf-c2c5f688fef7"), new Guid("ce6e0a8e-fad0-4f17-9c4a-908f4f4c8b95"), "Ethan", 5 },
                    { new Guid("2f9d2bdf-a412-4f8a-a6d2-c2f823e8dbd8"), new Guid("5ea94313-b5ec-44ed-b259-f41ba84f6c5d"), "Anika", 5 },
                    { new Guid("3a7f72c8-a258-4aa9-aa31-df4d508fef74"), new Guid("0f6f8d1e-0fd6-4622-8d85-66f3e95b0e21"), "Lucas", 5 },
                    { new Guid("3ac79f42-6b44-4f96-bf96-0d09008ad68d"), new Guid("65f52a7a-5ed5-4e70-a3f1-94327453d6c8"), "Liam", 5 },
                    { new Guid("486c43cb-43f5-43f8-87f5-15898f45395d"), new Guid("70ef8a9a-3e8d-4d6b-94ba-7f83d710c3a2"), "Sara", 5 },
                    { new Guid("50d5082a-a6af-4dcb-9348-8fe529a9f368"), new Guid("6d35f2f3-e2f6-417e-97e8-3f7a56eb0f3f"), "Ava", 4 },
                    { new Guid("5771692c-e0f1-4288-b53e-2a81054eecbf"), new Guid("70ef8a9a-3e8d-4d6b-94ba-7f83d710c3a2"), "Ben", 4 },
                    { new Guid("66ec7be0-29c4-4f5b-af94-8f7b19d99eb8"), new Guid("5ea94313-b5ec-44ed-b259-f41ba84f6c5d"), "Eli", 4 },
                    { new Guid("6c3ca0b9-5406-4d4f-80f1-f229eb3f66f7"), new Guid("0a5af839-5b7d-4e95-9418-0f26062734d3"), "Aiden", 4 },
                    { new Guid("72659f6a-d102-4d56-8f94-8512497fdb09"), new Guid("4b9e4458-72f9-47d9-9f17-5c65b9fbe11e"), "Kai", 4 },
                    { new Guid("73f26e04-0611-4f30-b435-4afe367c7d4d"), new Guid("ce6e0a8e-fad0-4f17-9c4a-908f4f4c8b95"), "Zara", 4 },
                    { new Guid("7601f043-ddf1-4cf1-b5f7-1e3f8dbb6560"), new Guid("f93aa293-8e10-4fb4-8176-a120744268d1"), "Victor", 5 },
                    { new Guid("7f299e6f-a191-4934-99e8-4aa5fd8625d9"), new Guid("f93aa293-8e10-4fb4-8176-a120744268d1"), "Iris", 4 },
                    { new Guid("7f5f9e5f-d0f3-4d3f-a62f-4d0f9d9601fa"), new Guid("65f52a7a-5ed5-4e70-a3f1-94327453d6c8"), "Nora", 4 },
                    { new Guid("877b7c54-9f48-4e36-8c84-64a36f25c9e3"), new Guid("f90285c8-4f71-4554-b757-ad8fb8ea6cc4"), "Omar", 5 },
                    { new Guid("89a2a08e-53a2-4733-a217-d60eb1f5f315"), new Guid("31b7c4d1-cb4e-4f61-8fcb-b5e2fc3a6942"), "Mateo", 5 },
                    { new Guid("8f71ec97-2de9-4d2f-8077-7c3985daef3f"), new Guid("31b7c4d1-cb4e-4f61-8fcb-b5e2fc3a6942"), "Sofia", 4 },
                    { new Guid("9af56d64-244f-4a6e-9ec0-c3e6f51e63ce"), new Guid("4b9e4458-72f9-47d9-9f17-5c65b9fbe11e"), "Ivy", 5 },
                    { new Guid("a048f2c2-442e-486c-a389-17fbde03477a"), new Guid("0ee80519-7c87-4f1b-bf38-15c1a7aa4bb9"), "Emma", 5 },
                    { new Guid("bcfcf25f-6648-4fa8-86fc-5e66fa7208f8"), new Guid("f90285c8-4f71-4554-b757-ad8fb8ea6cc4"), "Mila", 4 },
                    { new Guid("c5ea5597-90f0-4208-b654-f2cadfc0e801"), new Guid("a7d5f08e-3d68-4ef8-8fb4-f0ca1a53ed01"), "Arun", 5 },
                    { new Guid("ce2ed848-a6a2-4898-a6ea-15e6740f1a99"), new Guid("15f2365e-45cd-48d0-a706-a1b0c6dbf831"), "Jonah", 4 },
                    { new Guid("db8f2de4-2ea8-4fef-835b-a63ebce91a90"), new Guid("0ee80519-7c87-4f1b-bf38-15c1a7aa4bb9"), "Leo", 4 },
                    { new Guid("df8ab4fc-b59e-430b-91d5-5a54af7af66f"), new Guid("a7d5f08e-3d68-4ef8-8fb4-f0ca1a53ed01"), "Maya", 4 },
                    { new Guid("ed2ad6e4-81ea-4f77-a2a5-fcc9cb4ef7bf"), new Guid("ff0901f9-a6ac-4f07-8ff6-c82f258c8ad2"), "Sam", 4 },
                    { new Guid("fd248541-7cf8-4a0f-ad2e-d0617f2e9150"), new Guid("6d35f2f3-e2f6-417e-97e8-3f7a56eb0f3f"), "Noah", 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductReviews_ProductId",
                table: "ProductReviews",
                column: "ProductId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductReviews");

            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
