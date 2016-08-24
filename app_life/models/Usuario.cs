using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;

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

        public void CadastrarUsuario(usuario user)
        {
            app_lifeContext contexto = new app_lifeContext();
            contexto.usuarios.Add(user);
            contexto.SaveChanges();
        }

      //  [DisplayName("Código")]
        public int usuarioID { get; set; }

     //   [DisplayName("Email")]
        public string email { get; set; }

   //     [DisplayName("Senha")]
        public string senha { get; set; }

        //[DisplayName("Confirmar Senha")]
       // public string confirmaSenha { get; set; }

        [DisplayName("Nome")]
        public string nome { get; set; }

        [DisplayName("Sobrenome")]
        public string sobrenome { get; set; }

        [DisplayName("Data de Nascimento")]
        public Nullable<System.DateTime> datanasc { get; set; }

        [DisplayName("Sexo")]
        public string sexo { get; set; }

        [DisplayName("Telefone")]
        public Nullable<long> telefone { get; set; }

        [DisplayName("Rua")]
        public string rua { get; set; }

        [DisplayName("Número da Rua")]
        public Nullable<int> numero { get; set; }

        [DisplayName("Bairro")]
        public string bairro { get; set; }

        [DisplayName("Cidade")]
        public string cidade { get; set; }

        [DisplayName("Estado")]
        public string estado { get; set; }

        [DisplayName("Calorias")]
        public Nullable<float> Calorias { get; set; }
        public virtual ICollection<despesa> despesas { get; set; }
        public virtual ICollection<dietaxalimentoxusuario> dietaxalimentoxusuarios { get; set; }
        public virtual ICollection<projetado> projetadoes { get; set; }
        public virtual ICollection<receita> receitas { get; set; }


        List<usuario> usuariosLista;
        public IEnumerator<usuario> GetEnumerator()
        {
            return usuariosLista.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return usuariosLista.GetEnumerator();
        }
    }
}
