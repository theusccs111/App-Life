using System;
using System.Collections.Generic;

namespace APP_Life.Models
{
    /// <summary>
    /// Classe de rela��o entre Dieta, Alimento e Usu�rio
    /// </summary>
    public partial class dietaxalimentoxusuario
    {
        public int DietaID { get; set; }
        public int AlimentoID { get; set; }
        public int UsuarioID { get; set; }
        public Nullable<float> Quantidade { get; set; }
        public string Medida { get; set; }
        public virtual alimento alimento { get; set; }
        public virtual dieta dieta { get; set; }
        public virtual usuario usuario { get; set; }
    }
}
