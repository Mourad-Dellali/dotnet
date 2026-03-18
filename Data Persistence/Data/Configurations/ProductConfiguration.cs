using ControllerResfulAPI.models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SQLitePCL;


namespace DataPersistence.Configurations;

public partial class ProductConfiguration: IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.HasKey(p => p.Id);

        builder.ToTable("Products");

        builder.Property(p=>p.Name).IsRequired().HasMaxLength(100);

        builder.Property(s=>s.Price).IsRequired().HasColumnType("deciaml(18,2)");

        builder.HasMany(p=>p.ProductReviews).WithOne().HasForeignKey(pr=>pr.ProductId).OnDelete(DeleteBehavior.Cascade);

        builder.HasData(
            [
                new Product
                {
                    Id = Guid.Parse("a7d5f08e-3d68-4ef8-8fb4-f0ca1a53ed01"),
                    Name = "Wireless Mouse",
                    Price = 24.99m
                },
                new Product
                {
                    Id = Guid.Parse("65f52a7a-5ed5-4e70-a3f1-94327453d6c8"),
                    Name = "Mechanical Keyboard",
                    Price = 79.50m
                },
                new Product
                {
                    Id = Guid.Parse("6d35f2f3-e2f6-417e-97e8-3f7a56eb0f3f"),
                    Name = "USB-C Hub",
                    Price = 39.00m
                },
                new Product
                {
                    Id = Guid.Parse("ce6e0a8e-fad0-4f17-9c4a-908f4f4c8b95"),
                    Name = "Noise-Canceling Headphones",
                    Price = 149.99m
                },
                new Product
                {
                    Id = Guid.Parse("4b9e4458-72f9-47d9-9f17-5c65b9fbe11e"),
                    Name = "4K Monitor",
                    Price = 289.00m
                },
                new Product
                {
                    Id = Guid.Parse("f90285c8-4f71-4554-b757-ad8fb8ea6cc4"),
                    Name = "Laptop Stand",
                    Price = 31.75m
                },
                new Product
                {
                    Id = Guid.Parse("0f6f8d1e-0fd6-4622-8d85-66f3e95b0e21"),
                    Name = "Webcam 1080p",
                    Price = 59.99m
                },
                new Product
                {
                    Id = Guid.Parse("5ea94313-b5ec-44ed-b259-f41ba84f6c5d"),
                    Name = "External SSD 1TB",
                    Price = 109.00m
                },
                new Product
                {
                    Id = Guid.Parse("31b7c4d1-cb4e-4f61-8fcb-b5e2fc3a6942"),
                    Name = "Ergonomic Chair Cushion",
                    Price = 44.50m
                },
                new Product
                {
                    Id = Guid.Parse("15f2365e-45cd-48d0-a706-a1b0c6dbf831"),
                    Name = "Portable Bluetooth Speaker",
                    Price = 68.25m
                },
                new Product
                {
                    Id = Guid.Parse("0a5af839-5b7d-4e95-9418-0f26062734d3"),
                    Name = "Smart LED Desk Lamp",
                    Price = 42.99m
                },
                new Product
                {
                    Id = Guid.Parse("0ee80519-7c87-4f1b-bf38-15c1a7aa4bb9"),
                    Name = "Wireless Charging Pad",
                    Price = 27.49m
                },
                new Product
                {
                    Id = Guid.Parse("70ef8a9a-3e8d-4d6b-94ba-7f83d710c3a2"),
                    Name = "Gaming Mouse Pad",
                    Price = 19.95m
                },
                new Product
                {
                    Id = Guid.Parse("f93aa293-8e10-4fb4-8176-a120744268d1"),
                    Name = "Laptop Cooling Pad",
                    Price = 36.80m
                },
                new Product
                {
                    Id = Guid.Parse("ff0901f9-a6ac-4f07-8ff6-c82f258c8ad2"),
                    Name = "USB Microphone",
                    Price = 84.20m
                }
            ]
        );


    }
}