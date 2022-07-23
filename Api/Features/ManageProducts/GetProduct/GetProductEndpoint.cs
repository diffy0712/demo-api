using Api.Repositories;

namespace Api.Features.ManageProducts.GetProduct;

public class GetProductEndpoint: Endpoint<GetProductEndpointRequest, GetProductEndpointResponse, GetProductEndpointMapper>
{
    private readonly IProductRepository _productRepository;

    public GetProductEndpoint(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }
    
    public override void Configure()
    {
        AllowAnonymous();
        Get("/products/{Id}");
        Description(b => b
            .Produces<GetProductEndpointResponse>(200, "application/json")
            .Produces<ErrorResponse>(400, "application/json+problem"));
        Summary(s => {
            s.Summary = "Get a product by id";
        }); 
    }
    
    public override async Task HandleAsync(GetProductEndpointRequest r, CancellationToken c)
    {
        if (r.Id is null)
        {
            await SendNotFoundAsync(c);
            return;
        }
        
        var product = await _productRepository.GetProductByIdAsync(Guid.Parse(r.Id));

        if (product is null)
        {
            await SendNotFoundAsync(c);
            return;
        }

        var response = Map.FromEntity(product);

        await SendAsync(response, 200, c);
    }
}