namespace Api.Features.ManageProducts.GetProduct;

public class GetProductEndpointResponse
{
    public Guid Id { get; set; }
    
    public string Content { get; set; }

    public List<GetProductTagEndpointResponse> Tags { get; set; } = new();
}

public class GetProductTagEndpointResponse
{
    public Guid id { get; set; }
    public string Content { get; set; }
}