using System.Linq;
using FluentAssertions;
using NUnit.Framework;
using Zakupy.Dane;
using Zakupy.Wczytywanie;

namespace ZakupyTests.Unit
{
    public class WczytywaczExcelaTests
    {
        [Test]
        public void WczytujePlikExcela()
        {
            string nazwaPliku = "..\\..\\Przyklady\\przyklad_zamowienia.xlsx";

            var wynik = new WczytywaczExcela().Wczytaj(nazwaPliku);

            //8 grup
            wynik.GrupyProduktow.Count.Should().Be(8);

            wynik.GrupyProduktow[0].Nazwa.Should().Be("SYCYLIA owoce i warzywa (min 1 karton)");
            SprawdzPozycjePierwszejGrupy(wynik.GrupyProduktow[0]);
            wynik.GrupyProduktow[1].Nazwa.Should().Be("SYCYLIA delikatesy (na szt)");

            wynik.GrupyProduktow[0].MinimalneIlosci.Should().Be(1);
            wynik.GrupyProduktow[1].MinimalneIlosci.HasValue.Should().BeFalse();
            wynik.GrupyProduktow[2].MinimalneIlosci.Should().Be(8);

            wynik.GrupyProduktow[0].Pozycje.Count.Should().Be(25);
            wynik.GrupyProduktow[0].Pozycje[0].CenaDecimal.Should().Be(123);
            wynik.GrupyProduktow[1].Pozycje[0].CenaDecimal.Should().Be(27.8m);
        }

        private void SprawdzPozycjePierwszejGrupy(GrupaProduktow grupaProduktow)
        {
            grupaProduktow.Pozycje[0].NumerPozycjiWExcelu.Should().Be(5);

            for (int i = 1; i < grupaProduktow.Pozycje.Count; i++)
                grupaProduktow.Pozycje[i].NumerPozycjiWExcelu.Should().Be(
                    grupaProduktow.Pozycje[i - 1].NumerPozycjiWExcelu + 1);
        }
    }
}
