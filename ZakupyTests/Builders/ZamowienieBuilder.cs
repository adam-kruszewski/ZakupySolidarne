using Zakupy.Dane;

namespace ZakupyTests.Builders
{
    class ZamowienieBuilder
    {
        private WczytaneZamowienie Object { get; set; }

        public ZamowienieBuilder()
        {
            Object = new WczytaneZamowienie();
        }

        public ZamowienieBuilder DodajGrupeProduktow(GrupaProduktow grupa)
        {
            Object.GrupyProduktow.Add(grupa);
            return this;
        }

        public ZamowienieBuilder NaPodstawie(WczytaneZamowienie zamowienie)
        {
            foreach (var grupy in zamowienie.GrupyProduktow)
                DodajGrupeProduktow(new GrupaPozycjiBuilder().NaPodstawie(grupy).Build());
            return this;
        }

        public WczytaneZamowienie Build()
        {
            return Object;
        }
    }
}