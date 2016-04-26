using Zakupy.Dane;

namespace ZakupyTests.Builders
{
    class GrupaPozycjiBuilder
    {
        private GrupaProduktow Object { get; set; }

        public GrupaPozycjiBuilder()
        {
            Object = new GrupaProduktow();
        }

        public GrupaPozycjiBuilder ZNazwa(string nazwa)
        {
            Object.Nazwa = nazwa;
            return this;
        }

        public GrupaPozycjiBuilder DodajPozycje(Pozycja pozycja)
        {
            Object.Pozycje.Add(pozycja);
            return this;
        }

        public GrupaPozycjiBuilder NaPodstawie(GrupaProduktow grupa)
        {
            Object.Pozycje.Clear();
            foreach (var pozycja in grupa.Pozycje)
                DodajPozycje(new PozycjaBuilder().NaPodstawiePozycji(pozycja).Build());
            return this;
        }

        public GrupaProduktow Build()
        {
            return Object;
        }
    }
}