using Api.Repositories;

namespace Api.Features.ManageProducts.DeleteProduct;

public class DeleteProductEndpoint: Endpoint<DeleteProductEndpointRequest, EmptyResponse>
{
    private readonly IProductRepository _productRepository;

    public DeleteProductEndpoint(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }
    
    public override void Configure()
    {
        AllowAnonymous();
        DontAutoTag();
        Delete("/products/{Id}");
        Description(b => b
            .WithTags("Manage Products")
            .Produces<EmptyResponse>(200, "application/json")
            .Produces<ErrorResponse>(400, "application/json+problem"));
        Summary(s => {
            s.Summary = "Delete a products by id";
        }); 
    }
    
    public override async Task HandleAsync(DeleteProductEndpointRequest r, CancellationToken c)
    {
        if (r.Id is null)
        {
            await SendNotFoundAsync(c);
            return;
        }
        
        await _productRepository.DeleteProductAsync(Guid.Parse(r.Id));

        await SendAsync(new EmptyResponse(), 200, c);
    }
}