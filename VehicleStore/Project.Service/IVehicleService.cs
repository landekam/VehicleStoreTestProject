using Project.Service.Model.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Project.Service
{
    public interface IVehicleService
    {
        Task<IEntity> CreateAsync(IEntity entity);
        Task<IEntity> ReadAsync(Guid id);
        Task<int> UpdateAsync(IEntity entity);
        Task<int> DeleteAsync(Guid id);
        Task<IEnumerable<IEntity>> FindAsync(ISort sort, IFilter filter, IPage page);
    }
}
