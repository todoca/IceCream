using IceCream.Domain.Entities;
using IceCream.Infrastructure.Commons.Bases.Request;
using IceCream.Infrastructure.Commons.Bases.Response;
using IceCream.Infrastructure.Persistences.Contexts;
using IceCream.Infrastructure.Persistences.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Dynamic.Core;

namespace IceCream.Infrastructure.Persistences.Repositories;

public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
{
    public CategoryRepository(IceCreamContext context) : base(context) { }

    public async Task<BaseEntityResponse<Category>> ListCategories(BaseFilterRequest filters)
    {
        var response = new BaseEntityResponse<Category>();

        var categories = GetEntityQuery(x => x.DeleteUser == null && x.DeleteDate == null);

        if (filters is not null && !string.IsNullOrEmpty(filters.TextFilter))
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

        if (filters.Sort is null) filters.Sort = "Id";

        response.TotalRecords = await categories.CountAsync();
        response.Items = await Ordering(filters, categories, !(bool)filters.Download!).ToListAsync();

        return response;
    }
}
