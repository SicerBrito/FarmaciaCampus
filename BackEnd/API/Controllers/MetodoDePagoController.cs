using API.Dtos;
using AutoMapper;
using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

    [ApiVersion("1.0")]
    [ApiVersion("1.1")]
    public class MetodoDePagoController : BaseApiController{
                        
        private readonly IUnitOfWork _UnitOfWork;
        private readonly IMapper _Mapper;
        
        public MetodoDePagoController(IUnitOfWork unitOfWork,IMapper mapper){
            _UnitOfWork = unitOfWork;
            _Mapper = mapper;
        }

        [HttpGet]
        //[Authorize]
        [MapToApiVersion("1.0")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<MetodoDePagoDto>>> Get(){
            var records = await _UnitOfWork.MetodosDePagos!.GetAllAsync();
            return _Mapper.Map<List<MetodoDePagoDto>>(records);
        }
        

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<MetodoDePagoDto>> Get(string id)
        {
            var record = await _UnitOfWork.MetodosDePagos!.GetByIdAsync(id);
            if (record == null){
                return NotFound();
            }
            return _Mapper.Map<MetodoDePagoDto>(record);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<MetodoDePago>> Post(MetodoDePagoDto recordDto){
            var record = _Mapper.Map<MetodoDePago>(recordDto);
            _UnitOfWork.MetodosDePagos!.Add(record);
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
        public async Task<ActionResult<MetodoDePagoDto>> Put(string id, [FromBody]MetodoDePagoDto recordDto){
            if(recordDto == null)
                return NotFound();
            var records = _Mapper.Map<MetodoDePago>(recordDto);
            _UnitOfWork.MetodosDePagos!.Update(records);
            await _UnitOfWork.SaveAsync();
            return recordDto;
            
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(string id){
            var record = await _UnitOfWork.MetodosDePagos!.GetByIdAsync(id);
            if(record == null){
                return NotFound();
            }
            _UnitOfWork.MetodosDePagos.Remove(record);
            await _UnitOfWork.SaveAsync();
            return NoContent();
        }
        
    }
