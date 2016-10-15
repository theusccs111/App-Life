using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace APP_Life.Models
{
    /// <summary>
    /// Classe das Despesas
    /// </summary>
    public partial class despesa : IEnumerable<despesa>
    {
        public int DespesaID { get; set; }
        public Nullable<int> CategoriaID { get; set; }
        public Nullable<int> UsuarioID { get; set; }

        [Required(ErrorMessage = "Digite o Valor")]
        public Nullable<float> Valor { get; set; }

        [Required(ErrorMessage = "Digite a Descricao")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "Digite a Data")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public string Data { get; set; }


        public virtual categoria categoria { get; set; }
        public virtual usuario usuario { get; set; }

        /// <summary>
        /// M�todo de Cadastro das Despesas
        /// </summary>
        /// <param name="rece">Objeto do Tipo Despesa</param>
        /// <param name="id">ID do Usu�rio logado</param>
        public void CadastrarDespesa(despesa rece, int id)
        {
            app_lifeContext contexto = new app_lifeContext();
            rece.UsuarioID = id;
            contexto.despesas.Add(rece);

            contexto.SaveChanges();
        }
        /// <summary>
        /// M�todo de Remo��o da Despesa
        /// </summary>
        /// <param name="id">ID da Despesa a ser exclu�da</param>
        public void RemoverDespesa(int id)
        {
            app_lifeContext contexto = new app_lifeContext();
            despesa main = contexto.despesas.Find(id);
            contexto.despesas.Remove(main);
            contexto.SaveChanges();
        }

        /// <summary>
        /// M�todo de Altera��o de uma Despesa j� cadastrada.
        /// </summary>
        /// <param name="rece">Objeto do Tipo Despesa</param>
        public void UpdateDespesa(despesa rece)
        {
            app_lifeContext contexto = new app_lifeContext();
            var query = from u in contexto.despesas where u.DespesaID == rece.DespesaID select u;
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


        List<despesa> despesaLista;

        public IEnumerator<despesa> GetEnumerator()
        {
            return despesaLista.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }


    }
}
