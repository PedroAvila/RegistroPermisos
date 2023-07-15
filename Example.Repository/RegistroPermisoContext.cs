using Example.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Example.Repository
{
    public class RegistroPermisoContext : DbContext
    {
        public RegistroPermisoContext(DbContextOptions<RegistroPermisoContext> options) : base(options) { }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PermisoMap());
            modelBuilder.ApplyConfiguration(new TipoPermisoMap());
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Permiso>? Permisos { get; set; }
        public DbSet<TipoPermiso>? TipoPermisos { get; set; }

    }
}
