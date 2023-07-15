using Example.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Example.Repository
{
    public class PermisoMap : IEntityTypeConfiguration<Permiso>
    {
        public void Configure(EntityTypeBuilder<Permiso> builder)
        {
            builder.ToTable("Permisos");
            builder.HasKey(c => c.Id);
            builder.Property(c=>c.Id).ValueGeneratedOnAdd();

            builder.Property(c=>c.NombreEmpleado).HasMaxLength(250).IsRequired();
            builder.Property(c => c.ApellidoEmpleado).HasMaxLength(250).IsRequired();
            builder.Property(c=>c.TipoPermiso).IsRequired();
            builder.Property(c=>c.FechaPermiso).IsRequired();
        }
    }
}
