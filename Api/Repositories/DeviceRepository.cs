using Api.Data;
using Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace Api.Repositories;

public class DeviceRepository : IDeviceRepository
{
    private DataContext _dataContext { get; set; }

    public DeviceRepository(DataContext dataContext)
    {
        this._dataContext = dataContext;
    }

    public async Task<List<Device>> GetDevicesAsync()
    {
        return await _dataContext.Devices.Include(device => device.Tags).ToListAsync();
    }

    public async Task<Device?> GetDeviceByIdAsync(Guid deviceId)
    {
        return await _dataContext.Devices.Include(note => note.Tags).SingleOrDefaultAsync(x => x.Id == deviceId);
    }
    
    public async Task<bool> CreateDeviceAsync(Device device)
    {
        await _dataContext.Devices.AddAsync(device);
        var created = await _dataContext.SaveChangesAsync();
        return created > 0;
    }

    public async Task<bool> UpdateDeviceAsync(Device device)
    {
        _dataContext.Devices.Update(device);
        var updated = await _dataContext.SaveChangesAsync();
        return updated > 0;
    }

    public async Task<bool> DeleteDeviceAsync(Guid deviceId)
    {
        var device = await GetDeviceByIdAsync(deviceId);
        if (device is null)
        {
            return false;
        }
        
        _dataContext.Devices.Remove(device);
        var deleted = await _dataContext.SaveChangesAsync();
        return deleted > 0;
    }
}