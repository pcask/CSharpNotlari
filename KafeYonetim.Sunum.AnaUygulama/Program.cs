using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KafeYonetim.Data;
using KafeYonetim.Lib;

namespace KafeYonetim.Sunum.AnaUygulama
{
    class Program
    {
        static void Main(string[] args)
        {
            //DataManager dm = new DataManager();

            //dm.KafeBilgisiniYazdir();

            //dm.UrunEkle();

            //Console.WriteLine("\n************************\n");

            //dm.UrunListesiniYazdir();

            DegerdenYuksekFiyatliUrunleriGetir();

            Console.WriteLine("\n*************************\n");

            UrunListesiniYazdir();

            Console.ReadLine();
        }

        private static List<string> basliklar = new List<string>() { "Ad", "Fiyat", "Stok" };

        private static void BaslikFormatliYazdir(List<string> basliklar)
        {
            foreach (var baslik in basliklar)
            {
                Console.Write(baslik.PadRight(20));
            }
            Console.WriteLine();
        }

        private static void UrunFormatliYazdir(List<Urun> urunler)
        {
            foreach (var urun in urunler)
            {
                Console.Write($"{urun.Ad}".PadRight(25));
                Console.Write($"{urun.Fiyat}".PadRight(15));
                Console.Write($"{urun.StoktaVarMi}".PadRight(7));
                Console.WriteLine();

            }
        }


        private static void DegerdenYuksekFiyatliUrunleriGetir()
        {
            Console.Clear();
            Console.Write("Eşik Değeri giriniz: ");
            var doubleEsikDeger = double.Parse(Console.ReadLine());

            var liste = DataManager.DegerdenYuksekFiyatliUrunleriGetir(doubleEsikDeger);

            Console.Clear();

            //Console.Write("Id".PadLeft(7));
            BaslikFormatliYazdir(basliklar);

            UrunFormatliYazdir(liste);
        }

        private static void UrunGir()
        {
            Console.Clear();

            Console.Write("Ürün Adı:");
            string urunAdi = Console.ReadLine();

            Console.Write("Fiyat:");
            double fiyat = double.Parse(Console.ReadLine());

            Console.Write("Stokta Var mı (E/H):");
            bool stokDurumu = Console.ReadLine().ToUpper() == "E";

            if (DataManager.UrunGir(urunAdi, fiyat, stokDurumu))
            {
                Console.WriteLine("Ürün başarıyla eklendi.");
            }
            else
            {
                Console.WriteLine("Ürün eklenirken bir hata oluştu...");
            }

            Console.ReadLine();
        }

        private static void UrunListesiniYazdir()
        {
            List<Urun> urunler = DataManager.UrunListesiniYazdir();

            BaslikFormatliYazdir(basliklar);

            UrunFormatliYazdir(urunler);
        }
    }
}
