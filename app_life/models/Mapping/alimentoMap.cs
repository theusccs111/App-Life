using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace APP_Life.Models.Mapping
{
    public class alimentoMap : EntityTypeConfiguration<alimento>
    {
        public alimentoMap()
        {
            // Primary Key
            this.HasKey(t => t.ID_COMPONENT);

            // Properties
            this.Property(t => t.NAME_COMPONENT)
                .HasMaxLength(255);

            this.Property(t => t.UNIT_COMPONENT)
                .HasMaxLength(255);

            this.Property(t => t.CLASSES_COMPONENT)
                .HasMaxLength(255);

            this.Property(t => t.TAGNAME)
                .HasMaxLength(255);

            this.Property(t => t.SYSTEMATIC_NAME)
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("alimento", "app_life");
            this.Property(t => t.ID_COMPONENT).HasColumnName("ID_COMPONENT");
            this.Property(t => t.NAME_COMPONENT).HasColumnName("NAME_COMPONENT");
            this.Property(t => t.UNIT_COMPONENT).HasColumnName("UNIT_COMPONENT");
            this.Property(t => t.CLASSES_COMPONENT).HasColumnName("CLASSES_COMPONENT");
            this.Property(t => t.TAGNAME).HasColumnName("TAGNAME");
            this.Property(t => t.DECIMAL_PLACES).HasColumnName("DECIMAL_PLACES");
            this.Property(t => t.SYSTEMATIC_NAME).HasColumnName("SYSTEMATIC_NAME");
        }
    }
}
