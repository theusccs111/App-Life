using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace APP_Life.Models
{
    public partial class receita : IEnumerable<receita>
    {

        public int ReceitaID { get; set; }
        public Nullable<int> UsuarioID { get; set; }
        public Nullable<int> CategoriaID { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:c}")]
        public Nullable<float> Valor { get; set; }
        public string Descricao { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public string Data { get; set; }
        public virtual categoria categoria { get; set; }
        public virtual usuario usuario { get; set; }

        public void CadastrarReceita(receita rece, int id)
        {
            app_lifeContext contexto = new app_lifeContext();
            rece.UsuarioID = id;
            contexto.receitas.Add(rece);

            contexto.SaveChanges();
        }

        List<receita> receitasLista;

        public IEnumerator<receita> GetEnumerator()
        {
            return receitasLista.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
