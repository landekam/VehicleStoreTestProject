using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Service.Model.Interface
{
    public interface IVehicleModel : IEntity
    {
        Guid MakeId { get; set; }
        string Name { get; set; }
        string Abbreviation { get; set; }
    }
}
