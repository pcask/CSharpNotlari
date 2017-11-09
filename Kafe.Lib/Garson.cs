using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KafeYonetim.Lib
{
    public class Garson: Calisan
    {
        public Garson(string i, DateTime g, Kafe k): base(i, g, k)
        {

        }

        public void MasaAc()
        {
            Console.WriteLine("Masa açıldı.");
        }

        public void SiparisAl(Siparis siparis)
        {
            Siparisler.Add(siparis);
            Asci asci = Kafe.UygunAsciBul(CalisanDurum.Uygun);//OVERLOAD
            asci.SiparisiHazirla(siparis);

            Console.WriteLine("Sipariş alındı.");
        }

        public void SiparisiServisEt()
        {
            Console.WriteLine("Sipariş servis edildi.");
        }

        public void OdemeAl()
        {
            Console.WriteLine("Ödeme alındı.");
        }
    }
}
