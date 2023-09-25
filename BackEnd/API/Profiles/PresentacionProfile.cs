using API.Dtos;
using AutoMapper;
using Dominio.Entities;

namespace API.Profiles;
    public class PresentacionProfile : Profile{
        public PresentacionProfile(){
            CreateMap<PresentacionDto, Presentacion>()
                .ReverseMap();
        }
    }
