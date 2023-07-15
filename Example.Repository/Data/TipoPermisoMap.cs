using Example.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Example.Repository
{
    public class TipoPermisoMap : IEntityTypeConfiguration<TipoPermiso>
    {
        public void Configure(EntityTypeBuilder<TipoPermiso> builder)
        {
            builder.ToTable("TipoPermisos");
            builder.HasKey(c=>c.Id);
            builder.Property(c => c.Id).ValueGeneratedOnAdd();

            builder.Property(c=>c.Descripcion).HasMaxLength(250).IsRequired();
        }
    }
}
