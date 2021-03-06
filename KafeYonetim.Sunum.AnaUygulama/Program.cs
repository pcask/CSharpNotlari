﻿using System;
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
            // 210 tane Garson Eklendi
            CokluGarsonEkle();

            do
            {
                Console.Clear();

                Console.WriteLine("1. Ürün Listesini Getir");
                Console.WriteLine("2. Eşik Değerden Yüksek Fiyatlı Ürünlerin Listesini Getir");
                Console.WriteLine("3. Ürün Ekle");
                Console.WriteLine("4. Stokta Olmayan Ürünleri Getir");
                Console.WriteLine("5. Ürün Sil");
                Console.WriteLine("6. Masa Sayısı ve Toplam Kapasite Bilgisini Getir");
                Console.WriteLine("7. Masa Ekle");
                Console.WriteLine("8. Garson Ekle");
                Console.WriteLine("9. Aşçı Ekle");
                Console.WriteLine("10. Bulaşıkçı Ekle");
                Console.WriteLine("11. Çalışanlari Listele");
                Console.WriteLine("12. Garsonları Listele");
                Console.WriteLine("13. Garsonları Sayfalı Listele");
                Console.WriteLine();
                Console.Write("Bir seçim yapınız (çıkmak için H harfine basınız): ");
                var secim = Console.ReadLine();

                switch (secim)
                {
                    case "1": UrunListesiniYazdir(); break;
                    case "2": DegerdenYuksekFiyatliUrunleriGetir(); break;
                    case "3": UrunGir(); break;
                    case "4": StoktaOlmayanUrunleriGetir(); break;
                    case "5": UrunleriSil(); break;
                    case "6": MasaSayisiVeToplamKapasiteYazdir(); break;
                    case "7": MasaEkle(); break;
                    case "8": GarsonEkle(); break;
                    case "9": AsciEkle(); break;
                    case "10": BulasikciEkle(); break;
                    case "11": CalisanlariListele(); break;
                    case "12": GarsonlariListele(DataManager.GarsonlariGetir()); break;
                    case "13": GarsonlariSayfaliListele(); break;
                    case "h": return;
                    default:
                        break;
                }

                Console.ReadLine();

            } while (true);
        }

        private static List<string> basliklar = new List<string>() { "ID", "Ad", "Fiyat", "Stok" };

        private static void UrunleriFormatliYazdir(List<Urun> urunler, List<string> basliklar)
        {
            foreach (var baslik in basliklar)
            {
                Console.Write(baslik.PadRight(20));
            }
            Console.WriteLine("\n");

            foreach (var urun in urunler)
            {
                Console.Write($"{urun.ID}".PadRight(25));
                Console.Write($"{urun.Ad}".PadRight(25));
                Console.Write($"{urun.Fiyat}".PadRight(15));
                Console.Write($"{urun.StoktaVarMi}".PadRight(7));
                Console.WriteLine();
            }

            Console.WriteLine();
        }

        //private static void MasaEkle()
        //{
        //    Console.Clear();

        //    Console.Write("Masa No:");
        //    int masaNo = int.Parse(Console.ReadLine());

        //    Console.Write("Kafe ID:");
        //    int kafeID = int.Parse(Console.ReadLine());

        //    Console.Write("Masa Durumu:");
        //    string durum = Console.ReadLine();

        //    if (DataManager.MasaEkle(masaNo, kafeID, durum))
        //        Console.WriteLine("Masa Başarıyla Eklendi");
        //    else
        //        Console.WriteLine("Masa Eklenirken Bir Hata Oluştu!!!");

        //    Console.ReadLine();
        //}

        private static void MasaEkle()
        {
            Console.Clear();

            KafeleriListele();

            Console.Write("Lütfen Yukarıdaki Listeden Masanın Ekleneceği Kafenin ID Bilgisini Giriniz: ");
            string kafeID = Console.ReadLine();

            Console.Write("Masa No: ");
            string masaNo = Console.ReadLine();

            Console.Write("Kapasitesi: ");
            byte kapasite = byte.Parse(Console.ReadLine());

            Masa masa = new Masa(masaNo, DataManager.KafeGetir(kafeID));
            masa.KisiSayisi = kapasite;
            masa.Durum = MasaDurum.Bos;

            int masaID = DataManager.MasaEkle(masa);

            Console.WriteLine("Masa Başarıyla Eklendi");
        }

        private static void KafeleriListele()
        {
            List<Kafe> kafeler = DataManager.KafeleriGetir();

            Console.WriteLine("Kafeler\n".PadLeft(40));

            Console.Write("ID".PadRight(20));
            Console.Write("Ad".PadRight(20));
            Console.Write("Acilis Saati".PadRight(20));
            Console.Write("Kapaniş Saati".PadRight(20));
            Console.WriteLine();

            foreach (var kafe in kafeler)
            {
                Console.Write($"{kafe.ID}".PadRight(20));
                Console.Write($"{kafe.Ad}".PadRight(20));
                Console.Write($"{kafe.AcilisSaati}".PadRight(20));
                Console.Write($"{kafe.KapanisSaati}".PadRight(20));
                Console.WriteLine();
            }

            Console.WriteLine();

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
                Console.WriteLine("Ürün başarıyla eklendi.");
            else
                Console.WriteLine("Ürün eklenirken bir hata oluştu...");

            Console.ReadLine();
        }

        private static void MasaSayisiVeToplamKapasiteYazdir()
        {
            Tuple<int, int> masaBilgileri = DataManager.MasaSayisiVeToplamKapasiteGetir();

            Console.WriteLine($"{masaBilgileri.Item1} Adet Masa ve Toplamda {masaBilgileri.Item2} Kapasiteye Sahip");
        }

        private static void DegerdenYuksekFiyatliUrunleriGetir()
        {
            Console.Clear();
            Console.Write("Eşik Değeri giriniz: ");
            var doubleEsikDeger = double.Parse(Console.ReadLine());

            var liste = DataManager.DegerdenYuksekFiyatliUrunleriGetir(doubleEsikDeger);

            Console.Clear();

            Console.WriteLine($"Ürün Listesi Eşik Değerli ({doubleEsikDeger})\n".PadLeft(35));

            UrunleriFormatliYazdir(liste, basliklar);
        }

        private static void StoktaOlmayanUrunleriGetir()
        {
            List<Urun> urunler = DataManager.StoktaOlmayanUrunleriGetir();

            Console.WriteLine($"Stokta Olmayan Ürünler".PadLeft(35));

            UrunleriFormatliYazdir(urunler, basliklar);
        }

        private static void UrunListesiniYazdir()
        {
            List<Urun> urunler = DataManager.UrunleriGetir();

            Console.WriteLine("Ürün Listesi\n".PadLeft(30));

            UrunleriFormatliYazdir(urunler, basliklar);
        }

        private static void UrunleriSil()
        {
            UrunListesiniYazdir();

            Console.Write("Silmek istediğiniz ürünlerin Id'lerini virgül ile ayırarak yazınız: ");

            string idList = Console.ReadLine();

            Console.WriteLine(DataManager.SecilenUrunleriSil(idList) + " Adet Ürün Silindi");

            UrunListesiniYazdir();
        }

        private static void GarsonEkle()
        {
            Console.Clear();

            Console.Write("Adı :");
            string ad = Console.ReadLine();

            Garson garson = new Garson(ad, DateTime.Now, DataManager.AktifKafeyiGetir());
            garson.Durum = CalisanDurum.Uygun;

            int sonuc = DataManager.GarsonEkle(garson);

            Console.WriteLine((sonuc > 0) ? "Garson Başarılı Bir Şekilde Eklendi" : "Garson Ekleme Başarısız!!");
        }

        private static void AsciEkle()
        {
            Console.Clear();

            Console.Write("Adı :");
            string ad = Console.ReadLine();

            Asci asci = new Asci(ad, DateTime.Now, DataManager.AktifKafeyiGetir());
            asci.Durum = CalisanDurum.Uygun;

            int eklenenCalisanID = DataManager.AsciEkle(asci);

            Console.WriteLine((eklenenCalisanID > 0) ? $"Aşçı {eklenenCalisanID} id'si ile Başarılı Bir Şekilde Eklendi" : "Aşçı Ekleme Başarısız!!");
        }
        private static void BulasikciEkle()
        {
            Console.Clear();

            Console.Write("Adı :");
            string ad = Console.ReadLine();

            Bulasikci bulasikci = new Bulasikci(ad, DateTime.Now, DataManager.AktifKafeyiGetir());

            bulasikci.Durum = CalisanDurum.Uygun;

            int eklenenCalisanID = DataManager.BulasikciEkle(bulasikci);

            Console.WriteLine((eklenenCalisanID > 0) ? $"Bulaşıkçı {eklenenCalisanID} id'si ile Başarılı Bir Şekilde Eklendi" : "Bulaşıkçı Ekleme İşlemi Başarısız!!");
        }

        private static void CalisanlariListele()
        {
            Console.Clear();

            List<Calisan> calisanlar = DataManager.CalisanlariGetir();

            Console.WriteLine("Çalışanlar Listesi\n".PadLeft(40));

            Console.Write("ID".PadRight(8));
            Console.Write("Ad".PadRight(15));
            Console.Write("İşe Giriş Tarihi".PadRight(20));
            Console.Write("Görevi".PadRight(20));
            Console.WriteLine("\n");

            foreach (var calisan in calisanlar)
            {
                Console.Write($"{calisan.ID}".PadRight(8));
                Console.Write($"{calisan.Ad}".PadRight(15));
                Console.Write($"{calisan.IseGirisTarihi.ToString("dd-MM-yyyy")}".PadRight(20));
                Console.Write($"{calisan.Gorev.GorevAdi}".PadRight(20));

                Console.WriteLine();
            }
        }

        private static void CokluGarsonEkle()
        {
            Random rnd = new Random();

            for (int i = 0; i < 210; i++)
            {
                Garson garson = new Garson(FakeData.NameData.GetFirstName(), DateTime.Now, DataManager.AktifKafeyiGetir());

                garson.Bahsis = rnd.Next(0, 100);

                DataManager.GarsonEkle(garson);
            }
        }

        private static void GarsonlariSayfaliListele()
        {
            List<Garson> garsonlar = DataManager.SayfaNumarasiIleGarsonlariGetir(1, 20);

            GarsonlariListele(garsonlar);

            int toplamSayfaSayisi = DataManager.ToplamSayfaSayisiniGetir();
            Console.WriteLine("\nToplam Sayfa Saysı: " + toplamSayfaSayisi);
            Console.Write("\nLütfen Görmek İstediğiniz Sayfanın Numarasını Giriniz: ");

            int sayfaNumarasi = int.Parse(Console.ReadLine());

            if (sayfaNumarasi >= 1 && sayfaNumarasi <= toplamSayfaSayisi)
            {
                garsonlar = DataManager.SayfaNumarasiIleGarsonlariGetir(sayfaNumarasi, 20);

                GarsonlariListele(garsonlar);
            }
            else
                Console.WriteLine("Lütfen Geçerli Bir Sayfa Numarası Giriniz");
        }

        private static void GarsonlariListele(List<Garson> garsonlar)
        {
            Console.Clear();

            Console.WriteLine("Garsonlar\n".PadLeft(30));

            Console.Write("ID");
            Console.Write("Ad".PadLeft(10));
            Console.Write("İşe Giriş Tarihi".PadLeft(23));
            Console.Write("Bahşiş".PadLeft(10));

            Console.WriteLine("\n");

            foreach (var garson in garsonlar)
            {
                Console.Write($"{garson.ID}");
                Console.Write($"{garson.Ad}".PadLeft(13));
                Console.Write($"{garson.IseGirisTarihi.ToString("dd-MM-yyyy")}".PadLeft(15));
                Console.Write($"{garson.Bahsis}".PadLeft(15));

                Console.WriteLine();
            }
        }
    }
}
