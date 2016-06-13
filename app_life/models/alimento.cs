using System;
using System.Collections.Generic;

namespace APP_Life.Models
{
    public partial class alimento
    {
        public alimento()
        {
            this.dietaxalimentoxusuarios = new List<dietaxalimentoxusuario>();
        }

        public int AlimentoID { get; set; }
        public string Nome { get; set; }
        public virtual ICollection<dietaxalimentoxusuario> dietaxalimentoxusuarios { get; set; }
    }
}
