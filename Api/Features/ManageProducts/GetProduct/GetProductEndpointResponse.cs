namespace Api.Features.ManageProducts.GetProduct;

public class GetProductEndpointResponse
{
    public Guid Id { get; set; }
    
    public string Content { get; set; }

    public IEnumerable<GetProductTagEndpointResponse> Tags { get; set; } = new List<GetProductTagEndpointResponse>();
}

public class GetProductTagEndpointResponse
{
    public Guid Id { get; set; }
    public string Content { get; set; }
}