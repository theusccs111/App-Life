using System;
using System.Collections.Generic;

namespace APP_Life.Models
{
    public partial class projetado
    {
        public int ProjetadoID { get; set; }
        public Nullable<int> UsuarioID { get; set; }
        public Nullable<int> CategoriaID { get; set; }
        public Nullable<float> Valor { get; set; }
        public string Descricao { get; set; }
        public string Data { get; set; }
        public virtual categoria categoria { get; set; }
        public virtual usuario usuario { get; set; }
    }
}
