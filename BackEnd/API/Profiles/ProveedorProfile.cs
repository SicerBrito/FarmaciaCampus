using API.Dtos;
using AutoMapper;
using Dominio.Entities;

namespace API.Profiles;
    public class ProveedorProfile : Profile{
        public ProveedorProfile(){
            CreateMap<ProveedorDto, Proveedor>()
                .ReverseMap();
        }
    }
