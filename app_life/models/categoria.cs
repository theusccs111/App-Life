using System;
using System.Collections;
using System.Collections.Generic;

namespace APP_Life.Models
{
    public partial class categoria:IEnumerable<categoria>
    {
        public categoria()
        {
            this.despesas = new List<despesa>();
            this.projetadoes = new List<projetado>();
            this.receitas = new List<receita>();
        }

        public int CategoriaID { get; set; }
        public string nome { get; set; }
        public Nullable<bool> tipo { get; set; }
        public virtual ICollection<despesa> despesas { get; set; }
        public virtual ICollection<projetado> projetadoes { get; set; }
        public virtual ICollection<receita> receitas { get; set; }

        List<categoria> categoriaLista;

        public IEnumerator<categoria> GetEnumerator()
        {
            return categoriaLista.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
