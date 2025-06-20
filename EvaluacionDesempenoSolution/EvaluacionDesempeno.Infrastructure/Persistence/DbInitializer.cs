using EvaluacionDesempeno.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvaluacionDesempeno.Infrastructure.Persistence
{
    public static class DbInitializer
    {
        public static void Seed(AppDbContext context)
        {
            if (!context.CiclosEvaluativos.Any())
            {
                // Modelos
                var modelo90 = new ModeloEvaluativo { NombreModelo = "90°" };
                var modelo180 = new ModeloEvaluativo { NombreModelo = "180°" };
                var modelo360 = new ModeloEvaluativo { NombreModelo = "360°" };
                context.ModelosEvaluativos.AddRange(modelo90, modelo180, modelo360);
                context.SaveChanges();

                // Cargos
                var cargoDev = new Cargo { NombreCargo = "Desarrollador", ModeloEvaluativoId = modelo360.Id };
                var cargoQA = new Cargo { NombreCargo = "QA", ModeloEvaluativoId = modelo180.Id };
                var cargoPM = new Cargo { NombreCargo = "Project Manager", ModeloEvaluativoId = modelo90.Id };
                context.Cargos.AddRange(cargoDev, cargoQA, cargoPM);
                context.SaveChanges();

                // Ciclos
                var ciclo2024 = new CicloEvaluativo
                {
                    Anio = 2024,
                    FechaInicio = DateTime.Now.AddMonths(-1),
                    FechaFin = DateTime.Now.AddMonths(2)
                };
                var ciclo2023 = new CicloEvaluativo
                {
                    Anio = 2023,
                    FechaInicio = DateTime.Now.AddMonths(-6),
                    FechaFin = DateTime.Now.AddMonths(-3)
                };
                context.CiclosEvaluativos.AddRange(ciclo2024, ciclo2023);
                context.SaveChanges();

                // Grupos
                var grupoA = new GrupoEvaluativo
                {
                    NombreGrupo = "Grupo A",
                    CicloEvaluativoId = ciclo2024.Id,
                    FechaInicio = DateTime.Now.AddDays(-10),
                    FechaFin = DateTime.Now.AddDays(20)
                };
                var grupoB = new GrupoEvaluativo
                {
                    NombreGrupo = "Grupo B",
                    CicloEvaluativoId = ciclo2023.Id,
                    FechaInicio = DateTime.Now.AddMonths(-5),
                    FechaFin = DateTime.Now.AddMonths(-4)
                };
                context.GruposEvaluativos.AddRange(grupoA, grupoB);
                context.SaveChanges();

                // Cuestionarios
                var pregunta1 = new Cuestionario { Pregunta = "Calidad de trabajo", CargoId = cargoDev.Id };
                var pregunta2 = new Cuestionario { Pregunta = "Comunicación", CargoId = cargoDev.Id };
                var pregunta3 = new Cuestionario { Pregunta = "Liderazgo", CargoId = cargoPM.Id };
                var pregunta4 = new Cuestionario { Pregunta = "Detalle y precisión", CargoId = cargoQA.Id };
                context.Cuestionarios.AddRange(pregunta1, pregunta2, pregunta3, pregunta4);
                context.SaveChanges();

                // Colaboradores
                var dev = new Colaborador { Nombre = "Ana Dev", CargoId = cargoDev.Id };
                var qa = new Colaborador { Nombre = "Luis QA", CargoId = cargoQA.Id };
                var pm = new Colaborador { Nombre = "Carlos PM", CargoId = cargoPM.Id };
                context.Colaboradores.AddRange(dev, qa, pm);
                context.SaveChanges();

                // Evaluaciones 360° (Desarrollador)
                var eval360 = new Evaluacion
                {
                    GrupoEvaluativoId = grupoA.Id,
                    ColaboradorId = dev.Id,
                    EvaluadorId = dev.Id, // Autoevaluación
                    Fecha = DateTime.Now
                };
                context.Evaluaciones.Add(eval360);
                context.SaveChanges();

                var resp360_1 = new Respuesta
                {
                    EvaluacionId = eval360.Id,
                    CuestionarioId = pregunta1.Id,
                    Calificacion = 4,
                    Comentario = "Buen trabajo"
                };
                var resp360_2 = new Respuesta
                {
                    EvaluacionId = eval360.Id,
                    CuestionarioId = pregunta2.Id,
                    Calificacion = 5,
                    Comentario = "Excelente comunicación"
                };
                context.Respuestas.AddRange(resp360_1, resp360_2);
                context.SaveChanges();

                // Evaluaciones 180° (QA)
                var eval180 = new Evaluacion
                {
                    GrupoEvaluativoId = grupoA.Id,
                    ColaboradorId = qa.Id,
                    EvaluadorId = pm.Id, // Jefe
                    Fecha = DateTime.Now
                };
                context.Evaluaciones.Add(eval180);
                context.SaveChanges();

                var resp180 = new Respuesta
                {
                    EvaluacionId = eval180.Id,
                    CuestionarioId = pregunta4.Id,
                    Calificacion = 4,
                    Comentario = "Preciso en los detalles"
                };
                context.Respuestas.Add(resp180);
                context.SaveChanges();

                // Evaluaciones 90° (PM)
                var eval90 = new Evaluacion
                {
                    GrupoEvaluativoId = grupoA.Id,
                    ColaboradorId = pm.Id,
                    EvaluadorId = pm.Id, // Auto
                    Fecha = DateTime.Now
                };
                context.Evaluaciones.Add(eval90);
                context.SaveChanges();

                var resp90 = new Respuesta
                {
                    EvaluacionId = eval90.Id,
                    CuestionarioId = pregunta3.Id,
                    Calificacion = 5,
                    Comentario = "Buen liderazgo"
                };
                context.Respuestas.Add(resp90);
                context.SaveChanges();
            }
        }
    }
}
