using System;
using System.Collections;
using System.Collections.Generic;

namespace APP_Life.Models
{
    /// <summary>
    /// Classe dos Alimentos
    /// </summary>
    public partial class alimento : IEnumerable<alimento>
    {
        /// <summary>
        /// Método que busca as informações dos alimentos cadastrados no banco de dados.
        /// </summary>
        public alimento()
        {
            this.lista_alimentos = new List<lista_alimentos>();
        }

        public int ID { get; set; }
        public string Nome { get; set; }
        public string Umidade { get; set; }
        public string Kcal { get; set; }
        public string KJ { get; set; }
        public string Proteina { get; set; }
        public string Lipideos { get; set; }
        public string Colesterol { get; set; }
        public string Carboidrato { get; set; }
        public string FibraAlimentar { get; set; }
        public string Cinzas { get; set; }
        public string Calcio { get; set; }
        public string Magnesio { get; set; }
        public string Categoria { get; set; }
        public string Manganes { get; set; }
        public string Fosforo { get; set; }
        public string Ferro { get; set; }
        public string Sodio { get; set; }
        public string Potassio { get; set; }
        public string Cobre { get; set; }
        public string Zinco { get; set; }
        public string Retinol { get; set; }
        public string RE { get; set; }
        public string RAE { get; set; }
        public string Tiamina { get; set; }
        public string Riboflavina { get; set; }
        public string Piridoxina { get; set; }
        public string Niacina { get; set; }
        public string VitaminaC { get; set; }
        public virtual ICollection<lista_alimentos> lista_alimentos { get; set; }

        List<alimento> alimentosLista;

        public IEnumerator<alimento> GetEnumerator()
        {
            return alimentosLista.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
