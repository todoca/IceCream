using IceCream.Domain.Entities;
using IceCream.Infrastructure.Commons.Bases.Request;
using IceCream.Infrastructure.Commons.Bases.Response;
using IceCream.Infrastructure.Persistences.Contexts;
using IceCream.Infrastructure.Persistences.Interfaces;
using IceCream.Utilities.Static;
using Microsoft.EntityFrameworkCore;
using System.Linq.Dynamic.Core;

namespace IceCream.Infrastructure.Persistences.Repositories;

public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
{
    private readonly IceCreamContext _context;

    public CategoryRepository(IceCreamContext context)
    {
        _context = context;
    }
    public async Task<BaseEntityResponse<Category>> ListCategories(BaseFilterRequest filters)
    {
        var response = new BaseEntityResponse<Category>();

        var categories = (from c in _context.Categories 
                          where c.DeleteUser == null && c.DeleteDate == null
                          select c).AsNoTracking().AsQueryable();
        if(filters is not null && !string.IsNullOrEmpty(filters.TextFilter))
        {
            switch (filters.NumFilter)
            {
                case 1:
                    categories = categories.Where(x => x.Name!.Contains(filters.TextFilter));
                    break;
                case 2:
                    categories = categories.Where(x => x.Description!.Contains(filters.TextFilter));
                    break;
            }
        }

        if (filters!.StateFilter is not null)
        {
            categories = categories.Where(x => x.State.Equals(filters.StateFilter));
        }

        if (!string.IsNullOrEmpty(filters.StartDate) && !string.IsNullOrEmpty(filters.EndDate))
        {
            categories = categories.Where(x => x.CreateDate >= Convert.ToDateTime(filters.StartDate) &&
            x.CreateDate <= Convert.ToDateTime(filters.EndDate).AddDays(1));
        }

        if(filters.Sort is null) filters.Sort = "CategoryId";

        response.TotalRecords = await categories.CountAsync();
        response.Items = await Ordering(filters, categories, !(bool)filters.Download!).ToListAsync();
       
        return response;
    }
    public async Task<IEnumerable<Category>> ListSelectCategories()
    {
        var categories = await _context.Categories
            .Where(x => x.State.Equals((int)StateTypes.Active) && x.DeleteUser == null && x.DeleteDate == null)
            .AsNoTracking().ToListAsync();
        return categories;
    }
    public async Task<Category> CategoryById(int categoryId)
    {
        var category = await _context.Categories!.AsNoTracking()
            .FirstOrDefaultAsync(x => x.CategoryId.Equals(categoryId));
        return category!;
    }

    public async Task<bool> RegisterCategory(Category category)
    {
        category.CreateUser = 1;
        category.CreateDate = DateTime.Now;
        await _context.AddAsync(category);
        var recordsAffected = await _context.SaveChangesAsync();
        return recordsAffected > 0;

    }

    public async Task<bool> EditCategory(Category category)
    {
        category.UpdateUser = 1;
        category.UpdateDate = DateTime.Now;

        _context.Update(category);
        _context.Entry(category).Property(x => x.CreateUser).IsModified = false;
        _context.Entry(category).Property(x => x.CreateDate).IsModified = false;
        var recordsAffected = await _context.SaveChangesAsync();
        return recordsAffected > 0;
    }

    public async Task<bool> RemoveCategory(int categoryId)
    { 
        var category = await _context.Categories.AsNoTracking().SingleOrDefaultAsync(x => x.CategoryId.Equals(categoryId));

        category!.DeleteUser = 1;
        category.DeleteDate = DateTime.Now;

        _context.Update(category);
        var recordsAffected = await _context.SaveChangesAsync();
        return recordsAffected > 0;
    }
}
