using System;
using System.Collections;
using System.Collections.Generic;

namespace APP_Life.Models
{ /// <summary>
  /// Classe das Dietas
  /// </summary>
    public partial class dieta : IEnumerable<dieta>
    {
        /// <summary>
        /// M�todo que busca as informa��es das Dietas cadastradas no banco de dados relacionadas ao usu�rio logado.
        /// </summary>
        public dieta()
        {
            this.lista_alimentos = new List<lista_alimentos>();
        }

        public int DietaID { get; set; }
        public string Nome { get; set; }
        public Nullable<int> UsuarioID { get; set; }
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
