using Api.Features.ManageProducts.GetProduct;

namespace Api.Features.ManageProducts.GetProducts;

public class GetProductsEndpointResponse
{
    public List<GetProductEndpointResponse> products { get; set; }
}