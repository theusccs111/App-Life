using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace APP_Life.Models.Mapping
{
    public class usuarioMap : EntityTypeConfiguration<usuario>
    {
        public usuarioMap()
        {
            // Primary Key
            this.HasKey(t => t.usuarioID);

            // Properties
            this.Property(t => t.email)
                .HasMaxLength(100);

            this.Property(t => t.senha)
                .HasMaxLength(100);

            this.Property(t => t.nome)
                .HasMaxLength(45);

            this.Property(t => t.sobrenome)
                .HasMaxLength(100);

            this.Property(t => t.sexo)
                .HasMaxLength(1);

            this.Property(t => t.rua)
                .HasMaxLength(100);

            this.Property(t => t.bairro)
                .HasMaxLength(100);

            this.Property(t => t.cidade)
                .HasMaxLength(100);

            this.Property(t => t.estado)
                .HasMaxLength(100);

            // Table & Column Mappings
            this.ToTable("usuario", "app_life");
            this.Property(t => t.usuarioID).HasColumnName("usuarioID");
            this.Property(t => t.email).HasColumnName("email");
            this.Property(t => t.senha).HasColumnName("senha");
            this.Property(t => t.nome).HasColumnName("nome");
            this.Property(t => t.sobrenome).HasColumnName("sobrenome");
            this.Property(t => t.datanasc).HasColumnName("datanasc");
            this.Property(t => t.sexo).HasColumnName("sexo");
            this.Property(t => t.telefone).HasColumnName("telefone");
            this.Property(t => t.rua).HasColumnName("rua");
            this.Property(t => t.numero).HasColumnName("numero");
            this.Property(t => t.bairro).HasColumnName("bairro");
            this.Property(t => t.cidade).HasColumnName("cidade");
            this.Property(t => t.estado).HasColumnName("estado");
            this.Property(t => t.Calorias).HasColumnName("Calorias");

            this.Property(t => t.idfacebook).HasColumnName("idfacebook");
        }
    }
}
