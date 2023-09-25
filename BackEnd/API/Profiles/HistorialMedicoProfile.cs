using API.Dtos;
using API.Dtos.HistorialMedico;
using AutoMapper;
using Dominio.Entities;

namespace API.Profiles;
    public class HistorialMedicoProfile : Profile{
        public HistorialMedicoProfile(){
            CreateMap<HistorialMedicoDto, HistorialMedico>()
                .ReverseMap();

            CreateMap<HistorialMedicoComplementsDto, HistorialMedico>()
                .ReverseMap();
        }
    }
