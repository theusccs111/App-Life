using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace APP_Life.Models
{
    /// <summary>
    /// Classe dos Objetivos
    /// </summary>
    public partial class objetivo : IEnumerable<objetivo>
    {
        public int ObjetivoID { get; set; }

        [Required(ErrorMessage = "Digite o Nome do Objetivo")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Digite o Custo do Objetivo")]
        [DisplayName("Custo")]
        public decimal ValorTotal { get; set; }

        [Required(ErrorMessage = "Digite o Saldo Disponivel do Objetivo")]
        [DisplayName("Dispon�vel")]
        public decimal ValorAtual { get; set; }
        public Nullable<int> UsuarioID { get; set; }
        public virtual usuario usuario { get; set; }

        /// <summary>
        /// M�todo de Cadastro das Objetivo
        /// </summary>
        /// <param name="rece">Objeto do Tipo OBjetivo</param>
        /// <param name="id">ID do Usu�rio logado</param>
        public void CadastrarObjetivo(objetivo rece, int id)
        {
            app_lifeContext contexto = new app_lifeContext();
            rece.UsuarioID = id;
            contexto.objetivos.Add(rece);

            contexto.SaveChanges();
        }
        /// <summary>
        /// M�todo de Remo��o da Objetivo
        /// </summary>
        /// <param name="id">ID da Objetivo a ser exclu�da</param>
        public void RemoverObjetivo(int id)
        {
            app_lifeContext contexto = new app_lifeContext();
            objetivo main = contexto.objetivos.Find(id);
            contexto.objetivos.Remove(main);
            contexto.SaveChanges();
        }

        /// <summary>
        /// M�todo de Altera��o de uma Objetivo j� cadastrada.
        /// </summary>
        /// <param name="rece">Objeto do Tipo Objetivo</param>
        public void UpdateObjetivo(objetivo rece)
        {
            app_lifeContext contexto = new app_lifeContext();
            var query = from u in contexto.objetivos where u.ObjetivoID == rece.ObjetivoID select u;
            foreach (var item in query)
            {
                item.Nome = rece.Nome;
                item.ValorAtual = rece.ValorAtual;
                item.ValorTotal = rece.ValorTotal;
                //item.categoria.nome = rece.categoria.nome;
                item.UsuarioID = rece.UsuarioID;


            }
            contexto.SaveChanges();
        }


        List<objetivo> objetivoLista;

        public IEnumerator<objetivo> GetEnumerator()
        {
            return objetivoLista.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
