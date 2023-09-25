using API.Dtos;
using API.Dtos.Venta;
using AutoMapper;
using Dominio.Entities;

namespace API.Profiles;
    public class VentaProfile : Profile{
        public VentaProfile(){
            CreateMap<VentaDto, Venta>()
                .ReverseMap();

            CreateMap<VentaComplementsDto, Venta>()
                .ReverseMap();
        }
    }
