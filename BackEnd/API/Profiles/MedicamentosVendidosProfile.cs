using API.Dtos.MedicamentosVendidos;
using AutoMapper;
using Dominio.Entities;

namespace API.Profiles;
    public class MedicamentosVendidosProfile : Profile{
        public MedicamentosVendidosProfile(){
            CreateMap<MedicamentosVendidosDto, MedicamentosVendidos>()
                .ReverseMap();

            CreateMap<MedicamentosVendidosComplementsDto, MedicamentosVendidos>()
                .ReverseMap();
        }
    }
