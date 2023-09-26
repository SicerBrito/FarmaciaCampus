using API.Dtos;
using AutoMapper;
using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.Generic;

    [ApiVersion("1.0")]
    [ApiVersion("1.1")]
    public class CategoriaMedicamentoController : BaseApiController{

        private readonly IUnitOfWork _UnitOfWork;
        private readonly IMapper _Mapper;
        
        public CategoriaMedicamentoController(IUnitOfWork unitOfWork,IMapper mapper){
            _UnitOfWork = unitOfWork;
            _Mapper = mapper;
        }

        [HttpGet]
        //[Authorize]
        [MapToApiVersion("1.0")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<CategoriaMedicamentoDto>>> Get(){
            var records = await _UnitOfWork.CategoriaMedicamentos!.GetAllAsync();
            return _Mapper.Map<List<CategoriaMedicamentoDto>>(records);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<CategoriaMedicamentoDto>> Get(string id)
        {
            var record = await _UnitOfWork.CategoriaMedicamentos!.GetByIdAsync(id);
            if (record == null){
                return NotFound();
            }
            return _Mapper.Map<CategoriaMedicamentoDto>(record);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<CategoriaMedicamento>> Post(CategoriaMedicamentoDto categoriaMedicamentoDto){
            var record = _Mapper.Map<CategoriaMedicamento>(categoriaMedicamentoDto);
            _UnitOfWork.CategoriaMedicamentos!.Add(record);
            await _UnitOfWork.SaveAsync();
            if (record == null)
            {
                return BadRequest();
            }
            categoriaMedicamentoDto.Id = record.Id;
            return CreatedAtAction(nameof(Post),new {id= categoriaMedicamentoDto.Id}, categoriaMedicamentoDto);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<CategoriaMedicamentoDto>> Put(string id, [FromBody]CategoriaMedicamentoDto recordDto){
            if(recordDto == null)
                return NotFound();
            var records = _Mapper.Map<CategoriaMedicamento>(recordDto);
            _UnitOfWork.CategoriaMedicamentos!.Update(records);
            await _UnitOfWork.SaveAsync();
            return recordDto;
            
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(string id){
            var record = await _UnitOfWork.CategoriaMedicamentos!.GetByIdAsync(id);
            if(record == null){
                return NotFound();
            }
            _UnitOfWork.CategoriaMedicamentos.Remove(record);
            await _UnitOfWork.SaveAsync();
            return NoContent();
        }
    }
