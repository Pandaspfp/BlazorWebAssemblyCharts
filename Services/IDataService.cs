using HorizonLab.DataLayer.Interfaces;

namespace HorizonLab.DataLayer.Services
{
    public interface IDataService
    {
        public IDevice Device { get; }
        public IGreenhouse Greenhouse { get; }
        public IMeasurementLight MeasurementLight { get; }
        public IMeasurementTemperature MeasurementTemperature { get; }
    }
}
