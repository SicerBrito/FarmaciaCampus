using API.Dtos;
using API.Dtos.Cita;
using API.Dtos.Ciudad;
using API.Dtos.Compra;
using API.Dtos.Departamento;
using API.Dtos.Direccion;
using API.Dtos.Empleado;
using API.Dtos.FormulaMedica;
using API.Dtos.FormulaMedicamento;
using API.Dtos.HistorialMedico;
using API.Dtos.Inventario;
using API.Dtos.Medicamento;
using API.Dtos.MedicamentosVendidos;
using API.Dtos.Paciente;
using API.Dtos.Venta;
using AutoMapper;
using Dominio.Entities;

namespace API.Profiles;
    public class MappingProfile : Profile{
        public MappingProfile(){

            CreateMap<CargoEmpleadoDto, CargoEmpleado>()
                .ReverseMap();

            CreateMap<CategoriaMedicamentoDto, CategoriaMedicamento>()
                .ReverseMap();
                
            CreateMap<CitaDto, Cita>()
                .ReverseMap();
            
            CreateMap<CitaComplementsDto, Cita>()
                .ReverseMap();

            CreateMap<CiudadDto, Ciudad>()
                .ReverseMap();
                
            CreateMap<CiudadComplementsDto, Ciudad>()
                .ReverseMap();

            CreateMap<CompraDto, Compra>()
                .ReverseMap();

            CreateMap<CompraComplementsDto, Compra>()
                .ReverseMap();

            CreateMap<DepartamentoDto, Departamento>()
                .ReverseMap();

            CreateMap<DepartamentoComplemetsDto, Departamento>()
                .ReverseMap();

            CreateMap<DireccionDto, Direccion>()
                .ReverseMap();

            CreateMap<DireccionComplementsDto, Direccion>()
                .ReverseMap();

            CreateMap<EmpleadoDto, Empleado>()
                .ReverseMap();

            CreateMap<EmpleadoComplementsDto, Empleado>()
                .ReverseMap();

            CreateMap<EstadoCitaDto, EstadoCita>()
                .ReverseMap();

            CreateMap<FarmaciaDto, Farmacia>()
                .ReverseMap();

            CreateMap<FormulaMedicamentoDto, FormulaMedicamentos>()
                .ReverseMap();

            CreateMap<FormulaMedicamentoComplementsDto, FormulaMedicamentos>()
                .ReverseMap();

            CreateMap<FormulaMedicaComplementsDto, FormulaMedicamentos>()
                .ReverseMap();

            CreateMap<FormulaMedicaDto, FormulaMedica>()
                .ReverseMap();

            CreateMap<FormulaMedicaComplementsDto, FormulaMedica>()
                .ReverseMap();

            CreateMap<GeneroDto, Genero>()
                .ReverseMap();

            CreateMap<HistorialMedicoDto, HistorialMedico>()
                .ReverseMap();

            CreateMap<HistorialMedicoComplementsDto, HistorialMedico>()
                .ReverseMap();

            CreateMap<InventarioDto, Inventario>()
                .ReverseMap();

            CreateMap<InventarioComplementsDto, Inventario>()
                .ReverseMap();

            CreateMap<MedicamentoDto, Medicamento>()
                .ReverseMap();

            CreateMap<MedicamentoComplementsDto, Medicamento>()
                .ReverseMap();

            CreateMap<MedicamentosCompradosDto, MedicamentosComprados>()
                .ReverseMap();

            CreateMap<MedicamentosCompradosComplementsDto, MedicamentosComprados>()
                .ReverseMap();

            CreateMap<MedicamentosVendidosDto, MedicamentosVendidos>()
                .ReverseMap();

            CreateMap<MedicamentosVendidosComplementsDto, MedicamentosVendidos>()
                .ReverseMap();

            CreateMap<MetodoDePagoDto, MetodoDePago>()
                .ReverseMap();

            CreateMap<PacienteDto, Paciente>()
                .ReverseMap();

            CreateMap<PacienteComplementsDto, Paciente>()
                .ReverseMap();

            CreateMap<PaisDto, Pais>()
                .ReverseMap();

            CreateMap<PresentacionDto, Presentacion>()
                .ReverseMap();

            CreateMap<ProveedorDto, Proveedor>()
                .ReverseMap();

            CreateMap<TipoDireccionDto, TipoDireccion>()
                .ReverseMap();

            CreateMap<TipoMedicamentoDto, TipoMedicamento>()
                .ReverseMap();

           CreateMap<TipoViaDto, TipoVia>()
                .ReverseMap();

            CreateMap<VentaDto, Venta>()
                .ReverseMap();

            CreateMap<VentaComplementsDto, Venta>()
                .ReverseMap();

        }
    }
