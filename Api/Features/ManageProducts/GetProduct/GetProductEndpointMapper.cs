using Api.Entities;

namespace Api.Features.ManageProducts.GetProduct;

public class GetProductEndpointMapper: Mapper<GetProductEndpointRequest, GetProductEndpointResponse, Product>
{
    public override GetProductEndpointResponse FromEntity(Product e) => new()
    {
        Id = e.Id,
        Content = e.Content,
        Tags = e.Tags.Select(tag => new GetProductTagEndpointResponse()
        {
            Id = tag.Id,
            Content = tag.Content
        })
    };
}