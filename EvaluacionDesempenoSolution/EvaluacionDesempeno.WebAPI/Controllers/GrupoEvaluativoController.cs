using EvaluacionDesempeno.Application.Interfaces;
using EvaluacionDesempeno.Domain.Entities;
using EvaluacionDesempeno.Domain.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace EvaluacionDesempeno.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GrupoEvaluativoController : ControllerBase
    {
        private readonly IGrupoEvaluativoService _service;

        public GrupoEvaluativoController(IGrupoEvaluativoService service) => _service = service;

        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _service.GetAllAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var item = await _service.GetByIdAsync(id);
            return item == null ? NotFound() : Ok(item);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] GrupoEvaluativoDto dto)
        {
            var entity = new GrupoEvaluativo
            {
                CicloEvaluativoId = dto.CicloEvaluativoId,
                NombreGrupo = dto.NombreGrupo,
                FechaInicio = dto.FechaInicio,
                FechaFin = dto.FechaFin
            };

            await _service.AddAsync(entity);
            return Ok(entity);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] GrupoEvaluativoDto dto)
        {
            var entity = await _service.GetByIdAsync(id);
            if (entity == null) return NotFound();

            entity.CicloEvaluativoId = dto.CicloEvaluativoId;
            entity.NombreGrupo = dto.NombreGrupo;
            entity.FechaInicio = dto.FechaInicio;
            entity.FechaFin = dto.FechaFin;

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
