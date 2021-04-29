using FluentValidation.Results;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using PP.Treino.API.Models;

namespace PP.Treino.API.Data
{
    public sealed class TreinoContext : DbContext {
        public TreinoContext(DbContextOptions<TreinoContext> options)
            : base(options) {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            ChangeTracker.AutoDetectChangesEnabled = false;
        }

        public DbSet<ExercicioTreino> ExercicioTreino { get; set; }
        public DbSet<Exercicio> Exercicio { get; set; }
        public DbSet<Repeticao> Repeticao { get; set; }
        public DbSet<Models.Treino> Treino { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            foreach (var property in modelBuilder.Model.GetEntityTypes().SelectMany(
                e => e.GetProperties().Where(p => p.ClrType == typeof(string))))
                property.SetColumnType("varchar(100)");

            modelBuilder.Ignore<ValidationResult>();

            modelBuilder.Entity<ExercicioTreino>()
                .HasIndex(c => c.TreinoId)
                .HasName("IDX_Treino");

            modelBuilder.Entity<Exercicio>()
                .HasMany(c => c.ExercicioTreino)
                .WithOne(i => i.Exercicio)
                .HasForeignKey(c => c.ExercicioId);

            modelBuilder.Entity<Repeticao>()
                .HasMany(c => c.ExercicioTreino)
                .WithOne(i => i.Repeticao)
                .HasForeignKey(c => c.RepeticaoId);

            modelBuilder.Entity<Models.Treino>()
                .HasMany(c => c.ExercicioTreino)
                .WithOne(i => i.Treino)
                .HasForeignKey(c => c.TreinoId);

            foreach (var relationship in modelBuilder.Model.GetEntityTypes()
                .SelectMany(e => e.GetForeignKeys())) relationship.DeleteBehavior = DeleteBehavior.Cascade;
        }
    }
}