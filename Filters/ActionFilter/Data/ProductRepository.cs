namespace ActionFilter.Data.ProductRepository;
using ActionFilter.Data.AppDb;
using ActionFilter.Models;
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
    public List<Product> GetProductByName(string? productName)
    {
        var products = context.Products.Where(p => p.Name.Contains(productName)).ToList();
        return products;
    }
    public bool AddProduct(Product product) {
        context.Products.Add(product); 
        return context.SaveChanges() > 0;
    }
}