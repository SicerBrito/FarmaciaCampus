using API.Dtos;
using API.Dtos.Cita;
using API.Helpers;
using AutoMapper;
using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

    [ApiVersion("1.0")]
    [ApiVersion("1.1")]
    public class CitaController : BaseApiController{
        
        private readonly IUnitOfWork _UnitOfWork;
        private readonly IMapper _Mapper;
        
        public CitaController(IUnitOfWork unitOfWork,IMapper mapper){
            _UnitOfWork = unitOfWork;
            _Mapper = mapper;
        }

        [HttpGet]
        //[Authorize]
        [MapToApiVersion("1.0")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<CitaDto>>> Get(){
            var records = await _UnitOfWork.Citas!.GetAllAsync();
            return _Mapper.Map<List<CitaDto>>(records);
        }
        
        [HttpGet]
        [MapToApiVersion("1.1")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Pager<CitaComplementsDto>>> Get11([FromQuery] Params citaParams)
        {
            var cita = await _UnitOfWork.Citas!.GetAllAsync(citaParams.PageIndex,citaParams.PageSize,citaParams.Search);
            var lstcitasDto = _Mapper.Map<List<CitaComplementsDto>>(cita.registros);
            return new Pager<CitaComplementsDto>(lstcitasDto,cita.totalRegistros,citaParams.PageIndex,citaParams.PageSize,citaParams.Search);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<CitaComplementsDto>> Get(string id)
        {
            var record = await _UnitOfWork.Citas!.GetByIdAsync(id);
            if (record == null){
                return NotFound();
            }
            return _Mapper.Map<CitaComplementsDto>(record);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Cita>> Post(CitaComplementsDto citaDto){
            var record = _Mapper.Map<Cita>(citaDto);
            _UnitOfWork.Citas!.Add(record);
            await _UnitOfWork.SaveAsync();
            if (record == null)
            {
                return BadRequest();
            }
            citaDto.Id = record.Id;
            return CreatedAtAction(nameof(Post),new {id=citaDto.Id}, citaDto);
        }

        
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<CitaDto>> Put(string id, [FromBody]CitaDto recordDto){
            if(recordDto == null)
                return NotFound();
            var records = _Mapper.Map<Cita>(recordDto);
            _UnitOfWork.Citas!.Update(records);
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
