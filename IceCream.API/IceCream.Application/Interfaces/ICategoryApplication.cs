using IceCream.Application.Commons.Bases;
using IceCream.Application.Dtos.Request;
using IceCream.Application.Dtos.Response;
using IceCream.Infrastructure.Commons.Bases.Request;
using IceCream.Infrastructure.Commons.Bases.Response;

namespace IceCream.Application.Interfaces;

public interface ICategoryApplication
{
    Task<BaseResponse<BaseEntityResponse<CategoryResponseDto>>> ListCategories(BaseFilterRequest filters);
    Task<BaseResponse<IEnumerable<CategorySelectResponseDto>>> ListSelectCategories();
    Task<BaseResponse<CategoryResponseDto>> CategoryById(int categoryId);
    Task<BaseResponse<bool>> RegisterCategory(CategoryRequestDto requestDto);   
    Task<BaseResponse<bool>> EditCategory(int categoryId, CategoryRequestDto requestDto);  
    Task<BaseResponse<bool>> RemoveCategory(int categoryId);
}
