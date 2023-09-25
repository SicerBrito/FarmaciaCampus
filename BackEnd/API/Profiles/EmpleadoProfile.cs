using API.Dtos;
using API.Dtos.Empleado;
using AutoMapper;
using Dominio.Entities;

namespace API.Profiles;
    public class EmpleadoProfile : Profile{
        public EmpleadoProfile(){
            CreateMap<EmpleadoDto, Empleado>()
                .ReverseMap();

            CreateMap<EmpleadoComplementsDto, Empleado>()
                .ReverseMap();
        }
    }
