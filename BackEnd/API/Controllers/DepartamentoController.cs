using API.Dtos;
using API.Dtos.Departamento;
using API.Helpers;
using AutoMapper;
using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

    [ApiVersion("1.0")]
    [ApiVersion("1.1")]
    public class DepartamentoController : BaseApiController{
        
        private readonly IUnitOfWork _UnitOfWork;
        private readonly IMapper _Mapper;
        
        public DepartamentoController(IUnitOfWork unitOfWork,IMapper mapper){
            _UnitOfWork = unitOfWork;
            _Mapper = mapper;
        }

        [HttpGet]
        //[Authorize]
        [MapToApiVersion("1.0")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<DepartamentoDto>>> Get(){
            var records = await _UnitOfWork.Departamentos!.GetAllAsync();
            return _Mapper.Map<List<DepartamentoDto>>(records);
        }
        
        [HttpGet]
        [MapToApiVersion("1.1")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Pager<DepartamentoComplemetsDto>>> Get11([FromQuery] Params citaParams)
        {
            var cita = await _UnitOfWork.Departamentos!.GetAllAsync(citaParams.PageIndex,citaParams.PageSize,citaParams.Search);
            var lstcitasDto = _Mapper.Map<List<DepartamentoComplemetsDto>>(cita.registros);
            return new Pager<DepartamentoComplemetsDto>(lstcitasDto,cita.totalRegistros,citaParams.PageIndex,citaParams.PageSize,citaParams.Search);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<DepartamentoComplemetsDto>> Get(string id)
        {
            var record = await _UnitOfWork.Departamentos!.GetByIdAsync(id);
            if (record == null){
                return NotFound();
            }
            return _Mapper.Map<DepartamentoComplemetsDto>(record);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Departamento>> Post(DepartamentoComplemetsDto departamentoDto){
            var record = _Mapper.Map<Departamento>(departamentoDto);
            _UnitOfWork.Departamentos!.Add(record);
            await _UnitOfWork.SaveAsync();
            if (record == null)
            {
                return BadRequest();
            }
            departamentoDto.Id = record.Id;
            return CreatedAtAction(nameof(Post),new {id= departamentoDto.Id}, departamentoDto);
        }

        
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<DepartamentoDto>> Put(string id, [FromBody]DepartamentoDto recordDto){
            if(recordDto == null)
                return NotFound();
            var records = _Mapper.Map<Departamento>(recordDto);
            _UnitOfWork.Departamentos!.Update(records);
            await _UnitOfWork.SaveAsync();
            return recordDto;
            
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(string id){
            var record = await _UnitOfWork.Citas!.GetByIdAsync(id);
            if(record == null){
                return NotFound();
            }
            _UnitOfWork.Citas.Remove(record);
            await _UnitOfWork.SaveAsync();
            return NoContent();
        }
    }
