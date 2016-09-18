using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace APP_Life.Models.Mapping
{
    public class alimentoMap : EntityTypeConfiguration<alimento>
    {
        public alimentoMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.Nome)
                .HasMaxLength(487);

            this.Property(t => t.Umidade)
                .HasMaxLength(9);

            this.Property(t => t.Kcal)
                .HasMaxLength(10);

            this.Property(t => t.KJ)
                .HasMaxLength(11);

            this.Property(t => t.Proteina)
                .HasMaxLength(9);

            this.Property(t => t.Lipideos)
                .HasMaxLength(9);

            this.Property(t => t.Colesterol)
                .HasMaxLength(10);

            this.Property(t => t.Carboidrato)
                .HasMaxLength(9);

            this.Property(t => t.FibraAlimentar)
                .HasMaxLength(9);

            this.Property(t => t.Cinzas)
                .HasMaxLength(9);

            this.Property(t => t.Calcio)
                .HasMaxLength(10);

            this.Property(t => t.Magnesio)
                .HasMaxLength(10);

            this.Property(t => t.Categoria)
                .HasMaxLength(9);

            this.Property(t => t.Manganes)
                .HasMaxLength(9);

            this.Property(t => t.Fosforo)
                .HasMaxLength(11);

            this.Property(t => t.Ferro)
                .HasMaxLength(9);

            this.Property(t => t.Sodio)
                .HasMaxLength(12);

            this.Property(t => t.Potassio)
                .HasMaxLength(11);

            this.Property(t => t.Cobre)
                .HasMaxLength(9);

            this.Property(t => t.Zinco)
                .HasMaxLength(9);

            this.Property(t => t.Retinol)
                .HasMaxLength(11);

            this.Property(t => t.RE)
                .HasMaxLength(11);

            this.Property(t => t.RAE)
                .HasMaxLength(11);

            this.Property(t => t.Tiamina)
                .HasMaxLength(8);

            this.Property(t => t.Riboflavina)
                .HasMaxLength(11);

            this.Property(t => t.Piridoxina)
                .HasMaxLength(10);

            this.Property(t => t.Niacina)
                .HasMaxLength(9);

            this.Property(t => t.VitaminaC)
                .HasMaxLength(10);

            // Table & Column Mappings
            this.ToTable("alimentos", "app_life");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.Nome).HasColumnName("Nome");
            this.Property(t => t.Umidade).HasColumnName("Umidade");
            this.Property(t => t.Kcal).HasColumnName("Kcal");
            this.Property(t => t.KJ).HasColumnName("KJ");
            this.Property(t => t.Proteina).HasColumnName("Proteina");
            this.Property(t => t.Lipideos).HasColumnName("Lipideos");
            this.Property(t => t.Colesterol).HasColumnName("Colesterol");
            this.Property(t => t.Carboidrato).HasColumnName("Carboidrato");
            this.Property(t => t.FibraAlimentar).HasColumnName("FibraAlimentar");
            this.Property(t => t.Cinzas).HasColumnName("Cinzas");
            this.Property(t => t.Calcio).HasColumnName("Calcio");
            this.Property(t => t.Magnesio).HasColumnName("Magnesio");
            this.Property(t => t.Categoria).HasColumnName("Categoria");
            this.Property(t => t.Manganes).HasColumnName("Manganes");
            this.Property(t => t.Fosforo).HasColumnName("Fosforo");
            this.Property(t => t.Ferro).HasColumnName("Ferro");
            this.Property(t => t.Sodio).HasColumnName("Sodio");
            this.Property(t => t.Potassio).HasColumnName("Potassio");
            this.Property(t => t.Cobre).HasColumnName("Cobre");
            this.Property(t => t.Zinco).HasColumnName("Zinco");
            this.Property(t => t.Retinol).HasColumnName("Retinol");
            this.Property(t => t.RE).HasColumnName("RE");
            this.Property(t => t.RAE).HasColumnName("RAE");
            this.Property(t => t.Tiamina).HasColumnName("Tiamina");
            this.Property(t => t.Riboflavina).HasColumnName("Riboflavina");
            this.Property(t => t.Piridoxina).HasColumnName("Piridoxina");
            this.Property(t => t.Niacina).HasColumnName("Niacina");
            this.Property(t => t.VitaminaC).HasColumnName("VitaminaC");
        }
    }
}
