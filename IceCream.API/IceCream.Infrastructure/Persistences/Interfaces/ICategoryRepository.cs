using IceCream.Domain.Entities;
using IceCream.Infrastructure.Commons.Bases.Request;
using IceCream.Infrastructure.Commons.Bases.Response;

namespace IceCream.Infrastructure.Persistences.Interfaces;

public interface ICategoryRepository
{
    Task<BaseEntityResponse<Category>> ListCategories(BaseFilterRequest filters);
    Task<IEnumerable<Category>> ListSelectCategories();
    Task<Category> CategoryById(int categoryId);
    Task<bool> RegisterCategory(Category category);
    Task<bool> EditCategory(Category category);
    Task<bool> RemoveCategory(int categoryId);
}
