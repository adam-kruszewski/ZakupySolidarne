using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using BrightIdeasSoftware;
using Zakupy.Dane;
using ZakupyProgram.ViewModels;

namespace ZakupyProgram
{
    public partial class OknoZamowienia2 : Form
    {
        OLVColumn kolumnaLP;
        OLVColumn kolumnaNazwa;

        public WczytaneZamowienie Zamowienie
        {
            set { UstawZamowienie(value); }
        }

        public OknoZamowienia2()
        {
            InitializeComponent();
        }

        private void UstawZamowienie(WczytaneZamowienie value)
        {
            var zamowienie = value;
            var model = PrzygotujModel(zamowienie);
            objectListView1.SetObjects(model);
            SkonfigurujListe();
            textBox1.Text = zamowienie.Wartosc.ToString();
        }

        private void SkonfigurujListe()
        {
            DodajKolumny();

            objectListView1.ShowGroups = true;
            objectListView1.HasCollapsibleGroups = true;
            objectListView1.HeaderStyle = ColumnHeaderStyle.Nonclickable;

            objectListView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.None);
            objectListView1.RebuildColumns();
            objectListView1.BuildGroups(kolumnaNazwa, SortOrder.None);
            objectListView1.Sort(kolumnaLP, SortOrder.Ascending);
            objectListView1.Update();
        }

        private void DodajKolumny()
        {
            kolumnaLP = DodajKolumne("NumerPozycjiWExcelu", "Lp");
            kolumnaNazwa = DodajKolumne("Nazwa", "Nazwa");
            kolumnaNazwa.Groupable = true;
            DodajKolumne("Cena", "Cena");
            DodajKolumne("Ilosc", "Ilość");
            DodajKolumne("Wartosc", "Wartość");

            foreach (var olvColumn in objectListView1.AllColumns)
            {
                olvColumn.GroupKeyGetter = delegate(object r)
                {
                    var pozycja = r as PozycjaZamowieniaView;
                    return pozycja.NumerGrupy.ToString("00") + ". " + pozycja.Grupa;
                };
            }
        }

        private OLVColumn DodajKolumne(string aspect, string text)
        {
            var col1 = new OLVColumn();
            col1.AspectName = aspect;
            col1.Groupable = false;
            col1.Text = text;
            objectListView1.AllColumns.Add(col1);

            this.objectListView1.Columns.AddRange(
                new System.Windows.Forms.ColumnHeader[] { col1 });
            return col1;
        }

        private List<PozycjaZamowieniaView> PrzygotujModel(WczytaneZamowienie zamowienie)
        {
            var wynik = new List<PozycjaZamowieniaView>();
            //foreach (var grupa in zamowienie.GrupyProduktow)
            for (int i = 0; i < zamowienie.GrupyProduktow.Count; i++)
            {
                var grupa = zamowienie.GrupyProduktow[i];
                if (grupa.IstniejePozycjaZPodanaIloscia())
                {
                    foreach (var pozycja in
                        grupa.Pozycje.Where(o => o.Ilosc.HasValue && o.Ilosc > 0))
                        wynik.Add(new PozycjaZamowieniaView(grupa, pozycja, i + 1));
                }
            }
            return wynik;
        }

        private string DajOpisIlosci(GrupaProduktow grupa)
        {
            var ile = grupa.Pozycje.Where(o => o.Ilosc > 0).Sum(o => o.Ilosc);
            return " Liczba zamówionych = " + ile;
        }

        private void DodajPozycjeGrupy(TreeNode node, GrupaProduktow grupa)
        {
            foreach (var pozycja in grupa.Pozycje)
            {
                if (pozycja.Ilosc.HasValue && pozycja.Ilosc > 0)
                {
                    string text = "[" + pozycja.NumerPozycjiWExcelu + "]"
                        + " ilość " + pozycja.Ilosc +
                        " :: " + pozycja.Nazwa;
                    var nodePozycji = new TreeNode(text);

                    node.Nodes.Add(nodePozycji);
                }
            }
        }

        private void buttonZamknij_Click(object sender, EventArgs e)
        {
            Close();
        }

        private class Linia
        {
            public Linia()
            {
                Napis = "etykieta";
                Napis2 = "drugi napis";
            }

            public Linia(string napis)
                : this()
            {
                Napis = napis;
            }

            public string Napis { get; set; }
            public string Napis2 { get; set; }
        }
    }
}
