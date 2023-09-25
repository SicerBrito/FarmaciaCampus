using API.Dtos;
using AutoMapper;
using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

    [ApiVersion("1.0")]
    [ApiVersion("1.1")]
    public class TipoDireccionController : BaseApiController{
                        
        private readonly IUnitOfWork _UnitOfWork;
        private readonly IMapper _Mapper;
        
        public TipoDireccionController(IUnitOfWork unitOfWork,IMapper mapper){
            _UnitOfWork = unitOfWork;
            _Mapper = mapper;
        }

        [HttpGet]
        //[Authorize]
        [MapToApiVersion("1.0")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<TipoDireccionDto>>> Get(){
            var records = await _UnitOfWork.TipoDirecciones!.GetAllAsync();
            return _Mapper.Map<List<TipoDireccionDto>>(records);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<TipoDireccionDto>> Get(string id)
        {
            var record = await _UnitOfWork.TipoDirecciones!.GetByIdAsync(id);
            if (record == null){
                return NotFound();
            }
            return _Mapper.Map<TipoDireccionDto>(record);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<TipoDireccion>> Post(TipoDireccionDto recordDto){
            var record = _Mapper.Map<TipoDireccion>(recordDto);
            _UnitOfWork.TipoDirecciones!.Add(record);
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
        public async Task<ActionResult<TipoDireccionDto>> Put(string id, [FromBody]TipoDireccionDto recordDto){
            if(recordDto == null)
                return NotFound();
            var records = _Mapper.Map<TipoDireccion>(recordDto);
            _UnitOfWork.TipoDirecciones!.Update(records);
            await _UnitOfWork.SaveAsync();
            return recordDto;
            
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(string id){
            var record = await _UnitOfWork.TipoDirecciones!.GetByIdAsync(id);
            if(record == null){
                return NotFound();
            }
            _UnitOfWork.TipoDirecciones.Remove(record);
            await _UnitOfWork.SaveAsync();
            return NoContent();
        }
        
    }
