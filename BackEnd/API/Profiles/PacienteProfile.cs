using API.Dtos;
using API.Dtos.Paciente;
using AutoMapper;
using Dominio.Entities;

namespace API.Profiles;
    public class PacienteProfile : Profile{
        public PacienteProfile(){
            CreateMap<PacienteDto, Paciente>()
                .ReverseMap();

            CreateMap<PacienteComplementsDto, Paciente>()
                .ReverseMap();
        }
    }
