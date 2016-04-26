using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Zakupy.Dane;

namespace ZakupyProgram.UI
{
    class GrupaTreeNode : TreeNode
    {
        private readonly GrupaProduktow grupa;

        public GrupaTreeNode(
            GrupaProduktow grupa)
            : base(grupa.Nazwa + " " + DajOpisIlosci(grupa))
        {
            this.grupa = grupa;

            if (!grupa.MinimalneIlosci.HasValue ||
                grupa.MinimalneIlosci <= grupa.LiczbaPozycji())
                UstawKolorTekstu(Color.Green);
            else
            {
                UstawKolorTekstu(Color.Red);
                Text = "!!! " + Text;
            }
        }

        private void UstawKolorTekstu(Color kolor)
        {
            ForeColor = kolor;
        }

        private static string DajOpisIlosci(GrupaProduktow grupa)
        {
            var ile = grupa.Pozycje.Where(o => o.Ilosc > 0).Sum(o => o.Ilosc);
            return " Liczba zamówionych = " + ile;
        }
    }
}