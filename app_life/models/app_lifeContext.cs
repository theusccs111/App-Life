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

        public DbSet<categoria> categorias { get; set; }
        public DbSet<despesa> despesas { get; set; }
        public DbSet<projetado> projetadoes { get; set; }
        public DbSet<receita> receitas { get; set; }
        public DbSet<usuario> usuarios { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new categoriaMap());
            modelBuilder.Configurations.Add(new despesaMap());
            modelBuilder.Configurations.Add(new projetadoMap());
            modelBuilder.Configurations.Add(new receitaMap());
            modelBuilder.Configurations.Add(new usuarioMap());
        }
    }
}
