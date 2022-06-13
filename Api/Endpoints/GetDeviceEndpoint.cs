using Api.Contracts;
using Api.Repositories;

namespace Api.Endpoints;

public class GetDeviceEndpoint: Endpoint<GetDeviceEndpointRequest, GetDeviceEndpointResponse>
{
    private readonly IDeviceRepository _deviceRepository;

    public GetDeviceEndpoint(IDeviceRepository deviceRepository)
    {
        _deviceRepository = deviceRepository;
    }
    
    public override void Configure()
    {
        AllowAnonymous();
        Get("/devices/{Id}");
        Description(b => b
            .Produces<GetDeviceEndpointResponse>(200, "application/json")
            .Produces<ErrorResponse>(400, "application/json+problem"));
        Summary(s => {
            s.Summary = "Get a device by id";
        }); 
    }
    
    public override async Task HandleAsync(GetDeviceEndpointRequest r, CancellationToken c)
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

        var response = new GetDeviceEndpointResponse()
        {
            Id = device.Id,
            Content = device.Content
        };
        device.Tags.ForEach(tag =>
        {
            response.Tags.Add(new GetDeviceTagEndpointResponse()
            {
                id = tag.Id,
                Content = tag.Content
            });
        });

        await SendAsync(response, 200, c);
    }
}