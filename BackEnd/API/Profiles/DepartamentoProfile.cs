using API.Dtos;
using API.Dtos.Departamento;
using AutoMapper;
using Dominio.Entities;

namespace API.Profiles;
    public class DepartamentoProfile : Profile{
        public DepartamentoProfile(){
            CreateMap<DepartamentoDto, Departamento>()
                .ReverseMap();

            CreateMap<DepartamentoComplemetsDto, Departamento>()
                .ReverseMap();
        }
    }
