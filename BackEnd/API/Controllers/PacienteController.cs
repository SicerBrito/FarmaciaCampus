using API.Dtos;
using API.Dtos.Paciente;
using API.Helpers;
using AutoMapper;
using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

    [ApiVersion("1.0")]
    [ApiVersion("1.1")]
    public class PacienteController : BaseApiController{
                        
        private readonly IUnitOfWork _UnitOfWork;
        private readonly IMapper _Mapper;
        
        public PacienteController(IUnitOfWork unitOfWork,IMapper mapper){
            _UnitOfWork = unitOfWork;
            _Mapper = mapper;
        }

        [HttpGet]
        //[Authorize]
        [MapToApiVersion("1.0")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<PacienteDto>>> Get(){
            var records = await _UnitOfWork.Pacientes!.GetAllAsync();
            return _Mapper.Map<List<PacienteDto>>(records);
        }
        
        [HttpGet]
        [MapToApiVersion("1.1")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Pager<PacienteComplementsDto>>> Get11([FromQuery] Params recordParams)
        {
            var record = await _UnitOfWork.Pacientes!.GetAllAsync(recordParams.PageIndex,recordParams.PageSize,recordParams.Search);
            var lstrecordsDto = _Mapper.Map<List<PacienteComplementsDto>>(record.registros);
            return new Pager<PacienteComplementsDto>(lstrecordsDto,record.totalRegistros,recordParams.PageIndex,recordParams.PageSize,recordParams.Search);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<PacienteComplementsDto>> Get(string id)
        {
            var record = await _UnitOfWork.Pacientes!.GetByIdAsync(id);
            if (record == null){
                return NotFound();
            }
            return _Mapper.Map<PacienteComplementsDto>(record);
        }


        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Paciente>> Post(PacienteComplementsDto recordDto){
            var record = _Mapper.Map<Paciente>(recordDto);
            _UnitOfWork.Pacientes!.Add(record);
            await _UnitOfWork.SaveAsync();
            if (record == null)
            {
                return BadRequest();
            }
            recordDto.Id = record.Id;
            return CreatedAtAction(nameof(Post),new {id= recordDto.Id}, recordDto);
        }

        //! Consulta Nro.12
        [HttpGet("pacientesQueCompraronParacetamol")]
        public async Task<ActionResult<List<Paciente>>> ObtenerPacientesQueHanCompradoParacetamol()
        {
            var pacientes = await _UnitOfWork.Pacientes!.ObtenerPacientesQueHanCompradoParacetamol();
            return Ok(pacientes);
        }

        //! Consulta Nro.22
        [HttpGet("pacienteMayorGasto2023")]
        public async Task<ActionResult<Paciente>> ObtenerPacienteMayorGasto2023()
        {
            var pacienteMayorGasto2023 = await _UnitOfWork.Pacientes!.ObtenerPacienteMayorGasto2023();
            return Ok(pacienteMayorGasto2023);
        }
        
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<PacienteDto>> Put(string id, [FromBody]PacienteDto recordDto){
            if(recordDto == null)
                return NotFound();
            var records = _Mapper.Map<Paciente>(recordDto);
            _UnitOfWork.Pacientes!.Update(records);
            await _UnitOfWork.SaveAsync();
            return recordDto;
            
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(string id){
            var record = await _UnitOfWork.Pacientes!.GetByIdAsync(id);
            if(record == null){
                return NotFound();
            }
            _UnitOfWork.Pacientes.Remove(record);
            await _UnitOfWork.SaveAsync();
            return NoContent();
        }
        
    }
