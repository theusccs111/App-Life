using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace APP_Life.Models.Mapping
{
    public class alimentoMap : EntityTypeConfiguration<alimento>
    {
        public alimentoMap()
        {
            // Primary Key
            this.HasKey(t => t.AlimentoID);

            // Properties
            this.Property(t => t.Nome)
                .HasMaxLength(45);

            // Table & Column Mappings
            this.ToTable("alimento", "app_life");
            this.Property(t => t.AlimentoID).HasColumnName("AlimentoID");
            this.Property(t => t.Nome).HasColumnName("Nome");
        }
    }
}
