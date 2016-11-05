using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;


namespace APP_Life.Models
{
    /// <summary>
    /// Classe de Usuário
    /// </summary>
    public partial class usuario : IEnumerable<usuario>
    {
        /// <summary>
        /// Método que busca as informações no banco de dados relacionadas ao usuário logado.
        /// </summary>
        public usuario()
        {
            this.despesas = new List<despesa>();
            this.dietas = new List<dieta>();
            this.objetivoes = new List<objetivo>();
            this.projetadoes = new List<projetado>();
            this.receitas = new List<receita>();
        }

        /// <summary>
        /// Método que realiza o cadastro do Usuário
        /// </summary>
        /// <param name="user">Objeto do Tipo Usuário</param>
        public void CadastrarUsuario(usuario user)
        {
            app_lifeContext contexto = new app_lifeContext();
            contexto.usuarios.Add(user);
            contexto.SaveChanges();
        }
        /// <summary>
        /// Método que exclui o usuário cadastrado
        /// </summary>
        /// <param name="id">ID do usuário a ser excluido</param>
        public void RemoverUsuario(int id)
        {
            app_lifeContext contexto = new app_lifeContext();
            usuario main = contexto.usuarios.Find(id);
            contexto.usuarios.Remove(main);
            contexto.SaveChanges();
        }

        public void UpdateUsuario(usuario rece)
        {
            app_lifeContext contexto = new app_lifeContext();
            var query = from u in contexto.usuarios where u.usuarioID == rece.usuarioID select u;
            foreach (var item in query)
            {

                item.email = rece.email;
                item.senha = rece.senha;
                item.nome = rece.nome;
                item.sobrenome = rece.sobrenome;
                item.datanasc = rece.datanasc;
                item.sexo = rece.sexo;
                item.telefone = rece.telefone;
                item.rua = rece.rua;
                item.numero = rece.numero;
                item.bairro = rece.bairro;
                item.cidade = rece.cidade;
                item.estado = rece.estado;
                //  item.Calorias = rece.Calorias;
            }
            contexto.SaveChanges();
        }

        public int usuarioID { get; set; }

        [DisplayName("Email")]
        [Required(ErrorMessage = "Digite seu Email")]
        public string email { get; set; }

        [Required(ErrorMessage = "Digte sua Senha")]
        [DisplayName("Senha")]
        public string senha { get; set; }

        [DisplayName("Confirmar Senha")]
        [Required(ErrorMessage = "Digite A Confirmação de Senha")]
        [Compare("senha", ErrorMessage = "Senhas não Correspondem")]
        public string confirmarSenha { get; set; }

        [DisplayName("Nome")]
        public string nome { get; set; }

        [DisplayName("Sobrenome")]
        public string sobrenome { get; set; }

        [DisplayName("Nasc.")]
        public Nullable<System.DateTime> datanasc { get; set; }

        [DisplayName("Sexo")]
        public string sexo { get; set; }

        [DisplayName("Telefone")]
        public Nullable<long> telefone { get; set; }

        [DisplayName("Endereço")]
        public string rua { get; set; }

        [DisplayName("Número")]
        public Nullable<int> numero { get; set; }

        [DisplayName("Bairro")]
        public string bairro { get; set; }

        [DisplayName("Cidade")]
        public string cidade { get; set; }

        [DisplayName("Estado")]
        public string estado { get; set; }

        [DisplayName("Calorias")]
        public Nullable<float> Calorias { get; set; }


        public Nullable<long> idfacebook { get; set; }


        public virtual ICollection<despesa> despesas { get; set; }
        public virtual ICollection<dieta> dietas { get; set; }
        public virtual ICollection<objetivo> objetivoes { get; set; }
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
