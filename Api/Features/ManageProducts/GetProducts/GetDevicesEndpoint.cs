using Api.Features.ManageProducts.GetProduct;
using Api.Repositories;

namespace Api.Features.ManageProducts.GetProducts;

public class GetDevicesEndpoint: Endpoint<EmptyRequest, GetDevicesEndpointResponse>
{
    private readonly IDeviceRepository _deviceRepository;

    public GetDevicesEndpoint(IDeviceRepository deviceRepository)
    {
        _deviceRepository = deviceRepository;
    }
    
    public override void Configure()
    {
        AllowAnonymous();
        Get("/devices");
        Description(b => b
            .Produces<GetDevicesEndpointResponse>(200, "application/json")
            .Produces<ErrorResponse>(400, "application/json+problem"));
        Summary(s => {
            s.Summary = "Get all devices";
        }); 
    }
    
    public override async Task HandleAsync(EmptyRequest r, CancellationToken c)
    {
        var notes = await _deviceRepository.GetDevicesAsync();
        var response = new GetDevicesEndpointResponse()
        {
            devices = new List<GetDeviceEndpointResponse>()
        };

        notes.ForEach(device =>
        {
            var dto = new GetDeviceEndpointResponse()
            {
                Id = device.Id,
                Content = device.Content
            };
            response.devices.Add(dto);
            device.Tags.ForEach(tag =>
            {
                dto.Tags.Add(new GetDeviceTagEndpointResponse()
                {
                    id = tag.Id,
                    Content = tag.Content
                });
            });
        });
        
        await SendAsync(response, 200, c);
    }
}