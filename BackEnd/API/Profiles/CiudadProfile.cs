using API.Dtos;
using API.Dtos.Ciudad;
using AutoMapper;
using Dominio.Entities;

namespace API.Profiles;
    public class CiudadProfile : Profile{
        public CiudadProfile(){
            CreateMap<CiudadDto, Ciudad>()
                .ReverseMap();
                
            CreateMap<CiudadComplementsDto, Ciudad>()
                .ReverseMap();
        }
    }
