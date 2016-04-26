using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using Zakupy.Dane;
using Zakupy.Podsumowanie;
using Zakupy.Sumowanie;
using Zakupy.Wczytywanie;

namespace ZakupyProgram
{
    public partial class OknoGlowne : Form
    {
        public OknoGlowne()
        {
            InitializeComponent();
            WypelnijListePlikow();
        }

        private void WypelnijListePlikow()
        {
            var pliki = Directory.GetFiles(".", "*.xlsx");
            foreach (var plik in pliki)
            {
                var fileInfo = new FileInfo(plik);
                var item = new ListViewItem(fileInfo.Name);
                listView1.Items.Add(item);
            }
        }

        private void button4_Click(object sender, System.EventArgs e)
        {
            var listaPlikow = new List<WczytaneZamowienie>();
            var wczytywacz = new WczytywaczExcela();
            foreach (ListViewItem item in listView1.Items)
            {
                var nazwaPliku = item.Text;
                listaPlikow.Add(wczytywacz.Wczytaj(nazwaPliku));
            }

            var sumowacz = new Sumowacz();
            var ostrzezenia = new List<string>();
            var zsumowaneZamowienie = sumowacz.SumujZamowienia(listaPlikow, ostrzezenia);
            zsumowaneZamowienie.Nazwa = "Sumaryczne zamówienie";
            var oknoSumowania = new OknoZamowienia();
            oknoSumowania.Zamowienie = zsumowaneZamowienie;
            oknoSumowania.ShowDialog();
        }

        private void buttonPokaz_Click(object sender, System.EventArgs e)
        {
            var okno = new OknoZamowienia();

            var wczytywacz = new WczytywaczExcela();

            if (listView1.SelectedItems.Count > 0)
            {
                var wybrany = listView1.SelectedItems[0];
                okno.Zamowienie = wczytywacz.Wczytaj(listView1.SelectedItems[0].Text);
                okno.Show();
                wybrany.Selected = true;
                listView1.Select();
            }
        }

        private void buttonZapiszHtml_Click(object sender, System.EventArgs e)
        {
            const string sciezkaHtml = "html";
            var generatorHtml = new GeneratorHtml();
            var wczytywacz = new WczytywaczExcela();
            foreach (ListViewItem item in listView1.SelectedItems)
            {
                if (!Directory.Exists(sciezkaHtml))
                    Directory.CreateDirectory(sciezkaHtml);
                var zamowienie = wczytywacz.Wczytaj(item.Text);

                var nazwaPliku = Path.Combine(sciezkaHtml, item.Text + ".html");
                using (var fs = new FileStream(nazwaPliku, FileMode.Create))
                using (var writer = new StreamWriter(fs))
                {
                    generatorHtml.Generuj(zamowienie, writer);
                }
            }
        }
    }
}