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
            kafe.Ac();
            

            ConsoleKeyInfo secim;
            do
            {
                MenuYazdir();

                Console.Write("Lütfen Yapmak İstediğiniz İşlem Numarasını Giriniz :");

                secim = Console.ReadKey();

                switch (secim.KeyChar)
                {
                    case '1': MasayaGarsonCagir(kafe);
                        break;
                    case '2':
                        GarsonuMasadanGonder(kafe);
                        break;
                    case '3':
                        SiparisVer(kafe);
                        break;
                    default:
                        break;
                }

            } while (secim.KeyChar != '0');


            Console.ReadLine();
        }

        public static void MasayaGarsonCagir(Kafe kafe)
        {
            Console.Write("\nMasa numarasını belirtin :");
            int masaNo = int.Parse(Console.ReadLine());

            kafe.Masalar[masaNo].GarsonCagir();
        }

        public static void GarsonuMasadanGonder(Kafe kafe)
        {
            Console.Clear();
            Console.Write("Masa numarası giriniz :");
            int masaNo = int.Parse(Console.ReadLine());
            kafe.Masalar[masaNo].GarsonuSerbestBirak();
            Console.WriteLine("Garson Gitti");

        }

        public static void MenuYazdir()
        {
            Console.WriteLine("\nMenü");
            Console.WriteLine("1. Garson Çağır.");
            Console.WriteLine("2. Garsonu Serbest Bırak");
            Console.WriteLine("3. Garsona Sipariş Ver");
            Console.WriteLine("0. Uygulamayı Kapat");
            Console.WriteLine("");

        }

        public static void SiparisVer()
        {

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
            kafe.Urunler.Add(new Urun("Çay", 9.00f, true));
            kafe.Urunler.Add(new Urun("Kahve", 12.00f, true));
            kafe.Urunler.Add(new Urun("Gazoz", 12.00f, true));
            kafe.Urunler.Add(new Urun("Tombalıklı Sandwich", 16.00f, true));
            kafe.Urunler.Add(new Urun("Pekin Usulü Ördek", 150.00f, true));
        }               

        public static void KafeyeCalisanEkle(Kafe kafe)
        {
            kafe.Calisanlar.Add(new Garson("Ahmet", new DateTime(2017, 11, 08)));
            kafe.Calisanlar.Add(new Garson("Mehmet", new DateTime(2017, 11, 08)));
            kafe.Calisanlar.Add(new Asci("Berk", new DateTime(2017, 11, 08)));
        }

        public static void KafeyeMasaEkle(Kafe kafe)
        {
            kafe.Masalar.Add(new Masa(1, kafe));
            kafe.Masalar.Add(new Masa(2, kafe));
            kafe.Masalar.Add(new Masa(3, kafe));
            kafe.Masalar.Add(new Masa(4, kafe));
        }
    }
}
