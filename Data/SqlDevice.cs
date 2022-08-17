using HorizonLab.DataLayer.Context;
using HorizonLab.DataLayer.Interfaces;
using HorizonLab.DataLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace HorizonLab.DataLayer.Data
{
    public class SqlDevice : IDevice
    {
        private readonly greenhouse_dbContext _context;

        public SqlDevice(greenhouse_dbContext context)
        {
            _context = context;
        }

        public async Task<Device> GetDevice(int id)
        {
            return await _context.Devices.Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<List<Device>> GetDevices()
        {
            return await _context.Devices.OrderBy(x => x.Hostname).ToListAsync();
        }
    }
}
