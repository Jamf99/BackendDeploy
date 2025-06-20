using EvaluacionDesempeno.Domain.Dtos;

namespace EvaluacionDesempeno.Application.Interfaces
{
    public interface IReporteService
    {
        List<ReporteCargoDto> GenerarReportePorCiclo(int cicloId);
    }
}
