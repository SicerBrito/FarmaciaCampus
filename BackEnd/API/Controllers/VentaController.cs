using API.Dtos;
using API.Dtos.Venta;
using API.Helpers;
using AutoMapper;
using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

    [ApiVersion("1.0")]
    [ApiVersion("1.1")]
    public class VentaController : BaseApiController{
                        
        private readonly IUnitOfWork _UnitOfWork;
        private readonly IMapper _Mapper;
        
        public VentaController(IUnitOfWork unitOfWork,IMapper mapper){
            _UnitOfWork = unitOfWork;
            _Mapper = mapper;
        }

        [HttpGet]
        //[Authorize]
        [MapToApiVersion("1.0")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<VentaDto>>> Get(){
            var records = await _UnitOfWork.Ventas!.GetAllAsync();
            return _Mapper.Map<List<VentaDto>>(records);
        }
        
        [HttpGet]
        [MapToApiVersion("1.1")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Pager<VentaComplementsDto>>> Get11([FromQuery] Params recordParams)
        {
            var record = await _UnitOfWork.Ventas!.GetAllAsync(recordParams.PageIndex,recordParams.PageSize,recordParams.Search);
            var lstrecordsDto = _Mapper.Map<List<VentaComplementsDto>>(record.registros);
            return new Pager<VentaComplementsDto>(lstrecordsDto,record.totalRegistros,recordParams.PageIndex,recordParams.PageSize,recordParams.Search);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<VentaComplementsDto>> Get(string id)
        {
            var record = await _UnitOfWork.Ventas!.GetByIdAsync(id);
            if (record == null){
                return NotFound();
            }
            return _Mapper.Map<VentaComplementsDto>(record);
        }

        //! Consulta Nro.5
        [HttpGet("totalVentasParacetamol")]
        public async Task<ActionResult<decimal>> ObtenerTotalVentasParacetamol()
        {
            var totalVentas = await _UnitOfWork.Ventas!.ObtenerTotalVentasParacetamol();
            return Ok(totalVentas);
        }

        //! Consulta Nro.8
        [HttpGet("totalDineroRecaudadoPorVentas")]
        public async Task<ActionResult<decimal>> ObtenerTotalDineroRecaudadoPorVentas()
        {
            var totalDineroRecaudado = await _UnitOfWork.Ventas!.ObtenerTotalDineroRecaudadoPorVentas();
            return Ok(totalDineroRecaudado);
        }

        //! Consulta Nro.14
        [HttpGet("totalMedicamentosVendidosEnMarzo2023")]
        public async Task<ActionResult<int>> ObtenerTotalMedicamentosVendidosEnMarzo2023()
        {
            var totalMedicamentosVendidos = await _UnitOfWork.Ventas!.ObtenerTotalMedicamentosVendidosEnMarzo2023();
            return Ok(totalMedicamentosVendidos);
        }

        //! Consulta Nro.15
        [HttpGet("medicamentoMenosVendidoEn2023")]
        public async Task<ActionResult<Medicamento>> ObtenerMedicamentoMenosVendidoEn2023()
        {
            var medicamentoMenosVendido = await _UnitOfWork.Ventas!.ObtenerMedicamentoMenosVendidoEn2023();
            return Ok(medicamentoMenosVendido);
        }

        //! Consulta Nro.17
        [HttpGet("promedioMedicamentosCompradosPorVenta")]
        public async Task<ActionResult<double>> CalcularPromedioMedicamentosCompradosPorVenta()
        {
            var promedio = await _UnitOfWork.Ventas!.CalcularPromedioMedicamentosCompradosPorVenta();
            return Ok(promedio);
        }

        //! Consulta Nro.18
        [HttpGet("cantidadVentasPorEmpleadoEn2023")]
        public async Task<ActionResult<Dictionary<string, int>>> ObtenerCantidadVentasPorEmpleadoEn2023()
        {
            var ventasPorEmpleado = await _UnitOfWork.Ventas!.ObtenerCantidadVentasPorEmpleadoEn2023();
            return Ok(ventasPorEmpleado);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Venta>> Post(VentaComplementsDto recordDto){
            var record = _Mapper.Map<Venta>(recordDto);
            _UnitOfWork.Ventas!.Add(record);
            await _UnitOfWork.SaveAsync();
            if (record == null)
            {
                return BadRequest();
            }
            recordDto.Id = record.Id;
            return CreatedAtAction(nameof(Post),new {id= recordDto.Id}, recordDto);
        }

        
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<VentaDto>> Put(string id, [FromBody]VentaDto recordDto){
            if(recordDto == null)
                return NotFound();
            var records = _Mapper.Map<Venta>(recordDto);
            _UnitOfWork.Ventas!.Update(records);
            await _UnitOfWork.SaveAsync();
            return recordDto;
            
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(string id){
            var record = await _UnitOfWork.Ventas!.GetByIdAsync(id);
            if(record == null){
                return NotFound();
            }
            _UnitOfWork.Ventas.Remove(record);
            await _UnitOfWork.SaveAsync();
            return NoContent();
        }
        
    }
