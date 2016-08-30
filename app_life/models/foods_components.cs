using System;
using System.Collections.Generic;

namespace APP_Life.Models
{
    public partial class foods_components
    {
        public int ID_FOOD { get; set; }
        public int ID_COMPONENT { get; set; }
        public Nullable<int> QUANTITY { get; set; }
        public string REMARK { get; set; }
    }
}
