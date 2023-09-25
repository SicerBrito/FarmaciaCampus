using API.Dtos;
using API.Dtos.Inventario;
using AutoMapper;
using Dominio.Entities;

namespace API.Profiles;
    public class InventarioProfile : Profile{
        public InventarioProfile(){
            CreateMap<InventarioDto, Inventario>()
                .ReverseMap();

            CreateMap<InventarioComplementsDto, Inventario>()
                .ReverseMap();
        }
    }
