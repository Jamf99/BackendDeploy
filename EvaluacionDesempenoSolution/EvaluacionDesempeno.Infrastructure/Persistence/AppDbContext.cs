using EvaluacionDesempeno.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace EvaluacionDesempeno.Infrastructure.Persistence
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<CicloEvaluativo> CiclosEvaluativos { get; set; }
        public DbSet<GrupoEvaluativo> GruposEvaluativos { get; set; }
        public DbSet<ModeloEvaluativo> ModelosEvaluativos { get; set; }
        public DbSet<Cargo> Cargos { get; set; }
        public DbSet<Cuestionario> Cuestionarios { get; set; }
        public DbSet<Colaborador> Colaboradores { get; set; }
        public DbSet<Evaluacion> Evaluaciones { get; set; }
        public DbSet<Respuesta> Respuestas { get; set; }
    

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<GrupoEvaluativo>()
                .HasOne(g => g.CicloEvaluativo)
                .WithMany(c => c.GruposEvaluativos)
                .HasForeignKey(g => g.CicloEvaluativoId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Evaluacion>()
                .HasOne(e => e.GrupoEvaluativo)
                .WithMany(g => g.Evaluaciones)
                .HasForeignKey(e => e.GrupoEvaluativoId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Respuesta>()
                .HasOne(r => r.Evaluacion)
                .WithMany(e => e.Respuestas)
                .HasForeignKey(r => r.EvaluacionId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Cargo>()
                .HasOne(c => c.ModeloEvaluativo)
                .WithMany(m => m.Cargos)
                .HasForeignKey(c => c.ModeloEvaluativoId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Cuestionario>()
                .HasOne(q => q.Cargo)
                .WithMany(c => c.Cuestionarios)
                .HasForeignKey(q => q.CargoId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Colaborador>()
                .HasOne(c => c.Cargo)
                .WithMany(cg => cg.Colaboradores)
                .HasForeignKey(c => c.CargoId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Evaluacion>()
                .HasOne(e => e.Colaborador)
                .WithMany(c => c.Evaluaciones)
                .HasForeignKey(e => e.ColaboradorId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Respuesta>()
                .HasOne(r => r.Cuestionario)
                .WithMany(c => c.Respuestas)
                .HasForeignKey(r => r.CuestionarioId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
