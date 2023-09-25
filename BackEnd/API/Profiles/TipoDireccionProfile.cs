using API.Dtos;
using AutoMapper;
using Dominio.Entities;

namespace API.Profiles;
    public class TipoDireccionProfile : Profile{
        public TipoDireccionProfile(){
            CreateMap<TipoDireccionDto, TipoDireccion>()
                .ReverseMap();
        }
    }
