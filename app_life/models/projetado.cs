using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace APP_Life.Models
{
    /// <summary>
    /// Classe das Projeções
    /// </summary>
    public partial class projetado : IEnumerable<projetado>
    {
        public int ProjetadoID { get; set; }
        public Nullable<int> UsuarioID { get; set; }
        public Nullable<int> CategoriaID { get; set; }

        [Required(ErrorMessage = "Digite o Valor")]
        public Nullable<float> Valor { get; set; }

        [Required(ErrorMessage = "Digite a Descrição")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "Digite a data")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public string Data { get; set; }
        public virtual categoria categoria { get; set; }
        public virtual usuario usuario { get; set; }

        /// <summary>
        /// Método de Cadastro das Projeções
        /// </summary>
        /// <param name="rece">Objeto do Tipo Projeção</param>
        /// <param name="id">ID do usuário logado</param>
        public void CadastrarProjetado(projetado rece, int id)
        {
            app_lifeContext contexto = new app_lifeContext();
            rece.UsuarioID = id;
            contexto.projetadoes.Add(rece);

            contexto.SaveChanges();
        }
        /// <summary>
        /// Método de Remoção da Projeção
        /// </summary>
        /// <param name="id">ID da Projeção a ser removida</param>
        public void RemoverProjetado(int id)
        {
            app_lifeContext contexto = new app_lifeContext();
            projetado main = contexto.projetadoes.Find(id);
            contexto.projetadoes.Remove(main);
            contexto.SaveChanges();
        }

        /// <summary>
        /// Método de Alteração de uma Projeção já cadastrada
        /// </summary>
        /// <param name="rece">Objeto do tipo Projeção</param>
        public void UpdateProjetado(projetado rece)
        {
            app_lifeContext contexto = new app_lifeContext();
            var query = from u in contexto.projetadoes where u.ProjetadoID == rece.ProjetadoID select u;
            foreach (var item in query)
            {
                item.Descricao = rece.Descricao;
                item.Valor = rece.Valor;
                item.Data = rece.Data;
                //item.categoria.nome = rece.categoria.nome;
                item.UsuarioID = rece.UsuarioID;
                item.CategoriaID = rece.CategoriaID;

            }
            contexto.SaveChanges();
        }


        List<projetado> projetadoLista;



        public IEnumerator<projetado> GetEnumerator()
        {
            return projetadoLista.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
