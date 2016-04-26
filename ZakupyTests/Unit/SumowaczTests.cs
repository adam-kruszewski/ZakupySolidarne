using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using NUnit.Framework;
using Zakupy.Dane;
using Zakupy.Sumowanie;
using ZakupyTests.Builders;

namespace ZakupyTests.Unit
{
    public class SumowaczTests
    {
        private Sumowacz sumowacz = new Sumowacz();

        private WczytaneZamowienie zamowienie1;
        private WczytaneZamowienie zamowienie2;
        private WczytaneZamowienie zamowienieWynik;

        [SetUp]
        public void SetUpEachTests()
        {
            zamowienie1 = StworzZamowienie1();
            zamowienie2 = StworzZamowienie2();
            zamowienieWynik = sumowacz.SumujZamowienia(
                new WczytaneZamowienie[] { zamowienie1, zamowienie2 }.ToList(),
                new List<string>());
        }

        [Test]
        public void TakaSamaLiczbaPozycji()
        {
            zamowienieWynik.GrupyProduktow.Count().Should().Be(2);
            zamowienieWynik.GrupyProduktow[0].Pozycje.Count().Should().Be(3);
        }

        [Test]
        public void PoprawneIlosciWPozycjach()
        {
            SprawdzIlosciGrupyProduktow(
                zamowienieWynik.GrupyProduktow[0],
                new int?[] { 1, 3, 3 });

            SprawdzIlosciGrupyProduktow(
                zamowienieWynik.GrupyProduktow[1],
                new int?[] { 1, null, 2 });
        }

        private void SprawdzIlosciGrupyProduktow(
            GrupaProduktow grupaProduktow, int?[] ilosci)
        {
            for (int i = 0; i < ilosci.Length; i++)
                grupaProduktow.Pozycje[i].Ilosc.Should().Be(ilosci[i]);
        }

        private WczytaneZamowienie StworzZamowienie1()
        {
            return StworzZamowienieZIlosciami(
                new int?[] { null, 1, 2 },
                new int?[] { 1, null, 1 });
        }

        private WczytaneZamowienie StworzZamowienie2()
        {
            return StworzZamowienieZIlosciami(
                new int?[] { 1, 2, 1 },
                new int?[] { null, null, 1 });
        }

        private WczytaneZamowienie StworzZamowienieZIlosciami(
            int?[] ilosci1,
            int?[] ilosci2)
        {
            var wynik =
                new ZamowienieBuilder()
                    .NaPodstawie(StworzZamowieniePrzykladowe())
                        .Build();

            UstawIlosciGrupieProduktow(ilosci1, wynik.GrupyProduktow[0]);
            UstawIlosciGrupieProduktow(ilosci2, wynik.GrupyProduktow[1]);
            return wynik;
        }

        private void UstawIlosciGrupieProduktow(
            int?[] ilosci1,
            GrupaProduktow grupa)
        {
            for (int i = 0; i < ilosci1.Length; i++)
                grupa.Pozycje[i].Ilosc = ilosci1[i];
        }

        private WczytaneZamowienie StworzZamowieniePrzykladowe()
        {
            return
                new ZamowienieBuilder()
                    .DodajGrupeProduktow(StworzGrupeProduktow1())
                    .DodajGrupeProduktow(StworzGrupeProduktow2())
                        .Build();
        }

        private GrupaProduktow StworzGrupeProduktow1()
        {
            return new GrupaPozycjiBuilder()
                .ZNazwa("grupa1")
                    .DodajPozycje(StworzPozycje("produkt1.1", 10.5m, null))
                    .DodajPozycje(StworzPozycje("produkt1.2", 13m, null))
                    .DodajPozycje(StworzPozycje("produkt1.3", 21m, null))
                    .Build();
        }

        private Pozycja StworzPozycje(string nazwa, decimal cena, int? ilosc)
        {
            return
                new PozycjaBuilder()
                    .ZNazwa(nazwa)
                    .ZCena(cena)
                    .ZIloscia(ilosc)
                        .Build();
        }

        private GrupaProduktow StworzGrupeProduktow2()
        {
            return new GrupaPozycjiBuilder()
                .ZNazwa("grupa1")
                    .DodajPozycje(StworzPozycje("produkt2.1", 20.5m, null))
                    .DodajPozycje(StworzPozycje("produkt2.2", 23m, null))
                    .DodajPozycje(StworzPozycje("produkt2.3", 22m, null))
                    .Build();
        }
    }
}