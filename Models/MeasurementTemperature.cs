using System;
using System.Collections.Generic;

namespace HorizonLab.DataLayer.Models
{
    public partial class MeasurementTemperature
    {
        public int Id { get; set; }
        public int FkGreenhousesId { get; set; }
        public double Temperature { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
