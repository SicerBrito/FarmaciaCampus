using API.Dtos;
using AutoMapper;
using Dominio.Entities;

namespace API.Profiles;
    public class FarmaciaProfile : Profile{
        public FarmaciaProfile(){
            CreateMap<FarmaciaDto, Farmacia>()
                .ReverseMap();
        }
    }
