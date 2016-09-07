using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace APP_Life.Models.Mapping
{
    public class receitaMap : EntityTypeConfiguration<receita>
    {
        public receitaMap()
        {
            // Primary Key
            this.HasKey(t => t.ReceitaID);

            // Properties
            this.Property(t => t.Descricao)
                .HasMaxLength(100);

            this.Property(t => t.Data)
                .HasMaxLength(10);

            // Table & Column Mappings
            this.ToTable("receita", "app_life");
            this.Property(t => t.ReceitaID).HasColumnName("ReceitaID");
            this.Property(t => t.UsuarioID).HasColumnName("UsuarioID");
            this.Property(t => t.CategoriaID).HasColumnName("CategoriaID");
            this.Property(t => t.Valor).HasColumnName("Valor");
            this.Property(t => t.Descricao).HasColumnName("Descricao");
            this.Property(t => t.Data).HasColumnName("Data");

            // Relationships
            this.HasOptional(t => t.categoria)
                .WithMany(t => t.receitas)
                .HasForeignKey(d => d.CategoriaID);
            this.HasOptional(t => t.usuario)
                .WithMany(t => t.receitas)
                .HasForeignKey(d => d.UsuarioID);

        }
    }
}
