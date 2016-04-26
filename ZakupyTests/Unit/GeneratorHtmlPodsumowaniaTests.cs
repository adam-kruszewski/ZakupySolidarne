using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using FluentAssertions;
using NUnit.Framework;
using Zakupy.Dane;
using Zakupy.Podsumowanie;
using ZakupyTests.Builders;

namespace ZakupyTests.Unit
{
    public class GeneratorHtmlPodsumowaniaTests
    {
        private GeneratorHtml generator = new GeneratorHtml();
        const string nazwaKatalogu = "Wyniki";

        [Test, Ignore]
        public void PoprawnieGenerujePodsumowanieHtml()
        {
            PrzygotujKatalogNaWyniki();
            var zamowienie = StworzPrzykladoweZamowienie();

            string wynik;
            using (var writer = PrzygotujWriter())
            {
                generator.Generuj(zamowienie, writer);

                wynik = writer.ToString();
            }
            wynik.Should().Be(DajOczekiwanyHtml());
        }

        private void PrzygotujKatalogNaWyniki()
        {
            if (!Directory.Exists(nazwaKatalogu))
                Directory.CreateDirectory(nazwaKatalogu);
        }

        private TextWriter PrzygotujWriter()
        {
            return new StringWriter();
        }

        private string DajOczekiwanyHtml()
        {
            return "aaa";
        }

        private WczytaneZamowienie StworzPrzykladoweZamowienie()
        {
            return new ZamowienieBuilder()
                .DodajGrupeProduktow(StworzGrupe1())
                .DodajGrupeProduktow(StworzGrupe2())
                .DodajGrupeProduktow(StworzGrupe3())
                    .Build();
        }

        private GrupaProduktow StworzGrupe1()
        {
            var pozycje = StworzPozycje(3, 1);
            pozycje[0].Cena = "12";
            pozycje[0].Ilosc = 5;

            var grupa = new GrupaPozycjiBuilder()
                .ZNazwa("Grupa 1")
                    .Build();

            UzupelnijGrupeOPozycje(grupa, pozycje);
            return grupa;
        }

        private GrupaProduktow StworzGrupe2()
        {
            var pozycje = StworzPozycje(6, 5);

            var grupa = new GrupaPozycjiBuilder()
                .ZNazwa("Grupa 2")
                    .Build();

            UzupelnijGrupeOPozycje(grupa, pozycje);
            return grupa;
        }

        private GrupaProduktow StworzGrupe3()
        {
            var pozycje = StworzPozycje(10, 10);
            pozycje[2].Cena = "12.34";
            pozycje[2].Ilosc = 1;
            pozycje[4].Cena = "12.34";
            pozycje[4].Ilosc = 1;

            var grupa = new GrupaPozycjiBuilder()
                .ZNazwa("Grupa 3")
                    .Build();

            UzupelnijGrupeOPozycje(grupa, pozycje);
            return grupa;
        }

        private Pozycja[] StworzPozycje(int ile, int poczatkowyIndex)
        {
            var wynik = new Pozycja[ile];

            
            for (int i = 0; i < ile; i++)
                wynik[i] = new PozycjaBuilder()
                    .ZNazwa("Pozycja" + (i + poczatkowyIndex))
                    .ZNumeremPozycjiWExcelu(i + poczatkowyIndex)
                    .Build();

            return wynik;
        }

        private void UzupelnijGrupeOPozycje(
            GrupaProduktow grupa,
            IEnumerable<Pozycja> pozycje)
        {
            foreach (var p in pozycje)
                grupa.Pozycje.Add(p);
        }
    }
}