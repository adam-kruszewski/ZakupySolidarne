using System;

namespace Zakupy.Dane
{
    public class Pozycja
    {
        public string Nazwa { get; set; }

        public string Cena { get; set; }

        public decimal CenaDecimal
        {
            get
            {
                var doParsowania = Cena.Replace(".", ",");
                return Convert.ToDecimal(double.Parse(doParsowania));
            }
        }

        public int? Ilosc { get; set; }

        public int NumerPozycjiWExcelu { get; set; }

        public Pozycja()
        {
        }

        private Pozycja(Pozycja pozycja)
        {
            Nazwa = pozycja.Nazwa;
            Cena = pozycja.Cena;
            Ilosc = pozycja.Ilosc;
            NumerPozycjiWExcelu = pozycja.NumerPozycjiWExcelu;
        }

        public void ZwiekszIlosc(int oIle)
        {
            if (Ilosc.HasValue)
                Ilosc += oIle;
            else
                Ilosc = oIle;
        }

        public virtual Pozycja Klonuj()
        {
            return new Pozycja(this);
        }
    }
}
