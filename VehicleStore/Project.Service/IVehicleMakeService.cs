using Project.Service.Model.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Project.Service
{
    public interface IVehicleMakeService : IVehicleService
    {
        Task<IVehicleMake> ReadAsync(Guid id);
        Task<int> CreateAsync(IVehicleMake entity);
        Task<int> UpdateAsync(IVehicleMake entity);
        Task<IEnumerable<IVehicleMake>> FindAsync(ISort sort, IFilter filter, IPage page);
    }
}
