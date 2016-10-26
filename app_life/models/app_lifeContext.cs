using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using APP_Life.Models.Mapping;

namespace APP_Life.Models
{
    public partial class app_lifeContext : DbContext
    {
        static app_lifeContext()
        {
            Database.SetInitializer<app_lifeContext>(null);
        }

        public app_lifeContext()
            : base("Name=app_lifeContext")
        {
        }

        public DbSet<alimento> alimentos { get; set; }
        public DbSet<categoria> categorias { get; set; }
        public DbSet<categoriaalimento> categoriaalimentoes { get; set; }
        public DbSet<despesa> despesas { get; set; }
        public DbSet<dieta> dietas { get; set; }
        public DbSet<lista_alimentos> lista_alimentos { get; set; }
        public DbSet<objetivo> objetivos { get; set; }
        public DbSet<projetado> projetadoes { get; set; }
        public DbSet<receita> receitas { get; set; }
        public DbSet<usuario> usuarios { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new alimentoMap());
            modelBuilder.Configurations.Add(new categoriaMap());
            modelBuilder.Configurations.Add(new categoriaalimentoMap());
            modelBuilder.Configurations.Add(new despesaMap());
            modelBuilder.Configurations.Add(new dietaMap());
            modelBuilder.Configurations.Add(new lista_alimentosMap());
            modelBuilder.Configurations.Add(new objetivoMap());
            modelBuilder.Configurations.Add(new projetadoMap());
            modelBuilder.Configurations.Add(new receitaMap());
            modelBuilder.Configurations.Add(new usuarioMap());
        }
    }
}
