using System.Linq;
using FluentValidation.Results;
using Microsoft.EntityFrameworkCore;
using PP.Permissao.API.Models;
using PP.Permissao.API.Models.Configuration;

namespace PP.Permissao.API.Data
{
    public sealed class PermissaoContext : DbContext {
        public PermissaoContext(DbContextOptions<PermissaoContext> options)
            : base(options) {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            ChangeTracker.AutoDetectChangesEnabled = false;
        }

        public DbSet<Models.Permissao> Permissao { get; set; }
        public DbSet<Tipo> Tipo { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            foreach (var property in modelBuilder.Model.GetEntityTypes().SelectMany(
                e => e.GetProperties().Where(p => p.ClrType == typeof(string))))
                property.SetColumnType("varchar(100)");

            modelBuilder.Entity<Models.Permissao>()
                .HasIndex(c => c.TipoId)
                .HasName("IDX_Tipo");

            modelBuilder.Ignore<ValidationResult>();
            modelBuilder.ApplyConfiguration(new TipoConfiguration());

            foreach (var relationship in modelBuilder.Model.GetEntityTypes()
                .SelectMany(e => e.GetForeignKeys())) relationship.DeleteBehavior = DeleteBehavior.Cascade;
        }
    }
}