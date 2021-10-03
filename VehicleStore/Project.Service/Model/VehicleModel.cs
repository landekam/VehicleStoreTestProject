using Project.Service.Model.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Service.Model
{
    public class VehicleModel : IVehicleModel
    {
        public Guid Id { get; set; }
        public Guid MakeId { get; set; }
        public string Name { get; set; }
        public string Abbreviation { get; set; }
    }
}
