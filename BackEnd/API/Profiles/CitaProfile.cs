using API.Dtos;
using API.Dtos.Cita;
using AutoMapper;
using Dominio.Entities;

namespace API.Profiles;
    public class CitaProfile : Profile{
        public CitaProfile(){
            CreateMap<CitaDto, Cita>()
                .ReverseMap();
            
            CreateMap<CitaComplementsDto, Cita>()
                .ReverseMap();
        }
    }
