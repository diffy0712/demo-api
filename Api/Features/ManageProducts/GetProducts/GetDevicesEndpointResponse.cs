using Api.Features.ManageProducts.GetProduct;

namespace Api.Features.ManageProducts.GetProducts;

public class GetDevicesEndpointResponse
{
    public List<GetDeviceEndpointResponse> devices { get; set; }
}