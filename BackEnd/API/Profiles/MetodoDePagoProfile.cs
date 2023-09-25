using API.Dtos;
using AutoMapper;
using Dominio.Entities;

namespace API.Profiles;
    public class MetodoDePagoProfile : Profile{
        public MetodoDePagoProfile(){
            CreateMap<MetodoDePagoDto, MetodoDePago>()
                .ReverseMap();
        }
    }
