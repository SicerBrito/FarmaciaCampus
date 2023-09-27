using API.Dtos;
using API.Dtos.HistorialMedico;
using API.Helpers;
using AutoMapper;
using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

    [ApiVersion("1.0")]
    [ApiVersion("1.1")]
    public class HistorialMedicoController : BaseApiController{
                        
        private readonly IUnitOfWork _UnitOfWork;
        private readonly IMapper _Mapper;
        
        public HistorialMedicoController(IUnitOfWork unitOfWork,IMapper mapper){
            _UnitOfWork = unitOfWork;
            _Mapper = mapper;
        }

        [HttpGet]
        //[Authorize]
        [MapToApiVersion("1.0")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<HistorialMedicoDto>>> Get(){
            var records = await _UnitOfWork.HistorialesMedicos!.GetAllAsync();
            return _Mapper.Map<List<HistorialMedicoDto>>(records);
        }
        
        [HttpGet]
        [MapToApiVersion("1.1")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Pager<HistorialMedicoComplementsDto>>> Get11([FromQuery] Params recordParams)
        {
            var record = await _UnitOfWork.HistorialesMedicos!.GetAllAsync(recordParams.PageIndex,recordParams.PageSize,recordParams.Search);
            var lstrecordsDto = _Mapper.Map<List<HistorialMedicoComplementsDto>>(record.registros);
            return new Pager<HistorialMedicoComplementsDto>(lstrecordsDto,record.totalRegistros,recordParams.PageIndex,recordParams.PageSize,recordParams.Search);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<HistorialMedicoComplementsDto>> Get(string id)
        {
            var record = await _UnitOfWork.HistorialesMedicos!.GetByIdAsync(id);
            if (record == null){
                return NotFound();
            }
            return _Mapper.Map<HistorialMedicoComplementsDto>(record);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<HistorialMedico>> Post(HistorialMedicoComplementsDto recordDto){
            var record = _Mapper.Map<HistorialMedico>(recordDto);
            _UnitOfWork.HistorialesMedicos!.Add(record);
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
        public async Task<ActionResult<HistorialMedicoDto>> Put(string id, [FromBody]HistorialMedicoDto recordDto){
            if(recordDto == null)
                return NotFound();
            var records = _Mapper.Map<HistorialMedico>(recordDto);
            _UnitOfWork.HistorialesMedicos!.Update(records);
            await _UnitOfWork.SaveAsync();
            return recordDto;
            
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(string id){
            var record = await _UnitOfWork.HistorialesMedicos!.GetByIdAsync(id);
            if(record == null){
                return NotFound();
            }
            _UnitOfWork.HistorialesMedicos.Remove(record);
            await _UnitOfWork.SaveAsync();
            return NoContent();
        }
        
    }
