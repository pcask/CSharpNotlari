using System;

namespace KafeYonetim.Lib
{
    public class Masa
    {
        public Masa(int masaNo)
        {
            MasaNo = masaNo;
        }


        public int MasaNo { get; private set; }
        public Siparis Siparis { get; set; }
        public MasaDurum Durum { get; set; }
        public Garson Garson { get; set; }

        public void GarsonCagir(Garson garson)
        {
            Garson = garson;
            Console.WriteLine("Garson geldi.");
        }

        public void SiparisVer()
        {
            Console.WriteLine("Siparis verildi.");
        }

        public void OdemeYap()
        {
            Console.WriteLine("Ödeme yapıldı.");
        }
    }
}