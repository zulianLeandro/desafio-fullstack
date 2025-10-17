using AutoMapper;
using Backend.Application.Dtos;
using Backend.Domain.Entities;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Produto, ProdutoDto>().ReverseMap();
    }
}
