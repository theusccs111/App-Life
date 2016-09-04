using System;
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

        public DbSet<alimento> alimentoes { get; set; }
        public DbSet<categoria> categorias { get; set; }
        public DbSet<despesa> despesas { get; set; }
        public DbSet<dieta> dietas { get; set; }
        public DbSet<dietaxalimentoxusuario> dietaxalimentoxusuarios { get; set; }
        public DbSet<food> foods { get; set; }
        public DbSet<foods_components> foods_components { get; set; }
        public DbSet<projetado> projetadoes { get; set; }
        public DbSet<receita> receitas { get; set; }
        public DbSet<usuario> usuarios { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new alimentoMap());
            modelBuilder.Configurations.Add(new categoriaMap());
            modelBuilder.Configurations.Add(new despesaMap());
            modelBuilder.Configurations.Add(new dietaMap());
            modelBuilder.Configurations.Add(new dietaxalimentoxusuarioMap());
            modelBuilder.Configurations.Add(new foodMap());
            modelBuilder.Configurations.Add(new foods_componentsMap());
            modelBuilder.Configurations.Add(new projetadoMap());
            modelBuilder.Configurations.Add(new receitaMap());
            modelBuilder.Configurations.Add(new usuarioMap());
        }

      
    }
}
