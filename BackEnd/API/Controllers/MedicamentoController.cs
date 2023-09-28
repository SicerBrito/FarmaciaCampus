using API.Dtos.Medicamento;
using API.Helpers;
using AutoMapper;
using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;

    [ApiVersion("1.0")]
    [ApiVersion("1.1")]
    public class MedicamentoController : BaseApiController{
                        
        private readonly IUnitOfWork _UnitOfWork;
        private readonly IMapper _Mapper;
        
        public MedicamentoController(IUnitOfWork unitOfWork,IMapper mapper){
            _UnitOfWork = unitOfWork;
            _Mapper = mapper;
        }

        [HttpGet]
        //[Authorize]
        [MapToApiVersion("1.0")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<MedicamentoDto>>> Get(){
            var records = await _UnitOfWork.Medicamentos!.GetAllAsync();
            return _Mapper.Map<List<MedicamentoDto>>(records);
        }
        
        [HttpGet]
        [MapToApiVersion("1.1")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Pager<MedicamentoComplementsDto>>> Get11([FromQuery] Params recordParams)
        {
            var record = await _UnitOfWork.Medicamentos!.GetAllAsync(recordParams.PageIndex,recordParams.PageSize,recordParams.Search);
            var lstrecordsDto = _Mapper.Map<List<MedicamentoComplementsDto>>(record.registros);
            return new Pager<MedicamentoComplementsDto>(lstrecordsDto,record.totalRegistros,recordParams.PageIndex,recordParams.PageSize,recordParams.Search);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<MedicamentoComplementsDto>> Get(string id)
        {
            var record = await _UnitOfWork.Medicamentos!.GetByIdAsync(id);
            if (record == null){
                return NotFound();
            }
            return _Mapper.Map<MedicamentoComplementsDto>(record);
        }

        //! Consulta Nro.1
        [HttpGet("stockbajo")]
        [MapToApiVersion("1.0")]
        [MapToApiVersion("1.1")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<List<Medicamento>>> ObtenerMedicamentosConStockBajo()
        {
            var medicamentosConStockBajo = await _UnitOfWork.Medicamentos!
                .GetAllMedicamentos()
                .ToListAsync();

            return medicamentosConStockBajo!;
        }

        //! Consulta Nro.3
        [HttpGet("proveedor/{proveedorId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<List<MedicamentoDto>>> ObtenerMedicamentosCompradosPorProveedorId(int proveedorId)
        {
            try
            {
                var medicamentosProveedor = await _UnitOfWork.Medicamentos!.ObtenerMedicamentosCompradosPorProveedorId(proveedorId);
                var medicamentosDto = _Mapper.Map<List<MedicamentoDto>>(medicamentosProveedor);
                return Ok(medicamentosDto);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error al obtener medicamentos del proveedor: {ex.Message}");
            }
        }

        //! Consulta Nro.6
        [HttpGet("medicamentosCaducanAntesDe2024")]
        public async Task<ActionResult<List<Medicamento>>> ObtenerMedicamentosCaducanAntesDe2024()
        {
            var medicamentos = await _UnitOfWork.Medicamentos!.ObtenerMedicamentosCaducanAntesDe2024();
            return Ok(medicamentos);
        }


        //!Consulta Nro.7
        [HttpGet("medicamentosVendidosPorCadaProveedor")]
        public async Task<ActionResult<IEnumerable<Object>>> ObtenerTotalMedicamentosVendidosPorProveedor()
        {
            var totalMedicamentosPorProveedor = await _UnitOfWork.Medicamentos!.ObtenerTotalMedicamentosVendidosPorProveedor();
            return Ok(totalMedicamentosPorProveedor);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Medicamento>> Post(MedicamentoComplementsDto recordDto){
            var record = _Mapper.Map<Medicamento>(recordDto);
            _UnitOfWork.Medicamentos!.Add(record);
            await _UnitOfWork.SaveAsync();
            if (record == null)
            {
                return BadRequest();
            }
            recordDto.Id = record.Id;
            return CreatedAtAction(nameof(Post),new {id= recordDto.Id}, recordDto);
        }


        // !Consulta Nro.9
        [HttpGet("medicamentosNoVendidos")]
        public async Task<ActionResult<List<Medicamento>>> ObtenerMedicamentosNoVendidos()
        {
            var medicamentos = await _UnitOfWork.Medicamentos!.ObtenerMedicamentosNoVendidos();
            return Ok(medicamentos);
        }

        //! Consulta Nro.10
        [HttpGet("medicamentoMasCaro")]
        public async Task<ActionResult<Medicamento>> ObtenerMedicamentoMasCaro()
        {
            var medicamento = await _UnitOfWork.Medicamentos!.ObtenerMedicamentoMasCaro();
            return Ok(medicamento);
        }


        //! Consulta Nro.11
        [HttpGet("medicamentosPorProveedor")]
        public async Task<ActionResult<Dictionary<string, int>>> ObtenerNumeroMedicamentosPorProveedor()
        {
            var medicamentosPorProveedor = await _UnitOfWork.Medicamentos!.ObtenerNumeroMedicamentosPorProveedor();
            return Ok(medicamentosPorProveedor);
        }


        //! Consulta Nro.19
        [HttpGet("medicamentosExpiranEn2024")]
        public async Task<ActionResult<List<Medicamento>>> ObtenerMedicamentosQueExpiranEn2024()
        {
            var medicamentosEn2024 = await _UnitOfWork.Medicamentos!.ObtenerMedicamentosQueExpiranEn2024();
            return Ok(medicamentosEn2024);
        }

        //! Consulta Nro.21
        [HttpGet("medicamentosNuncaVendidos")]
        public async Task<ActionResult<List<Medicamento>>> ObtenerMedicamentosNuncaVendidos()
        {
            var medicamentosNuncaVendidos = await _UnitOfWork.Medicamentos!.ObtenerMedicamentosNuncaVendidos();
            return Ok(medicamentosNuncaVendidos);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<MedicamentoDto>> Put(string id, [FromBody]MedicamentoDto recordDto){
            if(recordDto == null)
                return NotFound();
            var records = _Mapper.Map<Medicamento>(recordDto);
            _UnitOfWork.Medicamentos!.Update(records);
            await _UnitOfWork.SaveAsync();
            return recordDto;
            
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(string id){
            var record = await _UnitOfWork.Medicamentos!.GetByIdAsync(id);
            if(record == null){
                return NotFound();
            }
            _UnitOfWork.Medicamentos.Remove(record);
            await _UnitOfWork.SaveAsync();
            return NoContent();
        }
        
    }
