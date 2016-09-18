using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace APP_Life.Models.Mapping
{
    public class categoriaalimentoMap : EntityTypeConfiguration<categoriaalimento>
    {
        public categoriaalimentoMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.Nome)
                .HasMaxLength(100);

            // Table & Column Mappings
            this.ToTable("categoriaalimento", "app_life");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.Nome).HasColumnName("Nome");
        }
    }
}
