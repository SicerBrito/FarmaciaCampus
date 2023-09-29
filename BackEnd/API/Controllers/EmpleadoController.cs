using API.Dtos;
using API.Dtos.Empleado;
using API.Helpers;
using AutoMapper;
using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

    [ApiVersion("1.0")]
    [ApiVersion("1.1")]
    public class EmpleadoController : BaseApiController{
                        
        private readonly IUnitOfWork _UnitOfWork;
        private readonly IMapper _Mapper;
        
        public EmpleadoController(IUnitOfWork unitOfWork,IMapper mapper){
            _UnitOfWork = unitOfWork;
            _Mapper = mapper;
        }

        [HttpGet]
        //[Authorize]
        [MapToApiVersion("1.0")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<EmpleadoDto>>> Get(){
            var records = await _UnitOfWork.Empleados!.GetAllAsync();
            return _Mapper.Map<List<EmpleadoDto>>(records);
        }
        
        [HttpGet]
        [MapToApiVersion("1.1")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Pager<EmpleadoComplementsDto>>> Get11([FromQuery] Params recordParams)
        {
            var record = await _UnitOfWork.Empleados!.GetAllAsync(recordParams.PageIndex,recordParams.PageSize,recordParams.Search);
            var lstrecordsDto = _Mapper.Map<List<EmpleadoComplementsDto>>(record.registros);
            return new Pager<EmpleadoComplementsDto>(lstrecordsDto,record.totalRegistros,recordParams.PageIndex,recordParams.PageSize,recordParams.Search);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<EmpleadoComplementsDto>> Get(string id)
        {
            var record = await _UnitOfWork.Empleados!.GetByIdAsync(id);
            if (record == null){
                return NotFound();
            }
            return _Mapper.Map<EmpleadoComplementsDto>(record);
        }

        //! Consulta Nro.20
        [HttpGet("empleadosConMasDe5Ventas")]
        public async Task<ActionResult<List<Empleado>>> ObtenerEmpleadosConMasDe5Ventas()
        {
            var empleadosConMasDe5Ventas = await _UnitOfWork.Empleados!.ObtenerEmpleadosConMasDe5Ventas();
            return Ok(empleadosConMasDe5Ventas);
        }

        //! Consulta Nro.23
        [HttpGet("empleadosSinVentasEn2023")]
        public async Task<ActionResult<List<Empleado>>> ObtenerEmpleadosSinVentasEn2023()
        {
            var empleadosSinVentasEn2023 = await _UnitOfWork.Empleados!.ObtenerEmpleadosSinVentasEn2023();
            return Ok(empleadosSinVentasEn2023);
        }

        //! Consulta Nro.32
        [HttpGet("empleadoMayorCantidadMedicamentosVendidosEn2023")]
        public async Task<ActionResult<Empleado>> ObtenerEmpleadoMayorCantidadMedicamentosVendidosEn2023()
        {
            var empleadoConMayorCantidad = await _UnitOfWork.Empleados!.ObtenerEmpleadoMayorCantidadMedicamentosVendidosEn2023();
            return Ok(empleadoConMayorCantidad);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Empleado>> Post(EmpleadoComplementsDto recordDto){
            var record = _Mapper.Map<Empleado>(recordDto);
            _UnitOfWork.Empleados!.Add(record);
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
        public async Task<ActionResult<EmpleadoDto>> Put(string id, [FromBody]EmpleadoDto recordDto){
            if(recordDto == null)
                return NotFound();
            var records = _Mapper.Map<Empleado>(recordDto);
            _UnitOfWork.Empleados!.Update(records);
            await _UnitOfWork.SaveAsync();
            return recordDto;
            
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(string id){
            var record = await _UnitOfWork.Empleados!.GetByIdAsync(id);
            if(record == null){
                return NotFound();
            }
            _UnitOfWork.Empleados.Remove(record);
            await _UnitOfWork.SaveAsync();
            return NoContent();
        }
        
    }
