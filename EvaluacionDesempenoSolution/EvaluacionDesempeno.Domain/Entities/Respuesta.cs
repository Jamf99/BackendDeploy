using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvaluacionDesempeno.Domain.Entities
{
    public class Respuesta
    {
        public int Id { get; set; }

        public int EvaluacionId { get; set; }
        public Evaluacion Evaluacion { get; set; }

        public int CuestionarioId { get; set; }
        public Cuestionario Cuestionario { get; set; }

        public int Calificacion { get; set; }
        public string Comentario { get; set; }
    }
}
