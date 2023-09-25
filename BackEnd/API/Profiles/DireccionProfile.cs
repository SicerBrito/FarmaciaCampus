using API.Dtos;
using API.Dtos.Direccion;
using AutoMapper;
using Dominio.Entities;

namespace API.Profiles;
    public class DireccionProfile : Profile{
        public DireccionProfile(){
            CreateMap<DireccionDto, Direccion>()
                .ReverseMap();

            CreateMap<DireccionComplementsDto, Direccion>()
                .ReverseMap();
        }
    }
