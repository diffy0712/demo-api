using Api.Entities;
using Api.Features.ManageProducts.GetProduct;

namespace Api.Features.ManageProducts.GetProducts;

public class GetProductsEndpointMapper: Mapper<EmptyRequest, GetProductsEndpointResponse, IEnumerable<Product>>
{
    public override GetProductsEndpointResponse FromEntity(IEnumerable<Product> e) => new()
    {
        products = e.Select(product => new GetProductEndpointResponse()
        {
            Id = product.Id,
            Content = product.Content,
            Tags = product.Tags.Select(tag => new GetProductTagEndpointResponse()
            {
                Id = tag.Id,
                Content = tag.Content
            })
        })
    };
}