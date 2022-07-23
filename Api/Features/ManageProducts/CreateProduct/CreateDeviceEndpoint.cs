using Api.Entities;
using Api.Repositories;

namespace Api.Features.ManageProducts.CreateProduct;

public class CreateDeviceEndpoint : Endpoint<CreateDeviceEndpointRequest>
{
    private readonly IDeviceRepository _deviceRepository;

    public CreateDeviceEndpoint(IDeviceRepository deviceRepository)
    {
        _deviceRepository = deviceRepository;
    }
    
    public override void Configure()
    {
        AllowAnonymous();
        Post("/devices");
        Description(b => b
            .Produces<EmptyResponse>(201, "application/json")
            .Produces<ErrorResponse>(400, "application/json+problem"));
        Summary(s => {
            s.Summary = "Create a new device";
        }); 
    }
    
    public override async Task HandleAsync(CreateDeviceEndpointRequest r, CancellationToken c)
    {
        var device = new Device()
        {
            Id = new Guid(r.Id),
            Content = r.Content
        };
        
        await _deviceRepository.CreateDeviceAsync(device);
        
        await SendAsync(new EmptyResponse(), 201, c);
    }
}