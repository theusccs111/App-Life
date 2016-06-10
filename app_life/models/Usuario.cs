using System;
using System.Collections.Generic;

namespace APP_Life.Models
{
    public partial class usuario
    {
        public usuario()
        {
            this.despesas = new List<despesa>();
            this.projetadoes = new List<projetado>();
            this.receitas = new List<receita>();
        }

        public int usuarioID { get; set; }
        public string email { get; set; }
        public string senha { get; set; }
        public string nome { get; set; }
        public string sobrenome { get; set; }
        public Nullable<System.DateTime> datanasc { get; set; }
        public string sexo { get; set; }
        public Nullable<long> telefone { get; set; }
        public string rua { get; set; }
        public Nullable<int> numero { get; set; }
        public string bairro { get; set; }
        public string cidade { get; set; }
        public string estado { get; set; }
        public virtual ICollection<despesa> despesas { get; set; }
        public virtual ICollection<projetado> projetadoes { get; set; }
        public virtual ICollection<receita> receitas { get; set; }
    }
}
