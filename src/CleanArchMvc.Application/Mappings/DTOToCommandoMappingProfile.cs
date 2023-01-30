using AutoMapper;
using CleanArchMvc.Application.DTOs;
using CleanArchMvc.Application.Products.Commands;

namespace CleanArchMvc.Application.Mappings;

public class DTOToCommandoMappingProfile : Profile
{
	public DTOToCommandoMappingProfile()
	{
		CreateMap<ProductDTO, ProductCreateCommand>();
        CreateMap<ProductDTO, ProductUpdateCommand>();
    }
}
