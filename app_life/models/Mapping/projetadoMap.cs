using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace APP_Life.Models.Mapping
{
    public class projetadoMap : EntityTypeConfiguration<projetado>
    {
        public projetadoMap()
        {
            // Primary Key
            this.HasKey(t => t.ProjetadoID);

            // Properties
            this.Property(t => t.Descricao)
                .HasMaxLength(100);

            // Table & Column Mappings
            this.ToTable("projetado", "app_life");
            this.Property(t => t.ProjetadoID).HasColumnName("ProjetadoID");
            this.Property(t => t.UsuarioID).HasColumnName("UsuarioID");
            this.Property(t => t.CategoriaID).HasColumnName("CategoriaID");
            this.Property(t => t.Valor).HasColumnName("Valor");
            this.Property(t => t.Descricao).HasColumnName("Descricao");
            this.Property(t => t.Data).HasColumnName("Data");

            // Relationships
            this.HasOptional(t => t.categoria)
                .WithMany(t => t.projetadoes)
                .HasForeignKey(d => d.CategoriaID);
            this.HasOptional(t => t.usuario)
                .WithMany(t => t.projetadoes)
                .HasForeignKey(d => d.UsuarioID);

        }
    }
}
