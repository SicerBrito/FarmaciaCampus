using API.Dtos;
using AutoMapper;
using Dominio.Entities;

namespace API.Profiles;
    public class TipoMedicamentoProfile : Profile{
        public TipoMedicamentoProfile(){
            CreateMap<TipoMedicamentoDto, TipoMedicamento>()
                .ReverseMap();
        }
    }
