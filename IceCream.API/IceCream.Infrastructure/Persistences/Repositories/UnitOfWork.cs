using IceCream.Infrastructure.Persistences.Contexts;
using IceCream.Infrastructure.Persistences.Interfaces;

namespace IceCream.Infrastructure.Persistences.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly IceCreamContext _context;
    public ICategoryRepository Category { get; private set; }

    public UnitOfWork(IceCreamContext context)
    {
        _context = context;
        Category = new CategoryRepository(context);
    }

    public void Dispose() => _context.Dispose();

    public IceCreamContext Get_context() => _context;

    public void SaveChanges() => _context.SaveChanges();

    public async Task SaveChangesAsync() => await _context.SaveChangesAsync();

}
