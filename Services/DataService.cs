using HorizonLab.DataLayer.Interfaces;

namespace HorizonLab.DataLayer.Services
{
    public class DataService : IDataService
    {
        private readonly IDevice _device;
        private readonly IGreenhouse _greenhouse;
        private readonly IMeasurementLight _measurementLight;
        private readonly IMeasurementTemperature _measurementTemperature;

        public IDevice Device => _device;
        public IGreenhouse Greenhouse => _greenhouse;
        public IMeasurementLight MeasurementLight => _measurementLight;
        public IMeasurementTemperature MeasurementTemperature => _measurementTemperature;

        public DataService(
            IDevice device,
            IGreenhouse greenhouse,
            IMeasurementLight measurementLight,
            IMeasurementTemperature measurementTemperature
            )
        {
            _device = device;
            _greenhouse = greenhouse;
            _measurementLight = measurementLight;
            _measurementTemperature = measurementTemperature;
        }
    }
}
