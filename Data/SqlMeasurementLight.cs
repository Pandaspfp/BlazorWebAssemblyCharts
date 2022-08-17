using HorizonLab.DataLayer.Context;
using HorizonLab.DataLayer.Interfaces;
using HorizonLab.DataLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace HorizonLab.DataLayer.Data
{
    public class SqlMeasurementLight : IMeasurementLight
    {
        private readonly greenhouse_dbContext _context;

        public SqlMeasurementLight(greenhouse_dbContext context)
        {
            _context = context;
        }

        public async Task<MeasurementLight> GetMeasurementLight(int id)
        {
            return await _context.MeasurementLights.Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<List<MeasurementLight>> GetMeasurementLights()
        {
            return await _context.MeasurementLights.OrderBy(x => x.Id).ToListAsync();
        }
    }
}
