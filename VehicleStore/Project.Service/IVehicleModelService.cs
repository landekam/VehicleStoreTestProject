using Project.Service.Model.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Project.Service
{
    public interface IVehicleModelService : IVehicleService
    {
        Task<IVehicleModel> ReadAsync(Guid id);
        Task<int> CreateAsync(IVehicleModel entity);
        Task<int> UpdateAsync(IVehicleModel entity);
        Task<IEnumerable<IVehicleModel>> FindAsync(ISort sort, IFilter filter, IPage page);
    }
}
