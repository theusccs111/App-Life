using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;

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
        [DisplayName("Alimento")]
        public string Nome { get; set; }
        public string Umidade { get; set; }
        public string Kcal { get; set; }
        public string KJ { get; set; }
        public decimal Proteina { get; set; }
        public string Lipideos { get; set; }
        public string Colesterol { get; set; }
        public decimal Carboidrato { get; set; }
        public decimal FibraAlimentar { get; set; }
        public string Cinzas { get; set; }
        public decimal Calcio { get; set; }
        public string Magnesio { get; set; }
        public string Categoria { get; set; }
        public string Manganes { get; set; }
        public string Fosforo { get; set; }
        public decimal Ferro { get; set; }
        public decimal Sodio { get; set; }
        public decimal Potassio { get; set; }
        public string Cobre { get; set; }
        public decimal Zinco { get; set; }
        public string Retinol { get; set; }
        public string RE { get; set; }
        public string RAE { get; set; }
        public string Tiamina { get; set; }
        public string Riboflavina { get; set; }
        public string Piridoxina { get; set; }
        public string Niacina { get; set; }
        public decimal VitaminaC { get; set; }
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
