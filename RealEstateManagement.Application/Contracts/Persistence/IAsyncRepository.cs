using RealEstateManagement.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateManagement.Application.Contracts.Presistence
{
    public interface IAsyncRepository<Entity> where Entity : IAggregateRoot
    {
        Task<Guid> CreateAsync(Entity entity);
        Task<IEnumerable<Entity>> GetAllAsync();
        Task<IEnumerable<Entity>> GetAllAsync(Expression<Func<Entity, bool>> filter);
        Task<Entity> GetByIdAsync(Guid id);
        Task<Entity> GetAsync(Expression<Func<Entity, bool>> filter);
        Task DeleteAsync(Guid id);
        Task UpdateAsync(Entity entity);
    }
}
