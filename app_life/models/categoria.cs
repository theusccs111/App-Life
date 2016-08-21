using System;
using System.Collections;
using System.Collections.Generic;
using System.Web.Mvc;

namespace APP_Life.Models
{
    public partial class categoria
    {
        public categoria()
        {
            this.despesas = new List<despesa>();
            this.projetadoes = new List<projetado>();
            this.receitas = new List<receita>();
        }

       // public SelectList CategoriaList { get; set; }
        public int CategoriaID { get; set; }
        public string nome { get; set; }
        public Nullable<bool> tipo { get; set; }
        public virtual ICollection<despesa> despesas { get; set; }
        public virtual ICollection<projetado> projetadoes { get; set; }
        public virtual ICollection<receita> receitas { get; set; }

       /* public List<categoria> ListaCategoria()
        {
            return new List<categoria>
            {
                new categoria { CategoriaID = 1, nome = "Eduardo Pires"},
                new categoria { CategoriaID = 2, nome = "João Silva"},
                new categoria { CategoriaID = 3, nome = "Fulano de Tal"}
            };
        }*/

       

    }
}
