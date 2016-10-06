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
            this.dietaxalimentoxusuarios = new List<dietaxalimentoxusuario>();
            this.projetadoes = new List<projetado>();
            this.receitas = new List<receita>();
            this.objetivos = new List<objetivo>();
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


        //  [DisplayName("Código")]
        public int usuarioID { get; set; }

        //   [DisplayName("Email")]
        [Required(ErrorMessage = "Digite seu Email")]
        public string email { get; set; }
        [Required(ErrorMessage = "Digte sua Senha")]
        //     [DisplayName("Senha")]
        public string senha { get; set; }

        //[DisplayName("Confirmar Senha")]
        // public string confirmaSenha { get; set; }
      //  [Required(ErrorMessage = "Digite seu Nome")]
        [DisplayName("Nome")]
        public string nome { get; set; }

      //  [Required(ErrorMessage = "Digite seu Sobrenome")]
        [DisplayName("Sobrenome")]
        public string sobrenome { get; set; }

      //  [Required(ErrorMessage = "Digite sua Data de Nascimento")]
        [DisplayName("Data de Nascimento")]
        public Nullable<System.DateTime> datanasc { get; set; }

     //   [Required(ErrorMessage = "Informe seu sexo")]
        [DisplayName("Sexo")]
        public string sexo { get; set; }

     //   [Required(ErrorMessage = "Digite seu Telefone")]
        [DisplayName("Telefone")]
        public Nullable<long> telefone { get; set; }

//[Required(ErrorMessage = "Digite o nome da rua em que você mora")]
        [DisplayName("Rua")]
        public string rua { get; set; }

      //  [Required(ErrorMessage = "Digite o nome o número da rua em que você mora")]
        [DisplayName("Número da Rua")]
        public Nullable<int> numero { get; set; }

      //  [Required(ErrorMessage = "Digite o nome do bairro em que você mora")]
        [DisplayName("Bairro")]
        public string bairro { get; set; }

       // [Required(ErrorMessage = "Digite o nome da cidade em que você mora")]
        [DisplayName("Cidade")]
        public string cidade { get; set; }

       // [Required(ErrorMessage = "Digite o nome do estado em que você mora")]
        [DisplayName("Estado")]
        public string estado { get; set; }

        [DisplayName("Calorias")]
        public Nullable<float> Calorias { get; set; }

        public virtual ICollection<despesa> despesas { get; set; }
        public virtual ICollection<dietaxalimentoxusuario> dietaxalimentoxusuarios { get; set; }
        public virtual ICollection<projetado> projetadoes { get; set; }
        public virtual ICollection<receita> receitas { get; set; }
        public virtual ICollection<objetivo> objetivos { get; set; }


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
