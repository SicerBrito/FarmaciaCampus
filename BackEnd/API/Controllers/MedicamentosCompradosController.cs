using API.Dtos;
using API.Dtos.Medicamento;
using API.Helpers;
using AutoMapper;
using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

    [ApiVersion("1.0")]
    [ApiVersion("1.1")]
    public class MedicamentosCompradosController : BaseApiController{
                        
        private readonly IUnitOfWork _UnitOfWork;
        private readonly IMapper _Mapper;
        
        public MedicamentosCompradosController(IUnitOfWork unitOfWork,IMapper mapper){
            _UnitOfWork = unitOfWork;
            _Mapper = mapper;
        }

        [HttpGet]
        //[Authorize]
        [MapToApiVersion("1.0")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<MedicamentosCompradosDto>>> Get(){
            var records = await _UnitOfWork.MedicamentosComprados!.GetAllAsync();
            return _Mapper.Map<List<MedicamentosCompradosDto>>(records);
        }
        
        [HttpGet]
        [MapToApiVersion("1.1")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Pager<MedicamentosCompradosComplementsDto>>> Get11([FromQuery] Params recordParams)
        {
            var record = await _UnitOfWork.MedicamentosComprados!.GetAllAsync(recordParams.PageIndex,recordParams.PageSize,recordParams.Search);
            var lstrecordsDto = _Mapper.Map<List<MedicamentosCompradosComplementsDto>>(record.registros);
            return new Pager<MedicamentosCompradosComplementsDto>(lstrecordsDto,record.totalRegistros,recordParams.PageIndex,recordParams.PageSize,recordParams.Search);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<MedicamentosCompradosComplementsDto>> Get(string id)
        {
            var record = await _UnitOfWork.MedicamentosComprados!.GetByIdAsync(id);
            if (record == null){
                return NotFound();
            }
            return _Mapper.Map<MedicamentosCompradosComplementsDto>(record);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<MedicamentosComprados>> Post(MedicamentosCompradosDto recordDto){
            var record = _Mapper.Map<MedicamentosComprados>(recordDto);
            _UnitOfWork.MedicamentosComprados!.Add(record);
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
        public async Task<ActionResult<MedicamentosCompradosDto>> Put(string id, [FromBody]MedicamentosCompradosDto recordDto){
            if(recordDto == null)
                return NotFound();
            var records = _Mapper.Map<MedicamentosComprados>(recordDto);
            _UnitOfWork.MedicamentosComprados!.Update(records);
            await _UnitOfWork.SaveAsync();
            return recordDto;
            
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(string id){
            var record = await _UnitOfWork.MedicamentosComprados!.GetByIdAsync(id);
            if(record == null){
                return NotFound();
            }
            _UnitOfWork.MedicamentosComprados.Remove(record);
            await _UnitOfWork.SaveAsync();
            return NoContent();
        }
        
    }