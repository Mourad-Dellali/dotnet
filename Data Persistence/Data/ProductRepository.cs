using ControllerResfulAPI.models;
using DataPersistence.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Win32;

namespace ControllerResfulAPI.Data;

public class ProductRepository(AppDbContext context)
{
	

	public int GetProductCount()=> context.Products.Count();
    public List<Product> GetProductsPage(int page=1, int pageSize=10) {
        var products= context.Products.Skip((page-1)* pageSize).Take(pageSize).ToList();

        return products;
    }
	

    public Product? GetProductById(Guid productId) {
        var product= context.Products.FirstOrDefault(p=>p.Id == productId);
        if (product is null) 
            return null;
        return product;
    }

    public List<ProductReview> GetProductReviews(Guid productId) {
        return context.ProductReviews.Where(r=>r.ProductId == productId).ToList();
    }
    public ProductReview? GetReview(Guid productID, Guid reviewId) {
        return context.ProductReviews.FirstOrDefault(r=>r.ProductId == productID && r.Id== reviewId);
    }
    public bool AddProduct(Product product) {
        context.Products.Add(product);

		context.SaveChanges();
        return true;
    }
    public bool AddProductReview(ProductReview productReview) {
        if (!context.Products.Any(p => p.Id == productReview.ProductId)) 
        return false;

        context.ProductReviews.Add(productReview);
		context.SaveChanges();
        return true;
    }
    public bool UpdateProduct(Product updateProduct) {
        var existingProduct= context.Products.FirstOrDefault(p=>p.Id== updateProduct.Id);
        if (existingProduct == null)
        return false;
        existingProduct.Name= updateProduct.Name;
        existingProduct.Price=updateProduct.Price;
		context.SaveChanges();
        return true;
    }
    public bool DeleteProduct(Guid id) {
        var product=context.Products.FirstOrDefault(p=>p.Id == id);
        if (product == null) 
        return false;

        context.Products.Remove(product);

		context.SaveChanges();
        return true;
    }
    public bool ExistsById(Guid id) => context.Products.Any(p=>p.Id==id);
    public bool ExistsByName(string? name)
	{
		if (string.IsNullOrWhiteSpace(name))
		return false;

		return context.Products.Any(p=>EF.Functions.Like(p.Name!.ToUpper(),name.ToUpper()));
	}
}