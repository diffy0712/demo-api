using Api.Features.ManageProducts.GetProduct;
using Api.Repositories;

namespace Api.Features.ManageProducts.GetProducts;

public class GetProductsEndpoint: Endpoint<EmptyRequest, GetProductsEndpointResponse, GetProductsEndpointMapper>
{
    private readonly IProductRepository _productRepository;

    public GetProductsEndpoint(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }
    
    public override void Configure()
    {
        AllowAnonymous();
        Get("/products");
        Description(b => b
            .Produces<GetProductsEndpointResponse>(200, "application/json")
            .Produces<ErrorResponse>(400, "application/json+problem"));
        Summary(s => {
            s.Summary = "Get all products";
        }); 
    }
    
    public override async Task HandleAsync(EmptyRequest r, CancellationToken c)
    {
        var products = await _productRepository.GetProductsAsync();
        var response = Map.FromEntity(products);

        await SendAsync(response, 200, c);
    }
}