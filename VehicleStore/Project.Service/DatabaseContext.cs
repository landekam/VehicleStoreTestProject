using Microsoft.EntityFrameworkCore;
using Project.Service.Model.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Service
{
    public class DatabaseContext : DbContext
    {        
        public DbSet<IVehicleMake> VehicleMakes { get; set; }
        public DbSet<IVehicleModel> VehicleModels { get; set; }
    }
}
