using System;

namespace KafeYonetim.Lib
{
    public class Masa
    {
        public Masa(int masaNo, Kafe kafe)
        {
            MasaNo = masaNo;
            Kafe = kafe;
        }


        public int MasaNo { get; private set; }
        public Siparis Siparis { get; set; }
        public MasaDurum Durum { get; set; }
        public Garson Garson { get; set; }
        public Kafe Kafe { get; private set; }

        public void GarsonCagir()
        {
            if (!(Garson is null))
                return;

            Garson = Kafe.UygunGarsonuBul(CalisanDurum.Masada);
            Console.WriteLine($"{MasaNo}. Masaya Garson Geldi.");
        }

        public void GarsonuSerbestBirak()
        {
            Garson.Durum = CalisanDurum.Uygun;
            Garson = null;
        }

        public void SiparisVer()
        {
            GarsonCagir();

            // ?? operatörü ilk değere bakar eğer değer Null değilse değeri atama işlemine alır. Eğer değer Null ise ikinci değeri atama işlemine alır.
            Siparis = Siparis ?? new Siparis();
            Siparis.SiparisiAlanGarson = Garson;
            Siparis.Masa = this;

            GarsonuSerbestBirak();

            Console.WriteLine("Siparis verildi.");
        }

        public void OdemeYap()
        {
            Console.WriteLine("Ödeme yapıldı.");
        }

        private void UrunSecimEkrani()
        {
            Console.Clear();
            Console.WriteLine("Ürün Seçimi");

            do
            {

                for (int i = 0; i < Kafe.Urunler.Count; i++)
                {
                    Console.WriteLine($"{i + 1 }. {Kafe.Urunler[i].Ad} - {Kafe.Urunler[i].Fiyat}");
                }

                Console.Write("Ürün Numarasını Belirtiniz: ");
                Console.WriteLine("Siparişi Tamamlamak İçin  T Harfine Basınız!");

                var secim = Console.ReadLine();

                if (secim.ToLower() == "t")
                {
                    break;
                }

                var kalem = new Kalem();
                kalem.Urun = Kafe.Urunler[int.Parse(secim)];

                Console.WriteLine();

            } while (true);
        }
    }
}