using API.Dtos;
using API.Dtos.Compra;
using API.Helpers;
using AutoMapper;
using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Persistencia.Data.Configuration;

namespace API.Controllers;

    [ApiVersion("1.0")]
    [ApiVersion("1.1")]
    public class CompraController : BaseApiController{
        private readonly IUnitOfWork _UnitOfWork;
        private readonly IMapper _Mapper;
        
        public CompraController(IUnitOfWork unitOfWork,IMapper mapper){
            _UnitOfWork = unitOfWork;
            _Mapper = mapper;
        }

        [HttpGet]
        //[Authorize]
        [MapToApiVersion("1.0")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<CompraDto>>> Get(){
            var records = await _UnitOfWork.Compras!.GetAllAsync();
            return _Mapper.Map<List<CompraDto>>(records);
        }
        
        [HttpGet]
        [MapToApiVersion("1.1")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Pager<CompraConfiguration>>> Get11([FromQuery] Params compraParams)
        {
            var compra = await _UnitOfWork.Compras!.GetAllAsync(compraParams.PageIndex,compraParams.PageSize,compraParams.Search);
            var lstcomprasDto = _Mapper.Map<List<CompraConfiguration>>(compra.registros);
            return new Pager<CompraConfiguration>(lstcomprasDto,compra.totalRegistros,compraParams.PageIndex,compraParams.PageSize,compraParams.Search);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<CompraConfiguration>> Get(string id)
        {
            var record = await _UnitOfWork.Compras!.GetByIdAsync(id);
            if (record == null){
                return NotFound();
            }
            return _Mapper.Map<CompraConfiguration>(record);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Compra>> Post(CompraComplementsDto compraDto){
            var record = _Mapper.Map<Compra>(compraDto);
            _UnitOfWork.Compras!.Add(record);
            await _UnitOfWork.SaveAsync();
            if (record == null)
            {
                return BadRequest();
            }
            compraDto.Id = record.Id;
            return CreatedAtAction(nameof(Post),new {id= compraDto.Id}, compraDto);
        }

        
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<CompraDto>> Put(string id, [FromBody]CompraDto recordDto){
            if(recordDto == null)
                return NotFound();
            var records = _Mapper.Map<Compra>(recordDto);
            _UnitOfWork.Compras!.Update(records);
            await _UnitOfWork.SaveAsync();
            return recordDto;
            
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(string id){
            var record = await _UnitOfWork.Compras!.GetByIdAsync(id);
            if(record == null){
                return NotFound();
            }
            _UnitOfWork.Compras.Remove(record);
            await _UnitOfWork.SaveAsync();
            return NoContent();
        }
    }
