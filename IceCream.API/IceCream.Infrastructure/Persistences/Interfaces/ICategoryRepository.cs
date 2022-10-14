using IceCream.Domain.Entities;
using IceCream.Infrastructure.Commons.Bases.Request;
using IceCream.Infrastructure.Commons.Bases.Response;

namespace IceCream.Infrastructure.Persistences.Interfaces;

public interface ICategoryRepository : IGenericRepository<Category>
{
    Task<BaseEntityResponse<Category>> ListCategories(BaseFilterRequest filters);

}
