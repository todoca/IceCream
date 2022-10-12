using IceCream.Domain.Entities;
using IceCream.Infrastructure.Persistences.Contexts;
using IceCream.Infrastructure.Persistences.Interfaces;

namespace IceCream.Infrastructure.Persistences.Repositories;

public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
{
    private readonly IceCreamContext _context;

    public CategoryRepository(IceCreamContext context)
    {
        _context = context;
    }
}
