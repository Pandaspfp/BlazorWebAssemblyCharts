using HorizonLab.DataLayer.Context;
using HorizonLab.DataLayer.Interfaces;
using HorizonLab.DataLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace HorizonLab.DataLayer.Data
{
    public class SqlMeasurementTemperature : IMeasurementTemperature
    {
        private readonly greenhouse_dbContext _context;

        public SqlMeasurementTemperature(greenhouse_dbContext context)
        {
            _context = context;
        }

        public async Task<List<MeasurementTemperature>> GetMeasurementTemperatures()
        {
            return await _context.MeasurementTemperatures.OrderBy(x => x.Id).Where(x => x.FkGreenhousesId == 1 && x.CreatedAt > DateTime.Today).ToListAsync();
        }

        public async Task<List<MeasurementTemperature>> GetMeasurementTemperaturesClientTwo()
        {
            return await _context.MeasurementTemperatures.OrderBy(x => x.Id).Where(x => x.FkGreenhousesId == 2 && x.CreatedAt > DateTime.Today).ToListAsync();
        }
    }
}
