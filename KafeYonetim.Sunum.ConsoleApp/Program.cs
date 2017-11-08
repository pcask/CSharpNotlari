using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KafeYonetim.Lib;

namespace KafeYonetim.Sunum.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var kafe = KafeInstanceOlustur();

            KafeyeUrunEkle(kafe);
            KafeyeCalisanEkle(kafe);
            KafeyeMasaEkle(kafe);


            ConsoleKeyInfo secim;
            do
            {
                MenuYazdir();

                secim = Console.ReadKey();

                switch (secim.KeyChar)
                {
                    case '1': MasayaGarsonCagir();
                        break;
                    default:
                        break;
                }

            } while (secim.KeyChar != '0');


            Console.ReadLine();
        }

        public static void MasayaGarsonCagir()
        {
            Console.WriteLine("Masa numarasını belirtin :");
            int masaNo = int.Parse(Console.ReadLine());
        }

        public static void MenuYazdir()
        {
            Console.WriteLine("Menü");
            Console.WriteLine("1. Garson Çağır.");
            Console.WriteLine("2. Garsona Sipariş Ver ");
            Console.WriteLine("");
        }

        public static Kafe KafeInstanceOlustur()
        {
            var kafe = new Kafe("Bizim Cafe", "09:00", "22:00");

            Console.WriteLine("Kafe");
            Console.WriteLine($"\tAd: {kafe.Ad}");
            Console.WriteLine($"\tDurum: {kafe.Durum}");

            return kafe;
        }

        public static void KafeyeUrunEkle(Kafe kafe)
        {
            kafe.Urunler[0] = new Urun("Çay", 9.00f, true);
            kafe.Urunler[1] = new Urun("Kahve", 12.00f, true);
            kafe.Urunler[2] = new Urun("Gazoz", 12.00f, true);
            kafe.Urunler[3] = new Urun("Tombalıklı Sandwich", 16.00f, true);
            kafe.Urunler[4] = new Urun("Pekin Usulü Ördek", 150.00f, true);
        }

        public static void KafeyeCalisanEkle(Kafe kafe)
        {
            kafe.Calisanlar[0] = new Garson("Ahmet", new DateTime(2017, 11, 08));
            kafe.Calisanlar[1] = new Garson("Mehmet", new DateTime(2017, 11, 08));
            kafe.Calisanlar[2] = new Asci("Berk", new DateTime(2017, 11, 08));
        }

        public static void KafeyeMasaEkle(Kafe kafe)
        {
            kafe.Masalar[0] = new Masa(1);
            kafe.Masalar[1] = new Masa(2);
            kafe.Masalar[2] = new Masa(3);
            kafe.Masalar[3] = new Masa(4);
        }
    }
}
