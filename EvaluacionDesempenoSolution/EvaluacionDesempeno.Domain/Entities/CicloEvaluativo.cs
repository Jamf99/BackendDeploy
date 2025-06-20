using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvaluacionDesempeno.Domain.Entities
{
    public class CicloEvaluativo
    {
        public int Id { get; set; }
        public int Anio { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }

        public ICollection<GrupoEvaluativo> GruposEvaluativos { get; set; }
    }
}
