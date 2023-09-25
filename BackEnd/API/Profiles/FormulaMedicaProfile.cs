using API.Dtos;
using API.Dtos.FormulaMedica;
using AutoMapper;
using Dominio.Entities;

namespace API.Profiles;
    public class FormulaMedicaProfile : Profile{
        public FormulaMedicaProfile(){
            CreateMap<FormulaMedicaDto, FormulaMedica>()
                .ReverseMap();

            CreateMap<FormulaMedicaComplementsDto, FormulaMedica>()
                .ReverseMap();
        }
    }
