using Api.Entities;
using Api.Repositories;

namespace Api.Features.ManageProducts.CreateProduct;

public class CreateProductEndpoint : Endpoint<CreateProductEndpointRequest>
{
    private readonly IProductRepository _productRepository;

    public CreateProductEndpoint(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }
    
    public override void Configure()
    {
        AllowAnonymous();
        Post("/products");
        Description(b => b
            .Produces<EmptyResponse>(201, "application/json")
            .Produces<ErrorResponse>(400, "application/json+problem"));
        Summary(s => {
            s.Summary = "Create a new product";
        }); 
    }
    
    public override async Task HandleAsync(CreateProductEndpointRequest r, CancellationToken c)
    {
        var product = new Product()
        {
            Id = new Guid(r.Id),
            Content = r.Content
        };
        
        await _productRepository.CreateProductAsync(product);
        
        await SendAsync(new EmptyResponse(), 201, c);
    }
}