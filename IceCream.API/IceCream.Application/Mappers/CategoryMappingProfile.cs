using AutoMapper;
using IceCream.Application.Dtos.Request;
using IceCream.Application.Dtos.Response;
using IceCream.Domain.Entities;
using IceCream.Infrastructure.Commons.Bases.Response;
using IceCream.Utilities.Static;

namespace IceCream.Application.Mappers;

public class CategoryMappingProfile : Profile
{
	public CategoryMappingProfile()
	{
		CreateMap<Category, CategoryResponseDto>()
			.ForMember(x => x.StateCategory, x => x.MapFrom(y => y.State.Equals((int)StateTypes.Active) ?
			"Active" : "Inactive")).ReverseMap();

		CreateMap<BaseEntityResponse<Category>, BaseEntityResponse<CategoryResponseDto>>()
			.ReverseMap();

		CreateMap<CategoryRequestDto, Category>();

		CreateMap<Category, CategorySelectResponseDto>();
	}
}
