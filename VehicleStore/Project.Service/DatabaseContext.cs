using Microsoft.EntityFrameworkCore;
using Project.Service.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Service
{
    public class DatabaseContext : DbContext
    {
        public DbSet<VehicleMake> vehicleMakes { get; set; }
        public DbSet<VehicleModel> vehicleModels { get; set; }
    }
}
