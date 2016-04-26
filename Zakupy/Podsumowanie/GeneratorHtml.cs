using System.IO;
using System.Xml.Linq;
using Zakupy.Dane;

namespace Zakupy.Podsumowanie
{
    public class GeneratorHtml
    {
        public void Generuj(WczytaneZamowienie zamowienie, TextWriter writer)
        {
            var dokument = new XDocument();
            var elementHtml = new XElement("html");

            var elementHeader = GenerujElementHead();
            var elementBody = GenerujElementBody(zamowienie);
            elementHtml.Add(elementHeader);
            elementHtml.Add(elementBody);

            dokument.Add(
                elementHtml);

            writer.Write(dokument.ToString());
        }

        private XElement GenerujElementBody(WczytaneZamowienie zamowienie)
        {
            var elementBody = new XElement("body");

            foreach (var grupa in zamowienie.GrupyProduktow)
            {
                if (grupa.IstniejePozycjaZPodanaIloscia())
                    GenerujPodsumowanieGrupy(grupa, elementBody);
            }

            DodajPodsumowanieWartosciZamowienia(zamowienie, elementBody);
            return elementBody;
        }

        private void DodajPodsumowanieWartosciZamowienia(
            WczytaneZamowienie zamowienie,
            XElement elementBody)
        {
            elementBody.Add(StworzElementZWartoscia("h3", "Suma"));
            elementBody.Add(StworzElementZWartoscia("p", zamowienie.Wartosc.ToString()));
        }


        private void GenerujPodsumowanieGrupy(
            GrupaProduktow grupa,
            XElement elementBody)
        {
            var element = StworzElementZWartoscia("h3", grupa.Nazwa);
            elementBody.Add(element);
            var elementP = new XElement("p");
            elementBody.Add(elementP);
            var elementUL = new XElement("ul");
            elementP.Add(elementUL);
            foreach (var pozycja in grupa.Pozycje)
            {
                if (pozycja.Ilosc.HasValue && pozycja.Ilosc > 0)
                    elementUL.Add(GenerujElementPozycji(pozycja));
            }
        }

        private XElement GenerujElementHead()
        {
            var elementHeader = new XElement("head");
            var elementMeta = GenerujElementMeta();
            var elementTitle = GenerujElementTitle();

            elementHeader.Add(elementMeta);
            elementHeader.Add(elementTitle);
            return elementHeader;
        }

        private XElement GenerujElementTitle()
        {
            var elementTitle =
                new XElement("title");
            elementTitle.Add(new XText("Podsumowanie zamówienia"));
            return elementTitle;
        }

        private XElement GenerujElementMeta()
        {
            var elementMeta = new XElement("meta");
            elementMeta.Add(new XAttribute("charset", "utf-8"));
            return elementMeta;
        }

        private XElement GenerujElementPozycji(Pozycja pozycja)
        {
            var wynik = new XElement("li");
            wynik.Add(new XText(pozycja.NumerPozycjiWExcelu + ". "));
            wynik.Add(StworzElementZWartoscia("b", pozycja.Nazwa));
            wynik.Add(new XText(" - " + pozycja.Ilosc.Value + " "));
            wynik.Add(StworzElementZWartoscia("i", DajWyliczenieWartosciPozycji(pozycja)));
            return wynik;
        }

        private string DajWyliczenieWartosciPozycji(Pozycja pozycja)
        {
            return "(" + pozycja.Ilosc.Value + " * "
                + pozycja.CenaDecimal + " = "
                + (pozycja.CenaDecimal * pozycja.Ilosc.Value) + ")";
        }

        private XElement StworzElementZWartoscia(string nazwa, string wartosc)
        {
            var element = new XElement(nazwa);
            element.Add(new XText(wartosc));
            return element;
        }
    }
}