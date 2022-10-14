using IceCream.Domain.Entities;
using IceCream.Infrastructure.Commons.Bases.Request;
using System.Linq.Expressions;

namespace IceCream.Infrastructure.Persistences.Interfaces;

public interface IGenericRepository<T> where T : IAuditable
{
    Task<IEnumerable<T>> GetAllAsync();
    Task<T> GetByIdAsync(int id);
    Task<bool> RegisterAsync(T entity);
    Task<bool> EditAsync(T entity);
    Task<bool> RemoveAsync(int id);
    IQueryable<T> GetEntityQuery(Expression<Func<T, bool>>? filter = null);
    IQueryable<TDTO> Ordering<TDTO>(BasePaginationRequest request, IQueryable<TDTO> queryable,
        bool pagination = false) where TDTO : class;
}
