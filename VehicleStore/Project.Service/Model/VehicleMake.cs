using Project.Service.Model.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Service.Model
{
    public class VehicleMake : IVehicleMake
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Abbreviation { get; set; }
    }
}
