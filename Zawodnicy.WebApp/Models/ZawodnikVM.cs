using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Zawodnicy.WebApp.Models
{
    public class ZawodnikVM
    {
        public int Id { get; set; }
        public int IdTrenera { get; set; }
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public string Kraj { get; set; }
        public DateTime DataUr { get; set; }
        public double Wzrost { get; set; }   //wzrost w cm
        public double Waga { get; set; } //waga w kg
    }
}
