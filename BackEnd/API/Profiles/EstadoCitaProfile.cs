using API.Dtos;
using AutoMapper;
using Dominio.Entities;

namespace API.Profiles;
    public class EstadoCitaProfile : Profile{
        public EstadoCitaProfile(){
            CreateMap<EstadoCitaDto, EstadoCita>()
                .ReverseMap();
        }        
    }
