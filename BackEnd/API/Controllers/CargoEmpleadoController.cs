using API.Dtos;
using AutoMapper;
using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

    [ApiVersion("1.0")]
    [ApiVersion("1.1")]
    public class CargoEmpleadoController : BaseApiController{
        
        private readonly IUnitOfWork _UnitOfWork;
        private readonly IMapper _Mapper;
        
        public CargoEmpleadoController(IUnitOfWork unitOfWork,IMapper mapper){
            _UnitOfWork = unitOfWork;
            _Mapper = mapper;
        }

        [HttpGet]
        //[Authorize]
        [MapToApiVersion("1.0")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<CargoEmpleadoDto>>> Get(){
            var records = await _UnitOfWork.CargoEmpleados!.GetAllAsync();
            return _Mapper.Map<List<CargoEmpleadoDto>>(records);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<CargoEmpleadoDto>> Get(string id)
        {
            var record = await _UnitOfWork.CargoEmpleados!.GetByIdAsync(id);
            if (record == null){
                return NotFound();
            }
            return _Mapper.Map<CargoEmpleadoDto>(record);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<CargoEmpleado>> Post(CargoEmpleadoDto cargoEmpleadoDto){
            var record = _Mapper.Map<CargoEmpleado>(cargoEmpleadoDto);
            _UnitOfWork.CargoEmpleados!.Add(record);
            await _UnitOfWork.SaveAsync();
            if (record == null)
            {
                return BadRequest();
            }
            cargoEmpleadoDto.IdCargo = record.Id;
            return CreatedAtAction(nameof(Post),new {id= cargoEmpleadoDto.IdCargo}, cargoEmpleadoDto);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<CargoEmpleadoDto>> Put(string id, [FromBody]CargoEmpleadoDto recordDto){
            if(recordDto == null)
                return NotFound();
            var records = _Mapper.Map<CargoEmpleado>(recordDto);
            _UnitOfWork.CargoEmpleados!.Update(records);
            await _UnitOfWork.SaveAsync();
            return recordDto;
            
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(string id){
            var record = await _UnitOfWork.CargoEmpleados!.GetByIdAsync(id);
            if(record == null){
                return NotFound();
            }
            _UnitOfWork.CargoEmpleados.Remove(record);
            await _UnitOfWork.SaveAsync();
            return NoContent();
        }

    }
