using API.Dtos;
using AutoMapper;
using Dominio.Entities;

namespace API.Profiles;
    public class PaisProfile : Profile{
        public PaisProfile(){
            CreateMap<PaisDto, Pais>()
                .ReverseMap();   
        } 
    }
