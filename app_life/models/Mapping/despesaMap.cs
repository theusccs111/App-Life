using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace APP_Life.Models.Mapping
{
    public class despesaMap : EntityTypeConfiguration<despesa>
    {
        public despesaMap()
        {
            // Primary Key
            this.HasKey(t => t.DespesaID);

            // Properties
            this.Property(t => t.Descricao)
                .HasMaxLength(100);

            this.Property(t => t.Data)
                .HasMaxLength(10);

            // Table & Column Mappings
            this.ToTable("despesa", "app_life");
            this.Property(t => t.DespesaID).HasColumnName("DespesaID");
            this.Property(t => t.CategoriaID).HasColumnName("CategoriaID");
            this.Property(t => t.UsuarioID).HasColumnName("UsuarioID");
            this.Property(t => t.Valor).HasColumnName("Valor");
            this.Property(t => t.Descricao).HasColumnName("Descricao");
            this.Property(t => t.Data).HasColumnName("Data");

            // Relationships
            this.HasOptional(t => t.categoria)
                .WithMany(t => t.despesas)
                .HasForeignKey(d => d.CategoriaID);
            this.HasOptional(t => t.usuario)
                .WithMany(t => t.despesas)
                .HasForeignKey(d => d.UsuarioID);

        }
    }
}
