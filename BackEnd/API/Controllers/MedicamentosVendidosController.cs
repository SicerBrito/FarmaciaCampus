using API.Dtos.MedicamentosVendidos;
using API.Helpers;
using AutoMapper;
using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

    [ApiVersion("1.0")]
    [ApiVersion("1.1")]
    public class MedicamentosVendidosController : BaseApiController{
                        
        private readonly IUnitOfWork _UnitOfWork;
        private readonly IMapper _Mapper;
        
        public MedicamentosVendidosController(IUnitOfWork unitOfWork,IMapper mapper){
            _UnitOfWork = unitOfWork;
            _Mapper = mapper;
        }

        [HttpGet]
        //[Authorize]
        [MapToApiVersion("1.0")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<MedicamentosVendidosDto>>> Get(){
            var records = await _UnitOfWork.MedicamentosVendidos!.GetAllAsync();
            return _Mapper.Map<List<MedicamentosVendidosDto>>(records);
        }
        
        [HttpGet]
        [MapToApiVersion("1.1")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Pager<MedicamentosVendidosComplementsDto>>> Get11([FromQuery] Params recordParams)
        {
            var record = await _UnitOfWork.MedicamentosVendidos!.GetAllAsync(recordParams.PageIndex,recordParams.PageSize,recordParams.Search);
            var lstrecordsDto = _Mapper.Map<List<MedicamentosVendidosComplementsDto>>(record.registros);
            return new Pager<MedicamentosVendidosComplementsDto>(lstrecordsDto,record.totalRegistros,recordParams.PageIndex,recordParams.PageSize,recordParams.Search);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<MedicamentosVendidosComplementsDto>> Get(string id)
        {
            var record = await _UnitOfWork.MedicamentosVendidos!.GetByIdAsync(id);
            if (record == null){
                return NotFound();
            }
            return _Mapper.Map<MedicamentosVendidosComplementsDto>(record);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<MedicamentosVendidos>> Post(MedicamentosVendidosComplementsDto recordDto){
            var record = _Mapper.Map<MedicamentosVendidos>(recordDto);
            _UnitOfWork.MedicamentosVendidos!.Add(record);
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
        public async Task<ActionResult<MedicamentosVendidosDto>> Put(string id, [FromBody]MedicamentosVendidosDto recordDto){
            if(recordDto == null)
                return NotFound();
            var records = _Mapper.Map<MedicamentosVendidos>(recordDto);
            _UnitOfWork.MedicamentosVendidos!.Update(records);
            await _UnitOfWork.SaveAsync();
            return recordDto;
            
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(string id){
            var record = await _UnitOfWork.MedicamentosVendidos!.GetByIdAsync(id);
            if(record == null){
                return NotFound();
            }
            _UnitOfWork.MedicamentosVendidos.Remove(record);
            await _UnitOfWork.SaveAsync();
            return NoContent();
        }
        
    }
