using System;
using System.Collections.Generic;
using System.Text;

namespace Zawodnicy.Core.Domain
{
    public class Zawodnik
    {
        public int Id { get; set; }
        public Trener Trener { get; set; }
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public string Kraj { get; set; }
        public DateTime DataUr { get; set; }
        public double Wzrost { get; set; }   //wzrost w cm
        public double Waga { get; set; } //waga w kg

        public override bool Equals(object obj)
        {
            if ((obj == null) || !this.GetType().Equals(obj.GetType()))
                return false;
            else
            {
                Zawodnik z = (Zawodnik)obj;
                return Id == z.Id && Trener == z.Trener && Imie == z.Imie && Nazwisko == z.Nazwisko && Kraj == z.Kraj && DataUr == z.DataUr
                    && Wzrost == z.Wzrost && Waga == z.Waga;
            }
        }
    }
}
