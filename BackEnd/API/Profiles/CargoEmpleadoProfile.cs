using API.Dtos;
using AutoMapper;
using Dominio.Entities;

namespace API.Profiles;
    public class CargoEmpleadoProfile : Profile{
        public CargoEmpleadoProfile(){
            CreateMap<CargoEmpleadoDto, CargoEmpleado>()
                .ReverseMap();
        }
    }
