using EvaluacionDesempeno.Application.Interfaces;
using EvaluacionDesempeno.Domain.Entities;
using EvaluacionDesempeno.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvaluacionDesempeno.Infrastructure.Services
{
    public class CicloEvaluativoService : BaseService<CicloEvaluativo>, ICicloEvaluativoService
    {
        public CicloEvaluativoService(AppDbContext context) : base(context)
        {
        }
    }
}
