using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvaluacionDesempeno.Domain.Entities
{
    public class ModeloEvaluativo
    {
        public int Id { get; set; }
        public string NombreModelo { get; set; }

        public ICollection<Cargo> Cargos { get; set; }
    }
}
