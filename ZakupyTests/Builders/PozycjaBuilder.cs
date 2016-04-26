using Zakupy.Dane;

namespace ZakupyTests.Builders
{
    class PozycjaBuilder
    {
        private Pozycja Object { get; set; }

        public PozycjaBuilder()
        {
            Object = new Pozycja();
        }

        public PozycjaBuilder ZNazwa(string nazwa)
        {
            Object.Nazwa = nazwa;
            return this;
        }

        public PozycjaBuilder ZNumeremPozycjiWExcelu(int numer)
        {
            Object.NumerPozycjiWExcelu = numer;
            return this;
        }

        public PozycjaBuilder ZIloscia(int? ile)
        {
            Object.Ilosc = ile;
            return this;
        }

        public PozycjaBuilder ZCena(decimal cena)
        {
            Object.Cena = cena.ToString().Replace(",", ".");
            return this;
        }
        public PozycjaBuilder NaPodstawiePozycji(Pozycja pozycja)
        {
            Object.Cena = pozycja.Cena;
            Object.Ilosc = pozycja.Ilosc;
            Object.Nazwa = pozycja.Nazwa;
            Object.NumerPozycjiWExcelu = pozycja.NumerPozycjiWExcelu;
            return this;
        }

        public Pozycja Build()
        {
            return Object;
        }
    }
}