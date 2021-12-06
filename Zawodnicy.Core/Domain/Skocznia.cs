using System;
using System.Collections.Generic;
using System.Text;

namespace Zawodnicy.Core.Domain
{
    public class Skocznia
    {
        public int Id { get; set; }
        public Miasto Miasto { get; set; }
        public string KrajSkoczni { get; set; }
        public string NazwaSkoczni { get; set; }
        public int K { get; set; }
        public int Sedz { get; set; }
    }
}
