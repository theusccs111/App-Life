using System;
using System.Collections;
using System.Collections.Generic;

namespace APP_Life.Models
{
    public partial class lista_alimentos : IEnumerable<lista_alimentos>
    {
        public int id { get; set; }
        public Nullable<int> IDAlimento { get; set; }
        public Nullable<float> Quantidade { get; set; }
        public string Medida { get; set; }
        public Nullable<int> IDDieta { get; set; }
        public virtual alimento alimento { get; set; }
        public virtual dieta dieta { get; set; }

        List<lista_alimentos> listaAlimentosLista;

        public IEnumerator<lista_alimentos> GetEnumerator()
        {
            return listaAlimentosLista.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
