using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace APP_Life.Models
{
    /// <summary>
    /// Classe das Categorias Financeiras
    /// </summary>
    public partial class categoria : IEnumerable<categoria>
    {
        /// <summary>
        /// Método que busca as informações no banco de dados relacionadas ao usuário logado.
        /// </summary>
        public categoria()
        {
            this.despesas = new List<despesa>();
            this.projetadoes = new List<projetado>();
            this.receitas = new List<receita>();
        }

        public int CategoriaID { get; set; }

        [Required(ErrorMessage = "Informe o Nome da Categoria")]
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
