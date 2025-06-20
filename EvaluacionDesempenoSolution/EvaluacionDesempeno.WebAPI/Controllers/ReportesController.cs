using EvaluacionDesempeno.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EvaluacionDesempeno.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReportesController : ControllerBase
    {
        private readonly IReporteService _reporteService;

        public ReportesController(IReporteService reporteService)
        {
            _reporteService = reporteService;
        }

        [HttpGet("{cicloId}")]
        public IActionResult ObtenerReportePorCiclo(int cicloId)
        {
            var reporte = _reporteService.GenerarReportePorCiclo(cicloId);
            return Ok(reporte);
        }
    }
}
