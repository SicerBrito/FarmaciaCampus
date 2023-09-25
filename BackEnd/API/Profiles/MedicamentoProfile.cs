using API.Dtos.Medicamento;
using AutoMapper;
using Dominio.Entities;

namespace API.Profiles;
    public class MedicamentoProfile : Profile{
        public MedicamentoProfile(){
            CreateMap<MedicamentoDto, Medicamento>()
                .ReverseMap();

            CreateMap<MedicamentoComplementsDto, Medicamento>()
                .ReverseMap();
        }
    }
