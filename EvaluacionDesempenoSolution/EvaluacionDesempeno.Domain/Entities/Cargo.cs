using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvaluacionDesempeno.Domain.Entities
{
    public class Cargo
    {
        public int Id { get; set; }
        public string NombreCargo { get; set; }

        public int ModeloEvaluativoId { get; set; }
        public ModeloEvaluativo ModeloEvaluativo { get; set; }

        public ICollection<Colaborador> Colaboradores { get; set; }
        public ICollection<Cuestionario> Cuestionarios { get; set; }
    }
}
