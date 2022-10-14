using IceCream.Domain.Entities;
using IceCream.Infrastructure.Commons.Bases.Request;
using IceCream.Infrastructure.Helpers;
using IceCream.Infrastructure.Persistences.Contexts;
using IceCream.Infrastructure.Persistences.Interfaces;
using IceCream.Utilities.Static;
using Microsoft.EntityFrameworkCore;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace IceCream.Infrastructure.Persistences.Repositories;

public class GenericRepository<T> : IGenericRepository<T> where T : IAuditable
{
    private readonly IceCreamContext _context;
    private readonly DbSet<T> _entity;

    public GenericRepository(IceCreamContext context)
    {
        _context = context;
        _entity = _context.Set<T>();
    }


    public async Task<IEnumerable<T>> GetAllAsync()
    {
        var getAll = await _entity
            .Where(x => x.State.Equals((int)StateTypes.Active) && x.DeleteUser == null && x.DeleteDate == null)
            .AsNoTracking().ToListAsync();
        return getAll;
    }
    public async Task<T> GetByIdAsync(int id)
    {
        var getById = await _entity!.AsNoTracking().FirstOrDefaultAsync(x => x.Id.Equals(id));
        return getById!;
    }

    public async Task<bool> RegisterAsync(T entity)
    {
        entity.CreateUser = 1;
        entity.CreateDate = DateTime.Now;

        await _context.AddAsync(entity);

        var recordAffected = await _context.SaveChangesAsync();
        return recordAffected > 0;


    }

    public async Task<bool> EditAsync(T entity)
    {
        entity.UpdateUser = 1;
        entity.UpdateDate = DateTime.Now;

        _context.Update(entity);
        _context.Entry(entity).Property(x => x.CreateUser).IsModified = false;
        _context.Entry(entity).Property(x => x.CreateDate).IsModified = false;
        var recordsAffected = await _context.SaveChangesAsync();
        return recordsAffected > 0;
    }

    public async Task<bool> RemoveAsync(int id)
    {
        T entity = await GetByIdAsync(id);

        entity!.DeleteUser = 1;
        entity.DeleteDate = DateTime.Now;

        _context.Update(entity);
        var recordsAffected = await _context.SaveChangesAsync();
        return recordsAffected > 0;
    }


    public IQueryable<T> GetEntityQuery(Expression<Func<T, bool>>? filter = null)
    {
        IQueryable<T> query = _entity;
        if (filter != null) query = query.Where(filter);
        return query;
    }

    public IQueryable<TDTO> Ordering<TDTO>(BasePaginationRequest request, IQueryable<TDTO> queryable,
        bool pagination = false) where TDTO : class
    {
        IQueryable<TDTO> queryDto = request.Order == "desc" ? queryable.OrderBy($"{request.Sort} descending") :
            queryable.OrderBy($"{request.Sort} ascending");

        if (pagination) queryDto = queryDto.Paginate(request);
        return queryDto;
    }
}
