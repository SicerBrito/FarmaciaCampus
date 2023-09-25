using API.Dtos;
using AutoMapper;
using Dominio.Entities;

namespace API.Profiles;
    public class TipoViaProfile : Profile{
        public TipoViaProfile(){
            CreateMap<TipoViaDto, TipoVia>()
                .ReverseMap();
        }
    }
