using Api.Entities;

namespace Api.Repositories;

public interface IDeviceRepository
{
    Task<List<Device>> GetDevicesAsync();
    Task<Device?> GetDeviceByIdAsync(Guid deviceId);
    Task<bool> CreateDeviceAsync(Device device);
    Task<bool> UpdateDeviceAsync(Device device);
    Task<bool> DeleteDeviceAsync(Guid deviceId);
}