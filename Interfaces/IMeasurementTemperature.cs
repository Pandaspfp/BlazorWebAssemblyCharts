using HorizonLab.DataLayer.Models;

namespace HorizonLab.DataLayer.Interfaces
{
    public interface IMeasurementTemperature
    {
        Task<List<MeasurementTemperature>> GetMeasurementTemperatures();
        Task<List<MeasurementTemperature>> GetMeasurementTemperaturesClientTwo();
    }
}
