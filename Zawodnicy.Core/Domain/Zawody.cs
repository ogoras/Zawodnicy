using System;
using System.Collections.Generic;
using System.Text;

namespace Zawodnicy.Core.Domain
{
    public class Zawody
    {
        public int Id { get; set; }
        public Skocznia Skocznia { get; set; }
        public string Nazwa { get; set; }
        public DateTime Data { get; set; }
    }
}
