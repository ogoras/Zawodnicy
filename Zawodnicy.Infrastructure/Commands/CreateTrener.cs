using System;

namespace Zawodnicy.WebAPI.Controllers
{
    public class CreateTrener
    {
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public DateTime DataUr { get; set; }
    }
}