using System.Collections.Generic;
using Zakupy.Dane;

namespace Zakupy.Sumowanie
{
    public class Sumowacz
    {
        public WczytaneZamowienie SumujZamowienia(
            IList<WczytaneZamowienie> zamowienia,
            IList<string> warningi)
        {
            var wynik = new WczytaneZamowienie(zamowienia[0]);
            wynik.WyczyscIlosci();

            foreach (var z in zamowienia)
                DodajZamowienieDoWyniku(z, wynik, warningi);

            return wynik;
        }

        private void DodajZamowienieDoWyniku(
            WczytaneZamowienie zamowienie,
            WczytaneZamowienie wynik,
            IList<string> warningi)
        {
            foreach (var grupa in zamowienie.GrupyProduktow)
                foreach(var p in grupa.Pozycje)
                {
                    if (p.Ilosc.HasValue && p.Ilosc > 0)
                    {
                        var pozycjaWyniku =
                           SzukajPozycjiZamowieniaWgPozycja(wynik, p);
                        if (pozycjaWyniku != null)
                            pozycjaWyniku.ZwiekszIlosc(p.Ilosc.Value);
                        else
                            warningi.Add("Nie można znaleźć pozycji "
                               + p.NumerPozycjiWExcelu + " - " + p.Nazwa
                               + " Ilość: " + p.Ilosc);
                    }
                }
        }

        private Pozycja SzukajPozycjiZamowieniaWgPozycja(
            WczytaneZamowienie zamowienie,
            Pozycja pozycjaWgKtorej)
        {
            foreach (var grupa in zamowienie.GrupyProduktow)
                foreach (var pozycja in grupa.Pozycje)
                    if (TakieSamePozycje(pozycja, pozycjaWgKtorej))
                        return pozycja;
            return null;
        }

        private bool TakieSamePozycje(Pozycja pozycja, Pozycja pozycjaWgKtorej)
        {
            return pozycja.Nazwa == pozycjaWgKtorej.Nazwa;
        }
    }
}
