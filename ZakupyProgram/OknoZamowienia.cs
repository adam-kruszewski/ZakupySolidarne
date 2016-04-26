using System;
using System.Linq;
using System.Windows.Forms;
using Zakupy.Dane;

namespace ZakupyProgram
{
    public partial class OknoZamowienia : Form
    {
        public OknoZamowienia()
        {
            InitializeComponent();
        }

        private WczytaneZamowienie zamowienie;
        public WczytaneZamowienie Zamowienie
        {
            get
            {
                return zamowienie;
            }
            set
            {
                zamowienie = value;
                foreach (var grupa in zamowienie.GrupyProduktow)
                {
                    if (grupa.IstniejePozycjaZPodanaIloscia())
                    {
                        var node = new TreeNode(grupa.Nazwa + " " + DajOpisIlosci(grupa));
                        treeView1.Nodes.Add(node);
                        DodajPozycjeGrupy(node, grupa);
                    }
                }

                textBoxWartosc.Text = zamowienie.Wartosc.ToString();
            }
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

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
