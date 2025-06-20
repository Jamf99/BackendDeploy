using EvaluacionDesempeno.Application.Interfaces;
using EvaluacionDesempeno.Domain.Dtos;
using EvaluacionDesempeno.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace EvaluacionDesempeno.Infrastructure.Services
{
    public class ReporteService : IReporteService
    {
        private readonly AppDbContext _context;

        public ReporteService(AppDbContext context)
        {
            _context = context;
        }

        public List<ReporteCargoDto> GenerarReportePorCiclo(int cicloId)
        {
            var reporte = _context.Respuestas
                .Include(r => r.Evaluacion)
                    .ThenInclude(e => e.Colaborador)
                        .ThenInclude(c => c.Cargo)
                .Include(r => r.Evaluacion)
                    .ThenInclude(e => e.GrupoEvaluativo)
                .Where(r => r.Evaluacion.GrupoEvaluativo.CicloEvaluativoId == cicloId)
                .GroupBy(r => r.Evaluacion.Colaborador.Cargo.NombreCargo)
                .Select(g => new ReporteCargoDto
                {
                    Cargo = g.Key,
                    CalificacionPromedio = g.Average(x => x.Calificacion),
                    PersonasEvaluadas = g.Select(x => x.Evaluacion.ColaboradorId).Distinct().Count()
                })
                .ToList();

            return reporte;
        }
    }
}
