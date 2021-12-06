using System;
using System.Collections.Generic;
using System.Text;

namespace Zawodnicy.Infrastructure.DTO
{
    public class TrenerDTO
    {
        public int Id { get; set; }
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public DateTime DataUr { get; set; }
    }
}
