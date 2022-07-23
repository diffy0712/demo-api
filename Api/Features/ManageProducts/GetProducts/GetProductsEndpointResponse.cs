using Api.Features.ManageProducts.GetProduct;

namespace Api.Features.ManageProducts.GetProducts;

public class GetProductsEndpointResponse
{
    public IEnumerable<GetProductEndpointResponse> products { get; set; }
}