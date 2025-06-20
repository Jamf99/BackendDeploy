using EvaluacionDesempeno.Application.Interfaces;
using EvaluacionDesempeno.Domain.Entities;
using EvaluacionDesempeno.Domain.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace EvaluacionDesempeno.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CargoController : ControllerBase
    {
        private readonly ICargoService _service;

        public CargoController(ICargoService service) => _service = service;

        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _service.GetAllAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var item = await _service.GetByIdAsync(id);
            return item == null ? NotFound() : Ok(item);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CargoDto dto)
        {
            var entity = new Cargo
            {
                NombreCargo = dto.NombreCargo,
                ModeloEvaluativoId = dto.ModeloEvaluativoId
            };
            await _service.AddAsync(entity);
            return Ok(entity);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] CargoDto dto)
        {
            var entity = await _service.GetByIdAsync(id);
            if (entity == null) return NotFound();

            entity.NombreCargo = dto.NombreCargo;
            entity.ModeloEvaluativoId = dto.ModeloEvaluativoId;

            await _service.UpdateAsync(entity);
            return Ok(entity);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteAsync(id);
            return Ok();
        }
    }
}
