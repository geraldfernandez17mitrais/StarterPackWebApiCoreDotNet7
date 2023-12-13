using AutoMapper;
using RefreshFW.Application.Dtos;
using RefreshFW.Domain.Entities;

namespace RefreshFW.Application.Mappers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            // CustomerIndividu:
            CreateMap<CustomerIndividuDto, CustomerIndividu>();
            CreateMap<CustomerIndividu, CustomerIndividuDto>();
            CreateMap<CustomerIndividuPostDto, CustomerIndividu>();
            CreateMap<CustomerIndividuPutDto, CustomerIndividu>();
        }
    }
}