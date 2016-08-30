using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace APP_Life.Models.Mapping
{
    public class foods_componentsMap : EntityTypeConfiguration<foods_components>
    {
        public foods_componentsMap()
        {
            // Primary Key
            this.HasKey(t => new { t.ID_FOOD, t.ID_COMPONENT });

            // Properties
            this.Property(t => t.ID_FOOD)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.ID_COMPONENT)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.REMARK)
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("foods_components", "app_life");
            this.Property(t => t.ID_FOOD).HasColumnName("ID_FOOD");
            this.Property(t => t.ID_COMPONENT).HasColumnName("ID_COMPONENT");
            this.Property(t => t.QUANTITY).HasColumnName("QUANTITY");
            this.Property(t => t.REMARK).HasColumnName("REMARK");
        }
    }
}
