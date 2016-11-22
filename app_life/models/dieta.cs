using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace APP_Life.Models
{ /// <summary>
  /// Classe das Dietas
  /// </summary>
    public partial class dieta : IEnumerable<dieta>
    {
        /// <summary>
        /// Método que busca as informações das Dietas cadastradas no banco de dados relacionadas ao usuário logado.
        /// </summary>
        public dieta()
        {
            this.lista_alimentos = new List<lista_alimentos>();
        }

        public void CadastrarDieta(dieta rece, int id)
        {
            app_lifeContext contexto = new app_lifeContext();
            rece.UsuarioID = id;
            contexto.dietas.Add(rece);

            contexto.SaveChanges();
        }

        public void RemoverDieta(int id)
        {
            app_lifeContext contexto = new app_lifeContext();
            dieta main = contexto.dietas.Find(id);
            var query = from u in contexto.lista_alimentos where u.IDDieta == id select u;
            foreach (var item in query)
            {
                lista_alimentos mainc = contexto.lista_alimentos.Find(item.id);
                contexto.lista_alimentos.Remove(mainc);
            }

            contexto.dietas.Remove(main);
            contexto.SaveChanges();
        }

        public void UpdateDieta(dieta rece)
        {

            app_lifeContext contexto = new app_lifeContext();
            var query = from u in contexto.dietas where u.DietaID == rece.DietaID select u;
            foreach (var item in query)
            {
                item.Nome = rece.Nome;
                if (rece.Valor != 0)
                {
                    item.Valor = rece.Valor;
                }
            }
            contexto.SaveChanges();
        }


        public int DietaID { get; set; }
        [DisplayName("Dieta")]
        public string Nome { get; set; }
        public Nullable<int> UsuarioID { get; set; }

        [DisplayName("Custo da Dieta")]
        public decimal Valor { get; set; }

        [DisplayName("Duração Mensal")]
        public int mensalVezes { get; set; }

        public virtual ICollection<lista_alimentos> lista_alimentos { get; set; }
        public virtual usuario usuario { get; set; }

        List<dieta> dietasLista;

        public IEnumerator<dieta> GetEnumerator()
        {
            return dietasLista.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
