using System;
using System.Collections.Generic;

namespace APP_Life.Models
{
    public partial class dieta
    {
        public int DietaID { get; set; }
        public string Nome { get; set; }
        public virtual dietaxalimentoxusuario dietaxalimentoxusuario { get; set; }
    }
}
