using System;
using System.Collections.Generic;

namespace APP_Life.Models
{
    public partial class alimento
    {
        public int ID_COMPONENT { get; set; }
        public string NAME_COMPONENT { get; set; }
        public string UNIT_COMPONENT { get; set; }
        public string CLASSES_COMPONENT { get; set; }
        public string TAGNAME { get; set; }
        public Nullable<int> DECIMAL_PLACES { get; set; }
        public string SYSTEMATIC_NAME { get; set; }
    }
}
