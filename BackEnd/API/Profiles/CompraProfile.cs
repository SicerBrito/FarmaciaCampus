using API.Dtos;
using API.Dtos.Compra;
using AutoMapper;
using Dominio.Entities;

namespace API.Profiles;
    public class CompraProfile : Profile{
        public CompraProfile(){
            CreateMap<CompraDto, Compra>()
                .ReverseMap();

            CreateMap<CompraComplementsDto, Compra>()
                .ReverseMap();
        }
    }
