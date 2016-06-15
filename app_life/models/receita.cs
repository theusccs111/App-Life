using System;
using System.Collections;
using System.Collections.Generic;

namespace APP_Life.Models
{
    public partial class receita:IEnumerable<receita>
    {
        public int ReceitaID { get; set; }
        public Nullable<int> UsuarioID { get; set; }
        public Nullable<int> CategoriaID { get; set; }
        public Nullable<float> Valor { get; set; }
        public string Descricao { get; set; }
        public Nullable<System.DateTime> Data { get; set; }
        public virtual categoria categoria { get; set; }
        public virtual usuario usuario { get; set; }

        private List<receita> receitaLista;
        public IEnumerator<receita> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return receitaLista.GetEnumerator();
        }
    }
}
