using System;
using System.Collections.Generic;
using System.Text;

namespace Zawodnicy.Core.Domain
{
    public class Uczestnictwo
    {
        public int Id { get; set; }
        public Zawodnik Zawodnik { get; set; }
        public Zawody Zawody { get; set; }
    }
}
