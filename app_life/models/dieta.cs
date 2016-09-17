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
        /// M�todo que busca as informa��es das Dietas cadastradas no banco de dados relacionadas ao usu�rio logado.
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
