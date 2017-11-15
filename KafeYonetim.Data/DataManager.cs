using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KafeYonetim.Data
{
    public class DataManager
    {

        private static string connStr = "Data Source=DESKTOP-S3O5AOR;Initial Catalog=KafeYonetim;Integrated Security=True";

        private static SqlConnection CreateConnection()
        {
            var connection = new SqlConnection(connStr);
            connection.Open();

            return connection;
        }


        public void KafeBilgisiniYazdir()
        {
            SqlConnection connection = new SqlConnection("Data Source=DESKTOP-S3O5AOR;Initial Catalog=KafeYonetim;Integrated Security=True");

            connection.Open();

            SqlCommand cmd = new SqlCommand("SELECT TOP 1 * FROM Kafe", connection);

            // Sorgu sonucu geri değer dönmeyecekse ExecuteNonQuery
            // Sorgu sonucu tek satır tek sütün yani tek bir veri dönecekse ExecuteScalar
            // Sorgu sonucu bir satır veya daha fazla ayrıca bir sütün veya daha fazla sütün dönecekse ExecuteReader kullanılır.
            SqlDataReader result = cmd.ExecuteReader();

            result.Read();
            Console.WriteLine($"Kafe Adı: {result["Ad"]}");
            Console.WriteLine($"Kafe Durum: {result["Durum"]}");

            result.Close();
            connection.Close();
        }

        public void UrunListesiniYazdir()
        {
            SqlConnection connection = new SqlConnection("Data Source=DESKTOP-S3O5AOR;Initial Catalog=KafeYonetim;Integrated Security=True");

            connection.Open();

            SqlCommand cmd = new SqlCommand("SELECT * FROM Urunler", connection);

            var result = cmd.ExecuteReader();

            while (result.Read())
            {
                Console.WriteLine($"Urun Adı: {result["Ad"]}");
                Console.WriteLine($"Urun Fiyatı: {result["Fiyat"]}");
                Console.WriteLine($"Stokta Var Mı: {result["StoktaVarMi"]}");
                Console.WriteLine();
            }

            result.Close();
            connection.Close();
        }

        public void KafeAdınıYazdir()
        {
            SqlConnection connection = new SqlConnection("Data Source=DESKTOP-S3O5AOR;Initial Catalog=KafeYonetim;Integrated Security=True");

            connection.Open();

            SqlCommand cmd = new SqlCommand("SELECT TOP 1 * FROM Kafe", connection);

            // Sorgu sonucu geri değer dönmeyecekse ExecuteNonQuery
            // Sorgu sonucu tek satır tek sütün yani tek bir veri dönecekse ExecuteScalar
            // Sorgu sonucu bir satır veya daha fazla ayrıca bir sütün veya daha fazla sütün dönecekse ExecuteReader kullanılır.
            Object result = (string)cmd.ExecuteScalar();

            Console.WriteLine($"Kafe Adı: {result}");

            connection.Close();
        }

        public void UrunEkle()
        {
            SqlConnection connection = new SqlConnection("Data Source=DESKTOP-S3O5AOR;Initial Catalog=KafeYonetim;Integrated Security=True");

            connection.Open();

            Console.Write("Lütfen Eklemek İstediğiniz Ürünün Adını Giriniz: ");
            string urunAdi = Console.ReadLine();
            Console.Write("Lütfen Eklemek İstediğiniz Ürünün Fiyatını Giriniz: ");
            double urunFiyati = double.Parse(Console.ReadLine());
            Console.Write("Lütfen Eklemek İstediğiniz Ürünün Stok Durumunu (Var = E, Yok = H) Giriniz: ");
            bool urunStok = (Console.ReadLine().ToLower() == "e") ? true : false; 



            SqlCommand cmd = new SqlCommand("INSERT INTO Urunler (Ad, Fiyat, StoktaVarMi) VALUES (@Ad, @Fiyat, @Stok)", connection);
            cmd.Parameters.AddWithValue("@Ad", urunAdi);
            cmd.Parameters.AddWithValue("@Fiyat", urunFiyati);
            cmd.Parameters.AddWithValue("@Stok", urunStok);

            cmd.ExecuteNonQuery();

            connection.Close();
        }


        public static void DegerdenYuksekFiyatliUrunleriGetir()
        {
            using (var connection = CreateConnection())
            {

                Console.Write("Bir değer giriniz: ");
                var deger = Console.ReadLine();

                var command = new SqlCommand("SELECT * FROM Urunler WHERE fiyat > @deger", connection);
                command.Parameters.AddWithValue("@deger", double.Parse(deger));

                using (var result = command.ExecuteReader())
                {

                    while (result.Read())
                    {
                        Console.Write($"{result["ad"]}");
                        Console.Write($"{result["Fiyat"]}");
                        Console.WriteLine();
                    }

                }
            }

            Console.ReadLine();

        }

    }
}
