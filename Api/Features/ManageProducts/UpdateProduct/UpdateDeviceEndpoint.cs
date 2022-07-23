using Api.Entities;
using Api.Repositories;

namespace Api.Features.ManageProducts.UpdateProduct;

public class UpdateDeviceEndpoint : Endpoint<UpdateDeviceEndpointRequest>
{
    private readonly IDeviceRepository _deviceRepository;

    public UpdateDeviceEndpoint(IDeviceRepository deviceRepository)
    {
        _deviceRepository = deviceRepository;
    }
    
    public override void Configure()
    {
        AllowAnonymous();
        Put("/devices/{Id}");
        Description(b => b
            .Produces<EmptyResponse>(201, "application/json")
            .Produces<ErrorResponse>(400, "application/json+problem"));
        Summary(s => {
            s.Summary = "Update product by id";
        }); 
    }
    
    public override async Task HandleAsync(UpdateDeviceEndpointRequest r, CancellationToken c)
    {
        if (r.Id is null)
        {
            await SendNotFoundAsync(c);
            return;
        }
        
        var device = await _deviceRepository.GetDeviceByIdAsync(Guid.Parse(r.Id));

        if (device is null)
        {
            await SendNotFoundAsync(c);
            return;
        }

        device.Content = r.Content;

        await _deviceRepository.UpdateDeviceAsync(device);
        
        await SendAsync(new EmptyResponse(), 200, c);
    }
}