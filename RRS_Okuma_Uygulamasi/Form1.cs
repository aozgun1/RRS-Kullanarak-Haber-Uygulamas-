using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace RRS_Okuma_Uygulamasi
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btn_getir_Click(object sender, EventArgs e)
        {
            List<Haber> Kayitlar = XMLCevir();
            lst_baslik.DataSource = Kayitlar;
        }

        private List<Haber> XMLCevir()
        { 
            List<Haber> HaberKayitlari = new List<Haber>(); //Elementlerin değeri Haber sınıfındaki field'lara atandıltan sonra burada List Generic olarak tutacak.

            XDocument XMLKaynak = XDocument.Load(txt_rrsurl.Text); // TextBox içindeki URL <XDocument> formatına alındı.
            List<XElement> Rows = XMLKaynak.Descendants("item").ToList(); // item node üzerinden parçalandı.
            foreach (XElement item in Rows) 
            {
                Haber Temp = new Haber();
                Temp.Baslik = item.Element("title").Value;
                Temp.Link = item.Element("link").Value;
                Temp.Aciklama = item.Element("description").Value;
                HaberKayitlari.Add(Temp);
            }
            return HaberKayitlari;
        }

        private void lst_baslik_SelectedIndexChanged(object sender, EventArgs e) //Haber başlıkları indeksi seçildiğinde(event) WebBrowser a çıktısı çıkacak.
        {
            ListBox Secilen_Deger = (ListBox)sender; //sender cast edililip listbox tipinden değere atandı.
            Haber Secilen_Haber = (Haber)Secilen_Deger.SelectedItem; // Haber class ına cast edildi ve 
            web_browser.DocumentText = Secilen_Haber.Aciklama; // Haber açıklaması WebBrowsere atandı.
        }
    }
}
