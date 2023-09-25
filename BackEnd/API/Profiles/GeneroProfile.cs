using API.Dtos;
using AutoMapper;
using Dominio.Entities;

namespace API.Profiles;
    public class GeneroProfile : Profile{
        public GeneroProfile(){
            CreateMap<GeneroDto, Genero>()
                .ReverseMap();
        }
    }
