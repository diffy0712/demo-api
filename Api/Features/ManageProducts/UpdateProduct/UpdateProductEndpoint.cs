using Api.Entities;
using Api.Repositories;

namespace Api.Features.ManageProducts.UpdateProduct;

public class UpdateProductEndpoint : Endpoint<UpdateProductEndpointRequest>
{
    private readonly IProductRepository _productRepository;

    public UpdateProductEndpoint(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }
    
    public override void Configure()
    {
        AllowAnonymous();
        Put("/products/{Id}");
        Description(b => b
            .Produces<EmptyResponse>(201, "application/json")
            .Produces<ErrorResponse>(400, "application/json+problem"));
        Summary(s => {
            s.Summary = "Update products by id";
        }); 
    }
    
    public override async Task HandleAsync(UpdateProductEndpointRequest r, CancellationToken c)
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

        product.Content = r.Content;

        await _productRepository.UpdateProductAsync(product);
        
        await SendAsync(new EmptyResponse(), 200, c);
    }
}