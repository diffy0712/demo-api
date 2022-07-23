using Api.Repositories;

namespace Api.Features.ManageProducts.DeleteProduct;

public class DeleteDeviceEndpoint: Endpoint<DeleteDeviceEndpointRequest, EmptyResponse>
{
    private readonly IDeviceRepository _deviceRepository;

    public DeleteDeviceEndpoint(IDeviceRepository deviceRepository)
    {
        _deviceRepository = deviceRepository;
    }
    
    public override void Configure()
    {
        AllowAnonymous();
        Delete("/devices/{Id}");
        Description(b => b
            .Produces<EmptyResponse>(200, "application/json")
            .Produces<ErrorResponse>(400, "application/json+problem"));
        Summary(s => {
            s.Summary = "Delete a device by id";
        }); 
    }
    
    public override async Task HandleAsync(DeleteDeviceEndpointRequest r, CancellationToken c)
    {
        if (r.Id is null)
        {
            await SendNotFoundAsync(c);
            return;
        }
        
        await _deviceRepository.DeleteDeviceAsync(Guid.Parse(r.Id));

        await SendAsync(new EmptyResponse(), 200, c);
    }
}