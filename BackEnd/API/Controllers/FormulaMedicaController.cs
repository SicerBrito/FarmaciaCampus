using API.Dtos;
using API.Dtos.FormulaMedica;
using API.Helpers;
using AutoMapper;
using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

    [ApiVersion("1.0")]
    [ApiVersion("1.1")]
    public class FormulaMedicaController : BaseApiController{
                        
        private readonly IUnitOfWork _UnitOfWork;
        private readonly IMapper _Mapper;
        
        public FormulaMedicaController(IUnitOfWork unitOfWork,IMapper mapper){
            _UnitOfWork = unitOfWork;
            _Mapper = mapper;
        }

        [HttpGet]
        //[Authorize]
        [MapToApiVersion("1.0")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<FormulaMedicaDto>>> Get(){
            var records = await _UnitOfWork.FormulasMedicas!.GetAllAsync();
            return _Mapper.Map<List<FormulaMedicaDto>>(records);
        }
        
        [HttpGet]
        [MapToApiVersion("1.1")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Pager<FormulaMedicaComplementsDto>>> Get11([FromQuery] Params recordParams)
        {
            var record = await _UnitOfWork.FormulasMedicas!.GetAllAsync(recordParams.PageIndex,recordParams.PageSize,recordParams.Search);
            var lstrecordsDto = _Mapper.Map<List<FormulaMedicaComplementsDto>>(record.registros);
            return new Pager<FormulaMedicaComplementsDto>(lstrecordsDto,record.totalRegistros,recordParams.PageIndex,recordParams.PageSize,recordParams.Search);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<FormulaMedicaComplementsDto>> Get(string id)
        {
            var record = await _UnitOfWork.FormulasMedicas!.GetByIdAsync(id);
            if (record == null){
                return NotFound();
            }
            return _Mapper.Map<FormulaMedicaComplementsDto>(record);
        }

        //! Consulta Nro.4
        [HttpGet("recetasDespuesDe2023")]
        public async Task<ActionResult<List<FormulaMedica>>> ObtenerRecetasDespuesDe2023()
        {
            var recetas = await _UnitOfWork.FormulasMedicas!.ObtenerRecetasMedicasEmitidasDespuesDe2023();
            return Ok(recetas);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<FormulaMedica>> Post(FormulaMedicaComplementsDto recordDto){
            var record = _Mapper.Map<FormulaMedica>(recordDto);
            _UnitOfWork.FormulasMedicas!.Add(record);
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
        public async Task<ActionResult<FormulaMedicaDto>> Put(string id, [FromBody]FormulaMedicaDto recordDto){
            if(recordDto == null)
                return NotFound();
            var records = _Mapper.Map<FormulaMedica>(recordDto);
            _UnitOfWork.FormulasMedicas!.Update(records);
            await _UnitOfWork.SaveAsync();
            return recordDto;
            
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(string id){
            var record = await _UnitOfWork.FormulasMedicas!.GetByIdAsync(id);
            if(record == null){
                return NotFound();
            }
            _UnitOfWork.FormulasMedicas.Remove(record);
            await _UnitOfWork.SaveAsync();
            return NoContent();
        }
        
    }
