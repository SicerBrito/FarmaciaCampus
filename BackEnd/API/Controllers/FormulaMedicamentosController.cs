using API.Dtos;
using API.Dtos.FormulaMedicamento;
using API.Helpers;
using AutoMapper;
using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

    [ApiVersion("1.0")]
    [ApiVersion("1.1")]
    public class FormulaMedicamentosController : BaseApiController{
                        
        private readonly IUnitOfWork _UnitOfWork;
        private readonly IMapper _Mapper;
        
        public FormulaMedicamentosController(IUnitOfWork unitOfWork,IMapper mapper){
            _UnitOfWork = unitOfWork;
            _Mapper = mapper;
        }

        [HttpGet]
        //[Authorize]
        [MapToApiVersion("1.0")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<FormulaMedicamentoDto>>> Get(){
            var records = await _UnitOfWork.FormulaMedicamentos!.GetAllAsync();
            return _Mapper.Map<List<FormulaMedicamentoDto>>(records);
        }
        
        [HttpGet]
        [MapToApiVersion("1.1")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Pager<FormulaMedicamentoComplementsDto>>> Get11([FromQuery] Params recordParams)
        {
            var record = await _UnitOfWork.FormulaMedicamentos!.GetAllAsync(recordParams.PageIndex,recordParams.PageSize,recordParams.Search);
            var lstrecordsDto = _Mapper.Map<List<FormulaMedicamentoComplementsDto>>(record.registros);
            return new Pager<FormulaMedicamentoComplementsDto>(lstrecordsDto,record.totalRegistros,recordParams.PageIndex,recordParams.PageSize,recordParams.Search);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<FormulaMedicamentoComplementsDto>> Get(string id)
        {
            var record = await _UnitOfWork.FormulaMedicamentos!.GetByIdAsync(id);
            if (record == null){
                return NotFound();
            }
            return _Mapper.Map<FormulaMedicamentoComplementsDto>(record);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<FormulaMedicamentos>> Post(FormulaMedicamentoComplementsDto recordDto){
            var record = _Mapper.Map<FormulaMedicamentos>(recordDto);
            _UnitOfWork.FormulaMedicamentos!.Add(record);
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
        public async Task<ActionResult<FormulaMedicamentoDto>> Put(string id, [FromBody]FormulaMedicamentoDto recordDto){
            if(recordDto == null)
                return NotFound();
            var records = _Mapper.Map<FormulaMedicamentos>(recordDto);
            _UnitOfWork.FormulaMedicamentos!.Update(records);
            await _UnitOfWork.SaveAsync();
            return recordDto;
            
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(string id){
            var record = await _UnitOfWork.FormulaMedicamentos!.GetByIdAsync(id);
            if(record == null){
                return NotFound();
            }
            _UnitOfWork.FormulaMedicamentos.Remove(record);
            await _UnitOfWork.SaveAsync();
            return NoContent();
        }
        
    }
