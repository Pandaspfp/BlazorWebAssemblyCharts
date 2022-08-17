using System;
using System.Collections.Generic;

namespace HorizonLab.DataLayer.Models
{
    public partial class Device
    {
        public int Id { get; set; }
        public string Hostname { get; set; } = null!;
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
