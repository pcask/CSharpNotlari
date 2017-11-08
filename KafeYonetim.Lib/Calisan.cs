using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KafeYonetim.Lib
{
    public class Calisan
    {
        public Calisan(string isim, DateTime girisTarihi)
        {
            Isim = isim;
            IseGirisTarihi = girisTarihi;
            MesaideMi = false;
        }

        public string Isim { get; private set; }
        public DateTime IseGirisTarihi { get; private set; }
        public bool MesaideMi { get; private set; }
        public CalisanDurum Durum { get; set; }
        public Siparis[] Siparisler { get; set; }

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
