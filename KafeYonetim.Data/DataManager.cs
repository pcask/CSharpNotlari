using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KafeYonetim.Lib;


namespace KafeYonetim.Data
{
    public class DataManager
    {

        //private static string connStr = "Data Source=DESKTOP-S3O5AOR;Initial Catalog=KafeYonetim;Integrated Security=True";

        private static string connStr = "Data Source=PCASK\\MSSQLSERVER2016D;Initial Catalog=KafeYonetim;Integrated Security=True";

        private static SqlConnection CreateConnection()
        {
            var connection = new SqlConnection(connStr);
            connection.Open();

            return connection;
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

        public static bool MasaEkle(int masaNo, int kafeID, string Durum)
        {
            using( var connection = CreateConnection())
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO Masalar (MasaNo, KafeID, Durum) VALUES (@masaNo, @kafeID, @durum)", connection);
                cmd.Parameters.AddWithValue("@masaNo", masaNo);
                cmd.Parameters.AddWithValue("@kafeID", kafeID);
                cmd.Parameters.AddWithValue("@durum", Durum);

                int result = cmd.ExecuteNonQuery();

                if (result > 0)
                    return true;

                return false;
            }
        }

        public static bool UrunGir(string ad, double fiyat, bool stoktaVarMi)
        {
            using (var connection = CreateConnection())
            {
                var command = new SqlCommand("INSERT INTO Urunler (ad, fiyat, stoktavarmi) VALUES (@ad, @fiyat, @stoktaVarMi)", connection);
                command.Parameters.AddWithValue("@ad", ad);
                command.Parameters.AddWithValue("@fiyat", fiyat);
                command.Parameters.AddWithValue("@stoktaVarMi", stoktaVarMi);

                var result = command.ExecuteNonQuery();

                if (result > 0)
                {
                    return true;
                }

                return false;
            }
        }

        public static List<Urun> UrunListesiniHazirla(SqlDataReader reader)
        {
            List<Urun> urunListesi = new List<Urun>();

            while (reader.Read())
            {
                Urun urun = new Urun((int)reader["ID"], reader["Ad"].ToString(), Convert.ToSingle(reader["Fiyat"]), (bool)reader["StoktaVarMi"]);

                urunListesi.Add(urun);
            }

            return urunListesi;
        }

        //public static List<Masa> MasalariGetir()
        //{
        //    using (var connection = CreateConnection())
        //    {
        //        SqlCommand cmd = new SqlCommand("SELECT * FROM Urunler", connection);

        //        SqlDataReader reader = cmd.ExecuteReader();

        //        List<Masa> masalar = new List<Masa>();

        //        while (reader.Read())
        //        {
        //            Kafe kafe = new Kafe()
        //            Masa masa = new Masa((int)reader["MasaNo"],)
        //        }
        //    }
        //}

        public static List<Urun> UrunleriGetir()
        {
            using (var connection = CreateConnection())
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM Urunler", connection);

                return UrunListesiniHazirla(cmd.ExecuteReader());
            }
        }

        public static List<Urun> StoktaOlmayanUrunleriGetir()
        {
            using (var connection = CreateConnection())
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM Urunler Where StoktaVarMi = 'false'", connection);

                return UrunListesiniHazirla(cmd.ExecuteReader());
            }
        }

        public static List<Urun> DegerdenYuksekFiyatliUrunleriGetir(double esikDeger)
        {
            using (var connection = CreateConnection())
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM Urunler WHERE fiyat > @deger", connection);
                cmd.Parameters.AddWithValue("@deger", esikDeger);

                return UrunListesiniHazirla(cmd.ExecuteReader());
            }
        }

        public static int SecilenUrunleriSil(string idList)
        {
            using (var connection = CreateConnection())
            {
                var command = new SqlCommand($"DELETE FROM Urunler WHERE ID IN ({idList}) ", connection);

               return command.ExecuteNonQuery();
            }
        }
    }
}
