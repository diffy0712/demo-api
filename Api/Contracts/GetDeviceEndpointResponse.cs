namespace Api.Contracts;

public class GetDeviceEndpointResponse
{
    public Guid Id { get; set; }
    
    public string Content { get; set; }

    public List<GetDeviceTagEndpointResponse> Tags { get; set; } = new();
}

public class GetDeviceTagEndpointResponse
{
    public Guid id { get; set; }
    public string Content { get; set; }
}