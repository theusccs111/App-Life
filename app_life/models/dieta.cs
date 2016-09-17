using System;
using System.Collections.Generic;

namespace APP_Life.Models
{
    /// <summary>
    /// Classe das Dietas
    /// </summary>
    public partial class dieta
    {
        /// <summary>
        /// Método que busca as informações das Dietas cadastradas no banco de dados relacionadas ao usuário logado.
        /// </summary>
        public dieta()
        {
            this.dietaxalimentoxusuarios = new List<dietaxalimentoxusuario>();
        }

        public int DietaID { get; set; }
        public string Nome { get; set; }
        public virtual ICollection<dietaxalimentoxusuario> dietaxalimentoxusuarios { get; set; }
    }
}
