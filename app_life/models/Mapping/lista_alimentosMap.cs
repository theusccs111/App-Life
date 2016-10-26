using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace APP_Life.Models.Mapping
{
    public class lista_alimentosMap : EntityTypeConfiguration<lista_alimentos>
    {
        public lista_alimentosMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            this.Property(t => t.Medida)
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("lista_alimentos", "app_life");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.IDAlimento).HasColumnName("IDAlimento");
            this.Property(t => t.Quantidade).HasColumnName("Quantidade");
            this.Property(t => t.Medida).HasColumnName("Medida");
            this.Property(t => t.IDDieta).HasColumnName("IDDieta");

            // Relationships
            this.HasOptional(t => t.alimento)
                .WithMany(t => t.lista_alimentos)
                .HasForeignKey(d => d.IDAlimento);
            this.HasOptional(t => t.dieta)
                .WithMany(t => t.lista_alimentos)
                .HasForeignKey(d => d.IDDieta);

        }
    }
}
