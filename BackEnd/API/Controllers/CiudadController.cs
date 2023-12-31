using API.Dtos;
using API.Dtos.Ciudad;
using API.Helpers;
using AutoMapper;
using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

    [ApiVersion("1.0")]
    [ApiVersion("1.1")]
    public class CiudadController : BaseApiController{
        private readonly IUnitOfWork _UnitOfWork;
        private readonly IMapper _Mapper;
        
        public CiudadController(IUnitOfWork unitOfWork,IMapper mapper){
            _UnitOfWork = unitOfWork;
            _Mapper = mapper;
        }

        [HttpGet]
        //[Authorize]
        [MapToApiVersion("1.0")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<CiudadDto>>> Get(){
            var records = await _UnitOfWork.Ciudades!.GetAllAsync();
            return _Mapper.Map<List<CiudadDto>>(records);
        }
        
        [HttpGet]
        [MapToApiVersion("1.1")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Pager<CiudadComplementsDto>>> Get11([FromQuery] Params ciudadParams)
        {
            var ciudad = await _UnitOfWork.Ciudades!.GetAllAsync(ciudadParams.PageIndex,ciudadParams.PageSize,ciudadParams.Search);
            var lstciudadesDto = _Mapper.Map<List<CiudadComplementsDto>>(ciudad.registros);
            return new Pager<CiudadComplementsDto>(lstciudadesDto,ciudad.totalRegistros,ciudadParams.PageIndex,ciudadParams.PageSize,ciudadParams.Search);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<CiudadComplementsDto>> Get(string id)
        {
            var record = await _UnitOfWork.Ciudades!.GetByIdAsync(id);
            if (record == null){
                return NotFound();
            }
            return _Mapper.Map<CiudadComplementsDto>(record);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Ciudad>> Post(CiudadComplementsDto ciudadDto){
            var record = _Mapper.Map<Ciudad>(ciudadDto);
            _UnitOfWork.Ciudades!.Add(record);
            await _UnitOfWork.SaveAsync();
            if (record == null)
            {
                return BadRequest();
            }
            ciudadDto.Id = record.Id;
            return CreatedAtAction(nameof(Post),new {id= ciudadDto.Id}, ciudadDto);
        }


        
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<CiudadDto>> Put(string id, [FromBody]CiudadDto recordDto){
            if(recordDto == null)
                return NotFound();
            var records = _Mapper.Map<Ciudad>(recordDto);
            _UnitOfWork.Ciudades!.Update(records);
            await _UnitOfWork.SaveAsync();
            return recordDto;
            
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(string id){
            var record = await _UnitOfWork.Ciudades!.GetByIdAsync(id);
            if(record == null){
                return NotFound();
            }
            _UnitOfWork.Ciudades.Remove(record);
            await _UnitOfWork.SaveAsync();
            return NoContent();
        }
    }
