using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvaluacionDesempeno.Domain.Entities
{
    public class Colaborador
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        public int CargoId { get; set; }
        public Cargo Cargo { get; set; }

        public ICollection<Evaluacion> Evaluaciones { get; set; }
    }
}
