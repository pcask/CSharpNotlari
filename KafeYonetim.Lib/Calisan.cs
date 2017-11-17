using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KafeYonetim.Lib
{
    public class Calisan
    {
        public Calisan(string ad, DateTime girisTarihi, Kafe kafe)
        {
            Ad = ad;
            IseGirisTarihi = girisTarihi;
            MesaideMi = false;
            Kafe = kafe;
            Gorev = new Gorev();
        }

        public int ID { get; set; }
        public string Ad { get; private set; }
        public DateTime IseGirisTarihi { get; private set; }
        public bool MesaideMi { get; private set; }
        public CalisanDurum Durum { get; set; }
        public List<Siparis> Siparisler { get; set; }
        public Kafe Kafe { get; set; }
        public Gorev Gorev { get; set; }

        public void MesaiyeBasla()
        {
            MesaideMi = true;
        }

        public void MesaiBitir()
        {
            MesaideMi = false;
        }
    }
}
