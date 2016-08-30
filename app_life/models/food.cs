using System;
using System.Collections.Generic;

namespace APP_Life.Models
{
    public partial class food
    {
        public int ID_FOOD { get; set; }
        public string NAME_FOOD { get; set; }
        public string SCIENTIFIC_NAME { get; set; }
        public string GROUP_FOOD { get; set; }
        public string CLASSES_FOOD { get; set; }
        public string TYPE_FOOD { get; set; }
        public string RESIDUES_DESC { get; set; }
        public Nullable<float> RESIDUES { get; set; }
        public Nullable<float> N_FACTOR { get; set; }
        public Nullable<float> PRO_FACTOR { get; set; }
        public Nullable<float> FAT_FACTOR { get; set; }
        public string CHO_FACTOR { get; set; }
        public string MAIN_DATA_SOURCE { get; set; }
        public string IDIOM { get; set; }
        public Nullable<int> PYRAMID { get; set; }
    }
}
