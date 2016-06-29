using System;
using System.Collections.Generic;

namespace APP_Life.Models
{
    public partial class view_saldo
    {
        public int ID { get; set; }
        public Nullable<double> receita { get; set; }
        public Nullable<double> despesa { get; set; }
        public string Saldo { get; set; }
    }
}
