using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KafeYonetim.Lib;
using System.Data;

namespace KafeYonetim.Data
{
    public class DataManager
    {

        private static string connStr = "Data Source=DESKTOP-S3O5AOR;Initial Catalog=KafeYonetim;Integrated Security=True";

        // private static string connStr = "Data Source=PCASK\\MSSQLSERVER2016D;Initial Catalog=KafeYonetim;Integrated Security=True";

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

        public static Kafe KafeGetir(string kafeID)
        {
            using (var connection = CreateConnection())
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM Kafeler WHERE ID = @kafeID", connection);

                cmd.Parameters.AddWithValue("@kafeID", kafeID);

                SqlDataReader reader = cmd.ExecuteReader();

                reader.Read();

                Kafe kafe = new Kafe((int)reader["ID"], reader["Ad"].ToString(), reader["AcilisSaati"].ToString(), reader["KapanisSaati"].ToString());

                return kafe;
            }
        }

        public static Kafe AktifKafeyiGetir()
        {
            using (var connection = CreateConnection())
            {
                SqlCommand cmd = new SqlCommand("SELECT TOP 1 * FROM Kafeler", connection);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    reader.Read();

                    Kafe kafe = new Kafe((int)reader["ID"], reader["Ad"].ToString(), reader["AcilisSaati"].ToString(), reader["KapanisSaati"].ToString());

                    return kafe;
                }
            }
        }


        public static List<Kafe> KafeleriGetir()
        {
            using (var connection = CreateConnection())
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM Kafeler", connection);

                SqlDataReader reader = cmd.ExecuteReader();

                List<Kafe> kafeler = new List<Kafe>();

                while (reader.Read())
                {
                    Kafe kafe = new Kafe((int)reader["ID"], reader["Ad"].ToString(), reader["AcilisSaati"].ToString(), reader["KapanisSaati"].ToString());

                    kafeler.Add(kafe);
                }

                return kafeler;
            }
        }

        //public static bool MasaEkle(int masaNo, int kafeID, string Durum)
        //{
        //    using( var connection = CreateConnection())
        //    {
        //        SqlCommand cmd = new SqlCommand("INSERT INTO Masalar (MasaNo, KafeID, Durum) VALUES (@masaNo, @kafeID, @durum)", connection);
        //        cmd.Parameters.AddWithValue("@masaNo", masaNo);
        //        cmd.Parameters.AddWithValue("@kafeID", kafeID);
        //        cmd.Parameters.AddWithValue("@durum", Durum);

        //        int result = cmd.ExecuteNonQuery();

        //        if (result > 0)
        //            return true;

        //        return false;
        //    }
        //}

        public static int MasaEkle(Masa masa)
        {
            using (var connection = CreateConnection())
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO Masalar (MasaNo, KafeID, Durum, KisiSayisi) VALUES (@masaNo, @kafeID, @durum, @kisiSayisi); SELECT scope_identity()", connection);

                cmd.Parameters.AddWithValue("@masaNo", masa.MasaNo);
                cmd.Parameters.AddWithValue("@kafeID", masa.Kafe.ID);
                cmd.Parameters.AddWithValue("@durum", masa.Durum.ToString());
                cmd.Parameters.AddWithValue("@kisiSayisi", masa.KisiSayisi);

                int masaID = Convert.ToInt32(cmd.ExecuteScalar());
                return masaID;
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

        public static List<Masa> MasalariGetir()
        {
            using (var connection = CreateConnection())
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM Masalar", connection);

                SqlDataReader reader = cmd.ExecuteReader();

                List<Masa> masalar = new List<Masa>();

                while (reader.Read())
                {
                    Masa masa = new Masa(reader["MasaNo"].ToString(), KafeGetir(reader["KafeID"].ToString()));

                    masa.Durum = reader["Durum"].ToString() == "Dolu" ? MasaDurum.Dolu : MasaDurum.Bos;
                    masa.KisiSayisi = Convert.ToByte(reader["KisiSayisi"]);

                    masalar.Add(masa);
                }

                return masalar;
            }
        }

        public static Tuple<int, int> MasaSayisiVeToplamKapasiteGetir()
        {
            using (var connection = CreateConnection())
            {
                SqlCommand cmd = new SqlCommand("SELECT COUNT(*) AS MasaSayisi, SUM(KisiSayisi) AS KisiSayisi FROM Masalar", connection);

                SqlDataReader reader = cmd.ExecuteReader();

                reader.Read();

                return new Tuple<int, int>((int)reader["MasaSayisi"], (int)reader["KisiSayisi"]);
            }
        }

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

        public static int GarsonEkle(Garson garson)
        {
            using (var connection = CreateConnection())
            {
                SqlCommand cmd = new SqlCommand(@"
                            INSERT INTO Garsonlar (Bahsis) VALUES(@bahsis);
                            DECLARE @eklenenGarsonID int;
                            SET @eklenenGarsonID = scope_identity();
                            INSERT INTO Calisanlar (Ad, IseGirisTarihi, MesaideMi, KafeID, Durum, GorevID, GorevTabloID) VALUES (@Ad, @IseGirisTarihi, @MesaideMi, @KafeId, @Durum, @GorevId, @eklenenGarsonID); SELECT scope_identity()", connection);

                cmd.Parameters.AddWithValue("@bahsis", garson.Bahsis);
                cmd.Parameters.AddWithValue("@Ad", garson.Ad);
                cmd.Parameters.AddWithValue("@IseGirisTarihi", garson.IseGirisTarihi);
                cmd.Parameters.AddWithValue("@MesaideMi", garson.MesaideMi);
                cmd.Parameters.AddWithValue("@KafeId", garson.Kafe.ID);
                cmd.Parameters.AddWithValue("@Durum", garson.Durum);
                cmd.Parameters.AddWithValue("@GorevId", 2);

                var result = Convert.ToInt32(cmd.ExecuteScalar());

                return result;
            }
        }

        //public static int AsciEkle(Asci asci)
        //{
        //    using (var connection = CreateConnection())
        //    {
        //        SqlCommand cmd = new SqlCommand(@"
        //                    INSERT INTO Ascilar (Puan) VALUES(@puan);
        //                    DECLARE @eklenenAsciID int;
        //                    SET @eklenenGarsonID = scope_identity();
        //                    INSERT INTO Calisanlar (Ad, IseGirisTarihi, MesaideMi, KafeID, Durum, GorevID, GorevTabloID) VALUES (@Ad, @IseGirisTarihi, @MesaideMi, @KafeId, @Durum, @GorevId, @eklenenAsciID); SELECT scope_identity()", connection);

        //        cmd.Parameters.AddWithValue("@puan", asci.Puan);
        //        cmd.Parameters.AddWithValue("@Ad", asci.Ad);
        //        cmd.Parameters.AddWithValue("@IseGirisTarihi", asci.IseGirisTarihi);
        //        cmd.Parameters.AddWithValue("@MesaideMi", asci.MesaideMi);
        //        cmd.Parameters.AddWithValue("@KafeId", asci.Kafe.ID);
        //        cmd.Parameters.AddWithValue("@Durum", asci.Durum);
        //        cmd.Parameters.AddWithValue("@GorevId", 1);

        //        var result = Convert.ToInt32(cmd.ExecuteScalar());

        //        return result;
        //    }
        //}

        // Stored Procedure Çağrısı ile Aşçı Ekleme
        public static int AsciEkle(Asci asci)
        {
            using (var connection = CreateConnection())
            {
                SqlCommand cmd = new SqlCommand("AsciEkle", connection);

                // Stored Procedure den return edilecek değeri yakalamak için;
                SqlParameter returnValue = new SqlParameter();
                returnValue.Direction = ParameterDirection.ReturnValue;
                cmd.Parameters.Add(returnValue);

                cmd.Parameters.AddWithValue("@puan", asci.Puan);
                cmd.Parameters.AddWithValue("@kafeID", asci.Kafe.ID);
                cmd.Parameters.AddWithValue("@Ad", asci.Ad);

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.ExecuteScalar();

                return (int)returnValue.Value;
            }
        }

        public static List<Calisan> CalisanlariGetir()
        {
            using (var connection = CreateConnection())
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM Calisanlar CLS INNER JOIN CalisanGorevler CLSG ON CLS.GorevID = CLSG.ID", connection);

                SqlDataReader reader = cmd.ExecuteReader();

                List<Calisan> calisanlar = new List<Calisan>();

                while (reader.Read())
                {
                    Calisan calisan = new Calisan(reader["Ad"].ToString(), (DateTime)reader["IseGirisTarihi"], KafeGetir(reader["KafeID"].ToString()),reader["GorevAdi"].ToString());

                    calisan.ID = (int)reader["ID"];

                    calisanlar.Add(calisan);
                }

                return calisanlar;
            }
        }
    }
}
