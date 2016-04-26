using Zakupy.Dane;

namespace ZakupyProgram.ViewModels
{
    class PozycjaZamowieniaView
    {
        public int NumerPozycjiWExcelu { get; set; }

        public string Nazwa { get; set; }

        public int Ilosc { get; set; }

        public decimal Cena { get; set; }

        public decimal Wartosc { get; set; }

        public string Grupa { get; set; }

        public int NumerGrupy { get; set; }

        public PozycjaZamowieniaView(
            GrupaProduktow grupa,
            Pozycja pozycja,
            int numerGrupy)
        {
            NumerPozycjiWExcelu = pozycja.NumerPozycjiWExcelu;
            Nazwa = pozycja.Nazwa;
            Ilosc = pozycja.Ilosc.Value;
            Cena = pozycja.CenaDecimal;
            Wartosc = pozycja.CenaDecimal * pozycja.Ilosc.Value;

            Grupa = grupa.Nazwa;
            NumerGrupy = numerGrupy;
        }
    }
}