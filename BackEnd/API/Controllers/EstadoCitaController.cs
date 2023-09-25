using API.Dtos;
using AutoMapper;
using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

    [ApiVersion("1.0")]
    [ApiVersion("1.1")]
    public class EstadoCitaController : BaseApiController{
        private readonly IUnitOfWork _UnitOfWork;
        private readonly IMapper _Mapper;
        
        public EstadoCitaController(IUnitOfWork unitOfWork,IMapper mapper){
            _UnitOfWork = unitOfWork;
            _Mapper = mapper;
        }

        [HttpGet]
        //[Authorize]
        [MapToApiVersion("1.0")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<EstadoCitaDto>>> Get(){
            var records = await _UnitOfWork.EstadoCitas!.GetAllAsync();
            return _Mapper.Map<List<EstadoCitaDto>>(records);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<EstadoCitaDto>> Get(string id)
        {
            var record = await _UnitOfWork.EstadoCitas!.GetByIdAsync(id);
            if (record == null){
                return NotFound();
            }
            return _Mapper.Map<EstadoCitaDto>(record);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<EstadoCita>> Post(EstadoCitaDto estadoCitaDto){
            var record = _Mapper.Map<EstadoCita>(estadoCitaDto);
            _UnitOfWork.EstadoCitas!.Add(record);
            await _UnitOfWork.SaveAsync();
            if (record == null)
            {
                return BadRequest();
            }
            estadoCitaDto.Id = record.Id;
            return CreatedAtAction(nameof(Post),new {id= estadoCitaDto.Id}, estadoCitaDto);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<EstadoCitaDto>> Put(string id, [FromBody]EstadoCitaDto recordDto){
            if(recordDto == null)
                return NotFound();
            var records = _Mapper.Map<EstadoCita>(recordDto);
            _UnitOfWork.EstadoCitas!.Update(records);
            await _UnitOfWork.SaveAsync();
            return recordDto;
            
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(string id){
            var record = await _UnitOfWork.EstadoCitas!.GetByIdAsync(id);
            if(record == null){
                return NotFound();
            }
            _UnitOfWork.EstadoCitas.Remove(record);
            await _UnitOfWork.SaveAsync();
            return NoContent();
        }

    }
