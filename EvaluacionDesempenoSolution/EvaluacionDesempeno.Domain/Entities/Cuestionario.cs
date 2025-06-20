using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvaluacionDesempeno.Domain.Entities
{
    public class Cuestionario
    {
        public int Id { get; set; }
        public int CargoId { get; set; }
        public string Pregunta { get; set; }

        public Cargo Cargo { get; set; }
        public ICollection<Respuesta> Respuestas { get; set; }
    }
}
