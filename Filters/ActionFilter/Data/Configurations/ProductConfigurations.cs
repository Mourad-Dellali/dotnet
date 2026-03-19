using System.Data.Common;
using ActionFilter.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SQLitePCL;


namespace ActionFilter.Data.Configurations;


public class ProductConfigurations : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.HasKey(p => p.Id);
        builder.ToTable("Products");
        builder.Property(p => p.Name).HasMaxLength(100);
        builder.Property(p => p.Price).HasColumnType("decimal(18,2)");


        builder.HasData(
            [
            new Product
            {
                Id = Guid.Parse("a7d5f08e-3d68-4ef8-8fb4-f0ca1a53ed01"),
                Name = "Wireless Mouse",
                Price = 24.99m
            },
            new Product {
                Id = Guid.Parse("65f52a7a-5ed5-4e70-a3f1-94327453d6c8"),
                Name = "Mechanical Keyboard",
                Price = 79.50m
            },
            new Product {
                Id = Guid.Parse("6d35f2f3-e2f6-417e-97e8-3f7a56eb0f3f"),
                Name = "USB-C Hub",
                Price = 39.00m
            },
                new Product {
                    Id = Guid.Parse("ce6e0a8e-fad0-4f17-9c4a-908f4f4c8b95"),
                    Name = "Noise-Canceling Headphones",
                    Price = 149.99m
                },
                new Product {
                    Id = Guid.Parse("4b9e4458-72f9-47d9-9f17-5c65b9fbe11e"),
                    Name = "4K Monitor",
                    Price = 289.00m
                },
                new Product {
                    Id = Guid.Parse("f90285c8-4f71-4554-b757-ad8fb8ea6cc4"),
                    Name = "Laptop Stand",
                    Price = 31.75m
                },
                new Product {
                    Id = Guid.Parse("d1e5f2a3-8c6b-4e7a-9f8e-2a3b4c5d6e7f"),
                    Name = "External SSD",
                    Price = 99.99m
                },
                new Product {
                    Id = Guid.Parse("e2f6a7b8-9c1d-4f3e-8a7b-5c6d7e8f9a0b"),
                    Name = "Gaming Chair",
                    Price = 199.00m
                },
            ]
        );
    }
}