using ControllerResfulAPI.models;
using Microsoft.Win32;

namespace ControllerResfulAPI.Data;

public class ProductRepository
{
	private readonly List<ControllerResfulAPI.models.Product> _products =
	[
		new()
		{
			Id = Guid.Parse("a7d5f08e-3d68-4ef8-8fb4-f0ca1a53ed01"),
			Name = "Wireless Mouse",
			Price = 24.99m
		},
		new()
		{
			Id = Guid.Parse("65f52a7a-5ed5-4e70-a3f1-94327453d6c8"),
			Name = "Mechanical Keyboard",
			Price = 79.50m
		},
		new()
		{
			Id = Guid.Parse("6d35f2f3-e2f6-417e-97e8-3f7a56eb0f3f"),
			Name = "USB-C Hub",
			Price = 39.00m
		},
		new()
		{
			Id = Guid.Parse("ce6e0a8e-fad0-4f17-9c4a-908f4f4c8b95"),
			Name = "Noise-Canceling Headphones",
			Price = 149.99m
		},
		new()
		{
			Id = Guid.Parse("4b9e4458-72f9-47d9-9f17-5c65b9fbe11e"),
			Name = "4K Monitor",
			Price = 289.00m
		},
		new()
		{
			Id = Guid.Parse("f90285c8-4f71-4554-b757-ad8fb8ea6cc4"),
			Name = "Laptop Stand",
			Price = 31.75m
		},
		new()
		{
			Id = Guid.Parse("0f6f8d1e-0fd6-4622-8d85-66f3e95b0e21"),
			Name = "Webcam 1080p",
			Price = 59.99m
		},
		new()
		{
			Id = Guid.Parse("5ea94313-b5ec-44ed-b259-f41ba84f6c5d"),
			Name = "External SSD 1TB",
			Price = 109.00m
		},
		new()
		{
			Id = Guid.Parse("31b7c4d1-cb4e-4f61-8fcb-b5e2fc3a6942"),
			Name = "Ergonomic Chair Cushion",
			Price = 44.50m
		},
		new()
		{
			Id = Guid.Parse("15f2365e-45cd-48d0-a706-a1b0c6dbf831"),
			Name = "Portable Bluetooth Speaker",
			Price = 68.25m
		},
		new()
		{
			Id = Guid.Parse("0a5af839-5b7d-4e95-9418-0f26062734d3"),
			Name = "Smart LED Desk Lamp",
			Price = 42.99m
		},
		new()
		{
			Id = Guid.Parse("0ee80519-7c87-4f1b-bf38-15c1a7aa4bb9"),
			Name = "Wireless Charging Pad",
			Price = 27.49m
		},
		new()
		{
			Id = Guid.Parse("70ef8a9a-3e8d-4d6b-94ba-7f83d710c3a2"),
			Name = "Gaming Mouse Pad",
			Price = 19.95m
		},
		new()
		{
			Id = Guid.Parse("f93aa293-8e10-4fb4-8176-a120744268d1"),
			Name = "Laptop Cooling Pad",
			Price = 36.80m
		},
		new()
		{
			Id = Guid.Parse("ff0901f9-a6ac-4f07-8ff6-c82f258c8ad2"),
			Name = "USB Microphone",
			Price = 84.20m
		}
	];

	private readonly List<ControllerResfulAPI.models.ProductReview> _productReviews =
	[
		new()
		{
			Id = Guid.Parse("c5ea5597-90f0-4208-b654-f2cadfc0e801"),
			ProductId = Guid.Parse("a7d5f08e-3d68-4ef8-8fb4-f0ca1a53ed01"),
			Reviewer = "Arun",
			Stars = 5
		},
		new()
		{
			Id = Guid.Parse("df8ab4fc-b59e-430b-91d5-5a54af7af66f"),
			ProductId = Guid.Parse("a7d5f08e-3d68-4ef8-8fb4-f0ca1a53ed01"),
			Reviewer = "Maya",
			Stars = 4
		},
		new()
		{
			Id = Guid.Parse("3ac79f42-6b44-4f96-bf96-0d09008ad68d"),
			ProductId = Guid.Parse("65f52a7a-5ed5-4e70-a3f1-94327453d6c8"),
			Reviewer = "Liam",
			Stars = 5
		},
		new()
		{
			Id = Guid.Parse("7f5f9e5f-d0f3-4d3f-a62f-4d0f9d9601fa"),
			ProductId = Guid.Parse("65f52a7a-5ed5-4e70-a3f1-94327453d6c8"),
			Reviewer = "Nora",
			Stars = 4
		},
		new()
		{
			Id = Guid.Parse("50d5082a-a6af-4dcb-9348-8fe529a9f368"),
			ProductId = Guid.Parse("6d35f2f3-e2f6-417e-97e8-3f7a56eb0f3f"),
			Reviewer = "Ava",
			Stars = 4
		},
		new()
		{
			Id = Guid.Parse("fd248541-7cf8-4a0f-ad2e-d0617f2e9150"),
			ProductId = Guid.Parse("6d35f2f3-e2f6-417e-97e8-3f7a56eb0f3f"),
			Reviewer = "Noah",
			Stars = 3
		},
		new()
		{
			Id = Guid.Parse("29e93c35-e424-4520-a4cf-c2c5f688fef7"),
			ProductId = Guid.Parse("ce6e0a8e-fad0-4f17-9c4a-908f4f4c8b95"),
			Reviewer = "Ethan",
			Stars = 5
		},
		new()
		{
			Id = Guid.Parse("73f26e04-0611-4f30-b435-4afe367c7d4d"),
			ProductId = Guid.Parse("ce6e0a8e-fad0-4f17-9c4a-908f4f4c8b95"),
			Reviewer = "Zara",
			Stars = 4
		},
		new()
		{
			Id = Guid.Parse("9af56d64-244f-4a6e-9ec0-c3e6f51e63ce"),
			ProductId = Guid.Parse("4b9e4458-72f9-47d9-9f17-5c65b9fbe11e"),
			Reviewer = "Ivy",
			Stars = 5
		},
		new()
		{
			Id = Guid.Parse("72659f6a-d102-4d56-8f94-8512497fdb09"),
			ProductId = Guid.Parse("4b9e4458-72f9-47d9-9f17-5c65b9fbe11e"),
			Reviewer = "Kai",
			Stars = 4
		},
		new()
		{
			Id = Guid.Parse("bcfcf25f-6648-4fa8-86fc-5e66fa7208f8"),
			ProductId = Guid.Parse("f90285c8-4f71-4554-b757-ad8fb8ea6cc4"),
			Reviewer = "Mila",
			Stars = 4
		},
		new()
		{
			Id = Guid.Parse("877b7c54-9f48-4e36-8c84-64a36f25c9e3"),
			ProductId = Guid.Parse("f90285c8-4f71-4554-b757-ad8fb8ea6cc4"),
			Reviewer = "Omar",
			Stars = 5
		},
		new()
		{
			Id = Guid.Parse("0c9a381e-c1f4-4854-a49c-03d70c7fd8d2"),
			ProductId = Guid.Parse("0f6f8d1e-0fd6-4622-8d85-66f3e95b0e21"),
			Reviewer = "Riya",
			Stars = 4
		},
		new()
		{
			Id = Guid.Parse("3a7f72c8-a258-4aa9-aa31-df4d508fef74"),
			ProductId = Guid.Parse("0f6f8d1e-0fd6-4622-8d85-66f3e95b0e21"),
			Reviewer = "Lucas",
			Stars = 5
		},
		new()
		{
			Id = Guid.Parse("2f9d2bdf-a412-4f8a-a6d2-c2f823e8dbd8"),
			ProductId = Guid.Parse("5ea94313-b5ec-44ed-b259-f41ba84f6c5d"),
			Reviewer = "Anika",
			Stars = 5
		},
		new()
		{
			Id = Guid.Parse("66ec7be0-29c4-4f5b-af94-8f7b19d99eb8"),
			ProductId = Guid.Parse("5ea94313-b5ec-44ed-b259-f41ba84f6c5d"),
			Reviewer = "Eli",
			Stars = 4
		},
		new()
		{
			Id = Guid.Parse("8f71ec97-2de9-4d2f-8077-7c3985daef3f"),
			ProductId = Guid.Parse("31b7c4d1-cb4e-4f61-8fcb-b5e2fc3a6942"),
			Reviewer = "Sofia",
			Stars = 4
		},
		new()
		{
			Id = Guid.Parse("89a2a08e-53a2-4733-a217-d60eb1f5f315"),
			ProductId = Guid.Parse("31b7c4d1-cb4e-4f61-8fcb-b5e2fc3a6942"),
			Reviewer = "Mateo",
			Stars = 5
		},
		new()
		{
			Id = Guid.Parse("14926b53-52aa-41f8-89d1-43f2f116653f"),
			ProductId = Guid.Parse("15f2365e-45cd-48d0-a706-a1b0c6dbf831"),
			Reviewer = "Priya",
			Stars = 5
		},
		new()
		{
			Id = Guid.Parse("ce2ed848-a6a2-4898-a6ea-15e6740f1a99"),
			ProductId = Guid.Parse("15f2365e-45cd-48d0-a706-a1b0c6dbf831"),
			Reviewer = "Jonah",
			Stars = 4
		},
		new()
		{
			Id = Guid.Parse("6c3ca0b9-5406-4d4f-80f1-f229eb3f66f7"),
			ProductId = Guid.Parse("0a5af839-5b7d-4e95-9418-0f26062734d3"),
			Reviewer = "Aiden",
			Stars = 4
		},
		new()
		{
			Id = Guid.Parse("1c6785fc-6408-4a23-a1ef-2f6403ac6f89"),
			ProductId = Guid.Parse("0a5af839-5b7d-4e95-9418-0f26062734d3"),
			Reviewer = "Hana",
			Stars = 5
		},
		new()
		{
			Id = Guid.Parse("db8f2de4-2ea8-4fef-835b-a63ebce91a90"),
			ProductId = Guid.Parse("0ee80519-7c87-4f1b-bf38-15c1a7aa4bb9"),
			Reviewer = "Leo",
			Stars = 4
		},
		new()
		{
			Id = Guid.Parse("a048f2c2-442e-486c-a389-17fbde03477a"),
			ProductId = Guid.Parse("0ee80519-7c87-4f1b-bf38-15c1a7aa4bb9"),
			Reviewer = "Emma",
			Stars = 5
		},
		new()
		{
			Id = Guid.Parse("5771692c-e0f1-4288-b53e-2a81054eecbf"),
			ProductId = Guid.Parse("70ef8a9a-3e8d-4d6b-94ba-7f83d710c3a2"),
			Reviewer = "Ben",
			Stars = 4
		},
		new()
		{
			Id = Guid.Parse("486c43cb-43f5-43f8-87f5-15898f45395d"),
			ProductId = Guid.Parse("70ef8a9a-3e8d-4d6b-94ba-7f83d710c3a2"),
			Reviewer = "Sara",
			Stars = 5
		},
		new()
		{
			Id = Guid.Parse("7f299e6f-a191-4934-99e8-4aa5fd8625d9"),
			ProductId = Guid.Parse("f93aa293-8e10-4fb4-8176-a120744268d1"),
			Reviewer = "Iris",
			Stars = 4
		},
		new()
		{
			Id = Guid.Parse("7601f043-ddf1-4cf1-b5f7-1e3f8dbb6560"),
			ProductId = Guid.Parse("f93aa293-8e10-4fb4-8176-a120744268d1"),
			Reviewer = "Victor",
			Stars = 5
		},
		new()
		{
			Id = Guid.Parse("208d0f06-e713-44fd-bf97-8570eecbf513"),
			ProductId = Guid.Parse("ff0901f9-a6ac-4f07-8ff6-c82f258c8ad2"),
			Reviewer = "Nina",
			Stars = 5
		},
		new()
		{
			Id = Guid.Parse("ed2ad6e4-81ea-4f77-a2a5-fcc9cb4ef7bf"),
			ProductId = Guid.Parse("ff0901f9-a6ac-4f07-8ff6-c82f258c8ad2"),
			Reviewer = "Sam",
			Stars = 4
		}
	];

	public int GetProductCount()=> _products.Count();
    public List<Product> GetProductsPage(int page=1, int pageSize=10) {
        var products= _products.Skip((page-1)* pageSize).Take(pageSize).ToList();

        return products;
    }
	

    public Product? GetProductById(Guid productId) {
        var product= _products.FirstOrDefault(p=>p.Id == productId);
        if (product is null) 
            return null;
        return product;
    }

    public List<ProductReview> GetProductReviews(Guid productId) {
        return _productReviews.Where(r=>r.ProductId == productId).ToList();
    }
    public ProductReview? GetReview(Guid productID, Guid reviewId) {
        return _productReviews.FirstOrDefault(r=>r.ProductId == productID && r.Id== reviewId);
    }
    public bool AddProduct(Product product) {
        _products.Add(product);
        return true;
    }
    public bool AddProductReview(ProductReview productReview) {
        if (!_products.Any(p => p.Id == productReview.ProductId)) 
        return false;

        _productReviews.Add(productReview);
        return true;
    }
    public bool UpdateProduct(Product updateProduct) {
        var existingProduct= _products.FirstOrDefault(p=>p.Id== updateProduct.Id);
        if (existingProduct == null)
        return false;
        existingProduct.Name= updateProduct.Name;
        existingProduct.Price=updateProduct.Price;
        return true;
    }
    public bool DeleteProduct(Guid id) {
        var product=_products.FirstOrDefault(p=>p.Id == id);
        if (product == null) 
        return false;

        _products.Remove(product);

        _productReviews.RemoveAll(r=>r.ProductId == id);
        return true;
    }
    public bool ExistsById(Guid id) => _products.Any(p=>p.Id==id);
    public bool ExistsByName(string? name) => _products.Any(p=>string.Equals(p.Name,name,StringComparison.OrdinalIgnoreCase));
}