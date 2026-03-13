using ControllerResfulAPI.models;

namespace ControllerResfulAPI.Responses;

public class ProductResponse
{
    public Guid Id {get;set;}
    public string? Name {get;set;}
    public decimal Price {get;set;}
    public List<ProductReviewResponse>? Reviews {get;set;} = default;

    private ProductResponse() {}

    public static ProductResponse FromModel(Product? product, IEnumerable<ProductReview>? reviews=null)
    {
        if (product==null) 
        throw new ArgumentNullException(nameof(product),"null product");
        var response= new ProductResponse
        {
            Id=product.Id,
            Name=product.Name,
            Price=product.Price,

        };
        if (reviews != null)
        response.Reviews = ProductReviewResponse.FromModels(reviews).ToList();
        return response;
    }
    public static IEnumerable<ProductResponse> FromModels(IEnumerable<Product>? products)
    {
        if (products==null)
        throw new ArgumentNullException(nameof(products),"null list of products");
        return products.Select(p=>FromModel(p));
    }
}