using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace APP_Life.Models.Mapping
{
    public class objetivoMap : EntityTypeConfiguration<objetivo>
    {
        public objetivoMap()
        {
            // Primary Key
            this.HasKey(t => t.ObjetivoID);

            // Properties
            this.Property(t => t.Nome)
                .HasMaxLength(100);

            // Table & Column Mappings
            this.ToTable("objetivo", "app_life");
            this.Property(t => t.ObjetivoID).HasColumnName("ObjetivoID");
            this.Property(t => t.Nome).HasColumnName("Nome");
            this.Property(t => t.ValorTotal).HasColumnName("ValorTotal");
            this.Property(t => t.ValorAtual).HasColumnName("ValorAtual");
            this.Property(t => t.UsuarioID).HasColumnName("UsuarioID");

            // Relationships
            this.HasOptional(t => t.usuario)
                .WithMany(t => t.objetivoes)
                .HasForeignKey(d => d.UsuarioID);

        }
    }
}
