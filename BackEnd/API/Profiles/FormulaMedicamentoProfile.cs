using API.Dtos;
using API.Dtos.FormulaMedica;
using AutoMapper;
using Dominio.Entities;

namespace API.Profiles;
    public class FormulaMedicamentoProfile : Profile{
        public FormulaMedicamentoProfile(){
            CreateMap<FormulaMedicamentoDto, FormulaMedicamentos>()
                .ReverseMap();

            CreateMap<FormulaMedicaComplementsDto, FormulaMedicamentos>()
                .ReverseMap();
        }
    }
