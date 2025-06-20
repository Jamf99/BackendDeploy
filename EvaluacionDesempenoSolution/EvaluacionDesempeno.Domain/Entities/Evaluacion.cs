using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvaluacionDesempeno.Domain.Entities
{
    public class Evaluacion
    {
        public int Id { get; set; }

        public int GrupoEvaluativoId { get; set; }
        public GrupoEvaluativo GrupoEvaluativo { get; set; }

        public int ColaboradorId { get; set; }
        public Colaborador Colaborador { get; set; }

        public int EvaluadorId { get; set; } // podría ser ColaboradorId del evaluador
        public DateTime Fecha { get; set; }

        public ICollection<Respuesta> Respuestas { get; set; }
    }
}
