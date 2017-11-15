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
            DataManager dm = new DataManager();

            dm.KafeBilgisiniYazdir();

            dm.UrunEkle();

            Console.WriteLine("\n************************\n");

            dm.UrunListesiniYazdir();




            Console.ReadLine();
        }

        private static void DegerdenYuksekFiyatliUrunleriGetir()
        {

            Console.Clear();
            Console.Write("Eşik Değeri giriniz: ");
            var doubleEsikDeger = double.Parse(Console.ReadLine());

            var liste = DataManager.DegerdenYuksekFiyatliUrunleriGetir(doubleEsikDeger);

            Console.Clear();

            //Console.Write("Id".PadLeft(7));
            Console.Write("Ad".PadRight(25));
            Console.Write("Fiyat".PadRight(15));
            Console.Write("Stok".PadRight(7));


            foreach (var urun in liste)
            {
                Console.WriteLine();
                //Console.Write($"{urun.ID}".PadLeft(7));
                Console.Write($"{urun.Ad}".PadRight(25));
                Console.Write($"{urun.Fiyat}".PadRight(15));
                Console.Write($"{urun.StoktaVarMi}".PadRight(7));
            }

            Console.ReadLine();

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
    }
}
