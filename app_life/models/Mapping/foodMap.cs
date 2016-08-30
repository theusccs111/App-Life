using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace APP_Life.Models.Mapping
{
    public class foodMap : EntityTypeConfiguration<food>
    {
        public foodMap()
        {
            // Primary Key
            this.HasKey(t => t.ID_FOOD);

            // Properties
            this.Property(t => t.ID_FOOD)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.NAME_FOOD)
                .HasMaxLength(255);

            this.Property(t => t.SCIENTIFIC_NAME)
                .HasMaxLength(255);

            this.Property(t => t.GROUP_FOOD)
                .HasMaxLength(255);

            this.Property(t => t.CLASSES_FOOD)
                .HasMaxLength(255);

            this.Property(t => t.TYPE_FOOD)
                .HasMaxLength(255);

            this.Property(t => t.RESIDUES_DESC)
                .HasMaxLength(255);

            this.Property(t => t.CHO_FACTOR)
                .HasMaxLength(255);

            this.Property(t => t.MAIN_DATA_SOURCE)
                .HasMaxLength(255);

            this.Property(t => t.IDIOM)
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("foods", "app_life");
            this.Property(t => t.ID_FOOD).HasColumnName("ID_FOOD");
            this.Property(t => t.NAME_FOOD).HasColumnName("NAME_FOOD");
            this.Property(t => t.SCIENTIFIC_NAME).HasColumnName("SCIENTIFIC_NAME");
            this.Property(t => t.GROUP_FOOD).HasColumnName("GROUP_FOOD");
            this.Property(t => t.CLASSES_FOOD).HasColumnName("CLASSES_FOOD");
            this.Property(t => t.TYPE_FOOD).HasColumnName("TYPE_FOOD");
            this.Property(t => t.RESIDUES_DESC).HasColumnName("RESIDUES_DESC");
            this.Property(t => t.RESIDUES).HasColumnName("RESIDUES");
            this.Property(t => t.N_FACTOR).HasColumnName("N_FACTOR");
            this.Property(t => t.PRO_FACTOR).HasColumnName("PRO_FACTOR");
            this.Property(t => t.FAT_FACTOR).HasColumnName("FAT_FACTOR");
            this.Property(t => t.CHO_FACTOR).HasColumnName("CHO_FACTOR");
            this.Property(t => t.MAIN_DATA_SOURCE).HasColumnName("MAIN_DATA_SOURCE");
            this.Property(t => t.IDIOM).HasColumnName("IDIOM");
            this.Property(t => t.PYRAMID).HasColumnName("PYRAMID");
        }
    }
}
