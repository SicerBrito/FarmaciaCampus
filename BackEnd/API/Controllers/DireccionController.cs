using API.Dtos;
using API.Dtos.Direccion;
using API.Helpers;
using AutoMapper;
using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

    [ApiVersion("1.0")]
    [ApiVersion("1.1")]
    public class DireccionController : BaseApiController{
                
        private readonly IUnitOfWork _UnitOfWork;
        private readonly IMapper _Mapper;
        
        public DireccionController(IUnitOfWork unitOfWork,IMapper mapper){
            _UnitOfWork = unitOfWork;
            _Mapper = mapper;
        }

        [HttpGet]
        //[Authorize]
        [MapToApiVersion("1.0")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<DireccionDto>>> Get(){
            var records = await _UnitOfWork.Direcciones!.GetAllAsync();
            return _Mapper.Map<List<DireccionDto>>(records);
        }
        
        [HttpGet]
        [MapToApiVersion("1.1")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Pager<DireccionComplementsDto>>> Get11([FromQuery] Params recordParams)
        {
            var record = await _UnitOfWork.Direcciones!.GetAllAsync(recordParams.PageIndex,recordParams.PageSize,recordParams.Search);
            var lstrecordsDto = _Mapper.Map<List<DireccionComplementsDto>>(record.registros);
            return new Pager<DireccionComplementsDto>(lstrecordsDto,record.totalRegistros,recordParams.PageIndex,recordParams.PageSize,recordParams.Search);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<DireccionComplementsDto>> Get(string id)
        {
            var record = await _UnitOfWork.Direcciones!.GetByIdAsync(id);
            if (record == null){
                return NotFound();
            }
            return _Mapper.Map<DireccionComplementsDto>(record);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Direccion>> Post(DireccionComplementsDto recordDto){
            var record = _Mapper.Map<Direccion>(recordDto);
            _UnitOfWork.Direcciones!.Add(record);
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
        public async Task<ActionResult<DireccionDto>> Put(string id, [FromBody]DireccionDto recordDto){
            if(recordDto == null)
                return NotFound();
            var records = _Mapper.Map<Direccion>(recordDto);
            _UnitOfWork.Direcciones!.Update(records);
            await _UnitOfWork.SaveAsync();
            return recordDto;
            
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(string id){
            var record = await _UnitOfWork.Direcciones!.GetByIdAsync(id);
            if(record == null){
                return NotFound();
            }
            _UnitOfWork.Direcciones.Remove(record);
            await _UnitOfWork.SaveAsync();
            return NoContent();
        }
        
    }
