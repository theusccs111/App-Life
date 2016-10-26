using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace APP_Life.Models.Mapping
{
    public class dietaMap : EntityTypeConfiguration<dieta>
    {
        public dietaMap()
        {
            // Primary Key
            this.HasKey(t => t.DietaID);

            // Properties
            this.Property(t => t.Nome)
                .HasMaxLength(45);

            // Table & Column Mappings
            this.ToTable("dieta", "app_life");
            this.Property(t => t.DietaID).HasColumnName("DietaID");
            this.Property(t => t.Nome).HasColumnName("Nome");
            this.Property(t => t.UsuarioID).HasColumnName("UsuarioID");

            // Relationships
            this.HasOptional(t => t.usuario)
                .WithMany(t => t.dietas)
                .HasForeignKey(d => d.UsuarioID);

        }
    }
}
