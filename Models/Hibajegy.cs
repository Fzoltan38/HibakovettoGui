using System;
using System.Collections.Generic;
using System.Text;

namespace HibaKovetoWpf.Models
{
    internal class Hibajegy
    {
        public string? Cim { get; set; }
        public string? Leiras { get; set; }
        public string? Komponens { get; set; }
        public string? Sulyossag { get; set; }
        public bool? Megoldva { get; set; }
        public bool? SurgosBeavatkozas { get; set; }
        public DateTime? Bejelentve { get; set; }

    }
}
