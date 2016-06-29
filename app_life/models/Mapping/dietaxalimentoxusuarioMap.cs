using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace APP_Life.Models.Mapping
{
    public class dietaxalimentoxusuarioMap : EntityTypeConfiguration<dietaxalimentoxusuario>
    {
        public dietaxalimentoxusuarioMap()
        {
            // Primary Key
            this.HasKey(t => new { t.DietaID, t.AlimentoID, t.UsuarioID });

            // Properties
            this.Property(t => t.DietaID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.AlimentoID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.UsuarioID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.Medida)
                .HasMaxLength(45);

            // Table & Column Mappings
            this.ToTable("dietaxalimentoxusuario", "app_life");
            this.Property(t => t.DietaID).HasColumnName("DietaID");
            this.Property(t => t.AlimentoID).HasColumnName("AlimentoID");
            this.Property(t => t.UsuarioID).HasColumnName("UsuarioID");
            this.Property(t => t.Quantidade).HasColumnName("Quantidade");
            this.Property(t => t.Medida).HasColumnName("Medida");

            // Relationships
            this.HasRequired(t => t.alimento)
                .WithMany(t => t.dietaxalimentoxusuarios)
                .HasForeignKey(d => d.AlimentoID);
            this.HasRequired(t => t.dieta)
                .WithMany(t => t.dietaxalimentoxusuarios)
                .HasForeignKey(d => d.DietaID);
            this.HasRequired(t => t.usuario)
                .WithMany(t => t.dietaxalimentoxusuarios)
                .HasForeignKey(d => d.UsuarioID);

        }
    }
}
