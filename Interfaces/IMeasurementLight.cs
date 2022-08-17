using HorizonLab.DataLayer.Models;

namespace HorizonLab.DataLayer.Interfaces
{
    public interface IMeasurementLight
    {
        Task<MeasurementLight> GetMeasurementLight(int id);
        Task<List<MeasurementLight>> GetMeasurementLights();
    }
}
