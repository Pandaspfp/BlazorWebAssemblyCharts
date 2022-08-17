using System;
using System.Collections.Generic;

namespace HorizonLab.DataLayer.Models
{
    public partial class MeasurementLight
    {
        public int Id { get; set; }
        public int FkGreenhousesId { get; set; }
        public bool LightOn { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
