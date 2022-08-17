using System;
using System.Collections.Generic;

namespace HorizonLab.DataLayer.Models
{
    public partial class Greenhouse
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int FkDevicesId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
