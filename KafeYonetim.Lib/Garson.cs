using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KafeYonetim.Lib
{
    public class Garson : Calisan
    {
        public Garson(string isim, DateTime girisTarihi, Kafe kafe, string gorev): base(isim, girisTarihi, kafe, gorev)
        {

        }

        public float Bahsis { get; set; }

        public void MasaAc()
        {
            Console.WriteLine("Masa açıldı");
        }

        public void SiparisAl(Siparis siparis)
        {
            Siparisler.Add(siparis);
            Asci asci = Kafe.UygunAsciBul(CalisanDurum.Mesgul);

            Console.WriteLine("Siparis alındı");
        }

        public void SiparisiServisEt()
        {
            Console.WriteLine("Siparis servis edildi.");
        }

        public void OdemeAl()
        {
            Console.WriteLine("Ödeme alındı");
        }
    }
}
