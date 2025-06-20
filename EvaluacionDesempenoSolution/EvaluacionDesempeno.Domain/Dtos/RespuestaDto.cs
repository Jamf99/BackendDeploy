namespace EvaluacionDesempeno.Domain.Dtos
{
    public class RespuestaDto
    {
        public int EvaluacionId { get; set; }
        public int CuestionarioId { get; set; }
        public int Calificacion { get; set; }
        public string Comentario { get; set; }
    }
}
