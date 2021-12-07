using System;
using System.Collections.Generic;
using System.Text;

namespace Zawodnicy.Infrastructure.Commands
{
    public class CreateZawodnik
    {
        public int IdTrenera { get; set; }
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public string Kraj { get; set; }
        public DateTime DataUr { get; set; }
        public double Wzrost { get; set; }   //wzrost w cm
        public double Waga { get; set; } //waga w kg
    }
}
