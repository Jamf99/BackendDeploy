namespace EvaluacionDesempeno.Domain.Dtos
{
    public class EvaluacionDto
    {
        public int GrupoEvaluativoId { get; set; }
        public int ColaboradorId { get; set; }
        public int EvaluadorId { get; set; }
        public DateTime Fecha { get; set; }
    }
}
