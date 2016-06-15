using System;
using System.Collections;
using System.Collections.Generic;

namespace APP_Life.Models
{
    public partial class usuario:IEnumerable<usuario>
    {
        public usuario()
        {
            this.despesas = new List<despesa>();
            this.dietaxalimentoxusuarios = new List<dietaxalimentoxusuario>();
            this.projetadoes = new List<projetado>();
            this.receitas = new List<receita>();
        }

        private List<usuario> usuariosLista;

       

        public IEnumerator<usuario> GetEnumerator()
        {
            return usuariosLista.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return usuariosLista.GetEnumerator();
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
        public Nullable<float> Calorias { get; set; }
        public virtual ICollection<despesa> despesas { get; set; }
        public virtual ICollection<dietaxalimentoxusuario> dietaxalimentoxusuarios { get; set; }
        public virtual ICollection<projetado> projetadoes { get; set; }
        public virtual ICollection<receita> receitas { get; set; }
    }
}
