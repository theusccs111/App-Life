using System;
using System.Collections.Generic;

namespace APP_Life.Models
{
    public partial class dieta
    {
        public dieta()
        {
            this.dietaxalimentoxusuarios = new List<dietaxalimentoxusuario>();
        }

        public int DietaID { get; set; }
        public string Nome { get; set; }
        public virtual ICollection<dietaxalimentoxusuario> dietaxalimentoxusuarios { get; set; }
    }
}
