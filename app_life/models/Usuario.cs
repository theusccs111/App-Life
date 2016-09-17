using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;

namespace APP_Life.Models
{
    /// <summary>
    /// Classe de Usu�rio
    /// </summary>
    public partial class usuario : IEnumerable<usuario>
    {
        /// <summary>
        /// M�todo que busca as informa��es no banco de dados relacionadas ao usu�rio logado.
        /// </summary>
        public usuario()
        {
            this.despesas = new List<despesa>();
            this.dietaxalimentoxusuarios = new List<dietaxalimentoxusuario>();
            this.projetadoes = new List<projetado>();
            this.receitas = new List<receita>();
        }
        /// <summary>
        /// M�todo que realiza o cadastro do Usu�rio
        /// </summary>
        /// <param name="user">Objeto do Tipo Usu�rio</param>
        public void CadastrarUsuario(usuario user)
        {
            app_lifeContext contexto = new app_lifeContext();
            contexto.usuarios.Add(user);
            contexto.SaveChanges();
        }
        /// <summary>
        /// M�todo que exclui o usu�rio cadastrado
        /// </summary>
        /// <param name="id">ID do usu�rio a ser excluido</param>
        public void RemoverUsuario(int id)
        {
            app_lifeContext contexto = new app_lifeContext();
            usuario main = contexto.usuarios.Find(id);
            contexto.usuarios.Remove(main);
            contexto.SaveChanges();
        }


        //  [DisplayName("C�digo")]
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

        [DisplayName("N�mero da Rua")]
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
