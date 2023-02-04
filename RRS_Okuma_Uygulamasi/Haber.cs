using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RRS_Okuma_Uygulamasi
{
    internal class Haber
    {
        public string Baslik { get; set; }
        public string Link { get; set; }
        public string Aciklama { get; set; }

        public override string ToString() //Haber başlıklarındaki 'title' lar namespace ekrana basmamsı için 'override' edildi.
        {
            return Baslik;
        }
    }
}
