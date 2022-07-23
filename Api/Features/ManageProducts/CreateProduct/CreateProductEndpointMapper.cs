using Api.Entities;

namespace Api.Features.ManageProducts.CreateProduct;

public class CreateProductEndpointMapper: Mapper<CreateProductEndpointRequest, EmptyResponse, Product>
{
    public override Product ToEntity(CreateProductEndpointRequest r) => new()
    {
        Id = Guid.NewGuid(),
        Content = r.Content
    };
}