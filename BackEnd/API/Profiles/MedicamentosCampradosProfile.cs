using API.Dtos;
using API.Dtos.Medicamento;
using AutoMapper;
using Dominio.Entities;

namespace API.Profiles;
    public class MedicamentosCampradosProfile : Profile{
        public MedicamentosCampradosProfile(){
            CreateMap<MedicamentosCompradosDto, MedicamentosComprados>()
                .ReverseMap();

            CreateMap<MedicamentosCompradosComplementsDto, MedicamentosComprados>()
                .ReverseMap();
        }
    }
