using System;
using System.Linq;
using System.Windows.Forms;
using Zakupy.Dane;
using ZakupyProgram.UI;

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
                if (zamowienie != null && !string.IsNullOrEmpty(zamowienie.Nazwa))
                    Text = "Zamówienie: " + zamowienie.Nazwa;

                foreach (var grupa in zamowienie.GrupyProduktow)
                {
                    if (grupa.IstniejePozycjaZPodanaIloscia())
                    {
                        var node = new GrupaTreeNode(grupa);
                        treeView1.Nodes.Add(node);
                        DodajPozycjeGrupy(node, grupa);
                    }
                }

                textBoxWartosc.Text = zamowienie.Wartosc.ToString();
            }
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
