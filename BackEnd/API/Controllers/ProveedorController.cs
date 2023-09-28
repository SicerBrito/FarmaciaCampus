using API.Dtos;
using API.Helpers;
using AutoMapper;
using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

    [ApiVersion("1.0")]
    [ApiVersion("1.1")]
    public class ProveedorController : BaseApiController{
                        
        private readonly IUnitOfWork _UnitOfWork;
        private readonly IMapper _Mapper;
        
        public ProveedorController(IUnitOfWork unitOfWork,IMapper mapper){
            _UnitOfWork = unitOfWork;
            _Mapper = mapper;
        }

        [HttpGet]
        //[Authorize]
        [MapToApiVersion("1.0")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<ProveedorDto>>> Get(){
            var records = await _UnitOfWork.Proveedores!.GetAllAsync();
            return _Mapper.Map<List<ProveedorDto>>(records);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ProveedorDto>> Get(string id)
        {
            var record = await _UnitOfWork.Proveedores!.GetByIdAsync(id);
            if (record == null){
                return NotFound();
            }
            return _Mapper.Map<ProveedorDto>(record);
        }

        //! Consulta 
        [HttpGet("proveedoresconmedicamentos")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<List<Proveedor>>> GetProveedoresConMedicamentos()
        {
            var proveedoresConMedicamentos = await _UnitOfWork.Proveedores!.ListarProveedoresConInformacionDeContacto();
            return Ok(proveedoresConMedicamentos);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Proveedor>> Post(ProveedorDto recordDto){
            var record = _Mapper.Map<Proveedor>(recordDto);
            _UnitOfWork.Proveedores!.Add(record);
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
        public async Task<ActionResult<ProveedorDto>> Put(string id, [FromBody]ProveedorDto recordDto){
            if(recordDto == null)
                return NotFound();
            var records = _Mapper.Map<Proveedor>(recordDto);
            _UnitOfWork.Proveedores!.Update(records);
            await _UnitOfWork.SaveAsync();
            return recordDto;
            
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(string id){
            var record = await _UnitOfWork.Proveedores!.GetByIdAsync(id);
            if(record == null){
                return NotFound();
            }
            _UnitOfWork.Proveedores.Remove(record);
            await _UnitOfWork.SaveAsync();
            return NoContent();
        }
        
    }
