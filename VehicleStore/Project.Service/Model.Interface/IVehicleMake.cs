using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Service.Model.Interface
{
    public interface IVehicleMake : IEntity
    {
        string Name { get; set; }
        string Abbreviation { get; set; }
    }
}
