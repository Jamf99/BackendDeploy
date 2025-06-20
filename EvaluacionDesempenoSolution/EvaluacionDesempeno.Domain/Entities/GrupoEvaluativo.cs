using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvaluacionDesempeno.Domain.Entities
{
    public class GrupoEvaluativo
    {
        public int Id { get; set; }
        public int CicloEvaluativoId { get; set; }
        public string NombreGrupo { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }

        public CicloEvaluativo CicloEvaluativo { get; set; }
        public ICollection<Evaluacion> Evaluaciones { get; set; }
    }
}
