using System;
using System.Collections.Generic;

namespace APP_Life.Models
{
    public partial class view_projetado_despesa
    {
        public int Codigo_usuario { get; set; }
        public int ID_projetadoD { get; set; }
        public string Descricao { get; set; }
        public string Valor { get; set; }
        public string Categoria { get; set; }
        public string Data_Entrada { get; set; }
        public Nullable<bool> tipo { get; set; }
    }
}
