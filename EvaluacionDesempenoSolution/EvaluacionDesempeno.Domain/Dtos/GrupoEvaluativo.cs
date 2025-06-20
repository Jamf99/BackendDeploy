namespace EvaluacionDesempeno.Domain.Dtos
{
    public class GrupoEvaluativoDto
    {
        public int CicloEvaluativoId { get; set; }
        public string NombreGrupo { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
    }
}
