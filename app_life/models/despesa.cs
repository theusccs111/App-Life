using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace APP_Life.Models
{
    public partial class despesa : IEnumerable<despesa>
    {
        public int DespesaID { get; set; }
        public Nullable<int> CategoriaID { get; set; }
        public Nullable<int> UsuarioID { get; set; }
        public Nullable<float> Valor { get; set; }
        public string Descricao { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public string Data { get; set; }
        public virtual categoria categoria { get; set; }
        public virtual usuario usuario { get; set; }

        public void CadastrarDespesa(despesa rece, int id)
        {
            app_lifeContext contexto = new app_lifeContext();
            rece.UsuarioID = id;
            contexto.despesas.Add(rece);

            contexto.SaveChanges();
        }

        public void RemoverDespesa(int id)
        {
            app_lifeContext contexto = new app_lifeContext();
            despesa main = contexto.despesas.Find(id);
            contexto.despesas.Remove(main);
            contexto.SaveChanges();
        }


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
