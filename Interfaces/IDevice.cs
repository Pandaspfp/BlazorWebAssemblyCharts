using HorizonLab.DataLayer.Models;

namespace HorizonLab.DataLayer.Interfaces
{
    public interface IDevice
    {
        Task<Device>GetDevice(int id);
        Task<List<Device>> GetDevices();
    }
}
