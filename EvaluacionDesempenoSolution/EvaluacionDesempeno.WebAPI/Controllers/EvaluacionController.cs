using EvaluacionDesempeno.Application.Interfaces;
using EvaluacionDesempeno.Domain.Entities;
using EvaluacionDesempeno.Domain.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace EvaluacionDesempeno.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EvaluacionController : ControllerBase
    {
        private readonly IEvaluacionService _service;

        public EvaluacionController(IEvaluacionService service) => _service = service;

        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _service.GetAllAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var item = await _service.GetByIdAsync(id);
            return item == null ? NotFound() : Ok(item);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] EvaluacionDto dto)
        {
            var entity = new Evaluacion
            {
                GrupoEvaluativoId = dto.GrupoEvaluativoId,
                ColaboradorId = dto.ColaboradorId,
                EvaluadorId = dto.EvaluadorId,
                Fecha = dto.Fecha
            };
            await _service.AddAsync(entity);
            return Ok(entity);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] EvaluacionDto dto)
        {
            var entity = await _service.GetByIdAsync(id);
            if (entity == null) return NotFound();

            entity.GrupoEvaluativoId = dto.GrupoEvaluativoId;
            entity.ColaboradorId = dto.ColaboradorId;
            entity.EvaluadorId = dto.EvaluadorId;
            entity.Fecha = dto.Fecha;

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
