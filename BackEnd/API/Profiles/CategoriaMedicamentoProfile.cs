using API.Dtos;
using AutoMapper;
using Dominio.Entities;

namespace API.Profiles;
    public class CategoriaMedicamentoProfile : Profile{
        public CategoriaMedicamentoProfile(){
            CreateMap<CategoriaMedicamentoDto, CategoriaMedicamento>()
                .ReverseMap();
        }
        
    }
