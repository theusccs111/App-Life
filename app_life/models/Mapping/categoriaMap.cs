using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace APP_Life.Models.Mapping
{
    public class categoriaMap : EntityTypeConfiguration<categoria>
    {
        public categoriaMap()
        {
            // Primary Key
            this.HasKey(t => t.CategoriaID);

            // Properties
            this.Property(t => t.nome)
                .HasMaxLength(100);

            // Table & Column Mappings
            this.ToTable("categoria", "app_life");
            this.Property(t => t.CategoriaID).HasColumnName("CategoriaID");
            this.Property(t => t.nome).HasColumnName("nome");
            this.Property(t => t.tipo).HasColumnName("tipo");
        }
    }
}
