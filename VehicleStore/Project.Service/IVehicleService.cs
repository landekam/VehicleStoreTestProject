using Project.Service.Model.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Project.Service
{
    public interface IVehicleService
    {                  
        Task<int> DeleteAsync(Guid id);
        
    }
}
