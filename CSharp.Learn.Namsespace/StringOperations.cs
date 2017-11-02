using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp.Learn.Namsespace
{
    public class StringOperations
    {
        #region Örnekler
        public void StringOp()
        {
            string a = "merhaba";
            string b = "dünya!";

            //Burada a değişkenine atama yapılırken a'nın var olduğu yere yeni değer yazılmaz. Yeni bir alan oluşturulup yeni değer buraya yazılır.
            a = a + " " + b;

            var sb = new StringBuilder("Merhaba");
            sb.Append(" ");
            sb.AppendLine(b);

            sb.Append("Nasılsın?");

            Console.WriteLine(sb.ToString());

            Console.ReadKey();
        }

        public string StringToplamaYontemiIleOlusturma(string isim, string soyisim, int yas)
        {
            string mesaj = "Merhaba " + isim + " " + soyisim + "\n" + yas + ". Yaşın kutlu olsun";

            return mesaj;
        }

        public string StringBuilderYontemiIleOlusturma(string isim, string soyisim, int yas)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Merhaba ");//Append eklenen stringleri yan yana birleştirir;
            sb.Append(isim);
            sb.Append(" ");
            sb.AppendLine(soyisim);//AppendLine kendisinden sonra eklenecek stringerin alt satırdan itibaren eklenmesini sağlar

            sb.Append(yas);
            sb.Append(" . yaşın kutlu olsun.");

            return sb.ToString();
        }

        public string StringFormatYontemiIleOlusturma(string isim, string soyisim, int yas)
        {
            //string.Format metodu en az iki parametre alır.
            //Birinci parametre değişkenlerin ekeneceği stringdir.
            //Bundan sonra istenilen sayıda parametre girilebilir. 
            //Girilen her parametre, tanımlandığı sıra numarası ile {} arasında çağrılır. Örneğin isim değişkeni stringden sonra gelen ilk değişken olduğu içinj {0} ile çağırılır.
            string mesaj = string.Format("Merhaba {0} {1} \n {2}. Yaşın kutlu olsun", isim, soyisim, yas);

            //Tanımlanan parametrelerin hepsi çağırılmak zorunda değildir.
            string mesaj2 = string.Format("\n Sevgili {0} , \n {2}. yaşına ulaşabildiğin çok şanslısın.", isim, soyisim, yas);

            //Tanımlana parametreler sırayla çağırılmak zorunda değildir
            string mesaj3 = string.Format("\n Sevgili {1} {0} , \n {2}. yaşına ulaşabildiğin çok şanslısın.", isim, soyisim, yas);

            //Tanımlanan parametreler birden fazla defa ve değişik sıralarla çağrılabilir
            string mesaj4 = string.Format("\n Sevgili {0} , \n {2}. yaşına ulaşabildiğin çok şanslısın. Bak {0} kardeş gerç.ekten çok şanslsın. {0} ciğim hayatının kıymetini bil", isim, soyisim, yas);

            return mesaj;
        }

        public string StringInterpolationYontemiIleOlusturma(string isim, string soyisim, int yas)
        {
            string mesaj = $"Merhaba {isim} {soyisim} \n {yas}. Yaşın kutlu olsun. {isim} kelimesinin ne anlama geldiğini biliyor musun?";

            return mesaj;
        }

        public string StringlerVeEscapeKarakteriKullanımı()
        {
            // Oluşturulmak istenen metnin içerisinde " işareti \ işareti, ya da yeni satır , tab gibi karakterleri kullanmak için escape karakterleri kullanılır
            string mesaj = "Bu gün \"neden gelmedin\" diye sordu.\nSonra da koşarak gitti";

            return mesaj;
        }

        public void StringMetodlari()
        {
            string metin = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nam nisl odio, imperdiet nec accumsan at, vulputate vitae mauris. Morbi sagittis lorem urna, at dictum massa blandit eu. Integer nulla lectus, rhoncus in gravida ac, hendrerit a est. Cras egestas hendrerit libero, quis viverra diam faucibus non. Proin tincidunt mauris sit amet dolor finibus mattis id sed massa. Sed quis nibh ullamcorper, tempor erat at, vehicula sem. Phasellus sed dui augue i";

            int ilkVirgulunIndexNumarasi = metin.IndexOf(",");
            int ilkAtKelimesininBaslangicIndisi = metin.IndexOf("at");
            int birdenFazlaAramadanEslesenIlkOgeninIndisi = metin.IndexOfAny(new[] { ',', '.', ' ' });//İlk olarak boşluk " " karakterini bulacak ve onun indis numarasını dönecek
            bool merhabaKelimesiMetindeVarmi = metin.Contains("merhaba");//merhaba kelimesi olmadığı için false döner;
            bool urnaKelimesiMetindeVarmi = metin.Contains("urna");//urna kelimesi olduğu için true döner;

            string tamamiKucukHarfEng = metin.ToLower();
            string tamamiBuyukHarfEng = metin.ToUpper();
            string tamamiBuyukHarfTr = metin.ToUpper(CultureInfo.GetCultureInfo("en-us"));
            string[] kelimeListesi = metin.Split(' ');
            string[] kelimeListesi2 = metin.Split(new[] { ' ', '.', ',', ';' });
            string[] kelimeListesi3 = metin.Split(new[] { ' ', '.', ',', ';' }, StringSplitOptions.RemoveEmptyEntries);

            string metinleriAyracIleBirlestir = string.Join("---", kelimeListesi);

            string subString90DansonrasininTamami = metin.Substring(90);
            string substring90ve97Arasi = metin.Substring(90, 7);
            bool lHarfiIleMiBasliyor = metin.StartsWith("l");//false CaseSensetive olduğu için L ve l farklı harfler olarak değerlendirilir
            bool LHarfiIleMiBasliyor = metin.StartsWith("L");//true
            bool lHarfiIleMiBasliyorCaseInsensetive = metin.StartsWith("l", StringComparison.OrdinalIgnoreCase);//true StringComparison.OrdinalIgnoreCase parametresi büyük-küçük harf farkını gözardı eder.
            bool bHarfiIleMiBitiyor = metin.EndsWith("b");//false
            bool bosMu = string.IsNullOrEmpty("");//True
            bool bosMu2 = string.IsNullOrEmpty(" ");//False
            bool bosMu3 = string.IsNullOrEmpty(" a");//False
            bool bosMu4 = string.IsNullOrEmpty(" a    ");//False
            bool boslukMu = string.IsNullOrWhiteSpace("");//true
            bool boslukMu2 = string.IsNullOrWhiteSpace("\n\t");//true
            bool boslukMu3 = string.IsNullOrWhiteSpace("  ");//true
            bool boslukMu3_1 = string.IsNullOrWhiteSpace(",");//false
            bool boslukMu4 = string.IsNullOrWhiteSpace("a12");//false
            bool boslukMu5 = string.IsNullOrWhiteSpace("   a    ");//false

            string yeniDeger = metin.Replace("at", "ot");
            string yeniDeger2 = metin.Replace("at", "");
            string metin2 = "kabahat";
            string yeniDeger3 = metin2.Replace("at", "otcul").Replace("ot", "at");
                                //"kabahotcul".Replace("ot", "at") 
                                //"kabahatcul"
            string trimlenmisDeger = "   sdfdsf   ".Trim();//"sdfdsf"
            string trimlenmisDeger2 = "  sdf     dsf   ".Trim();//"sdf     dsf"
            string solTrimDeger = "   sdfdsf   ".TrimStart();//"sdfdsf   "
            string sagTrimDeger = "   sdfdsf   ".TrimEnd();//"   sdfdsf"

        }
        #endregion


        #region Uygulamalar
        public void KelimeSayilariniBul(string metin)
        {
            var kelimeler = metin.Split(' ');
            var sayilar = new int[kelimeler.Length];
            //lorem lorem, lorem;
            for (int i = 0; i < kelimeler.Length; i++)
            {
                if (string.IsNullOrWhiteSpace(kelimeler[i]))
                {
                    continue;
                }

                string aranan = kelimeler[i];
                for (int j = 0; j < kelimeler.Length; j++)
                {
                    if (kelimeler[j] == aranan)
                    {
                        sayilar[i]++;
                        kelimeler[j] = "";
                    }
                }

                kelimeler[i] = aranan;
            }

            for (int i = 0; i < kelimeler.Length; i++)
            {
                if (kelimeler[i] != "")
                {
                    Console.WriteLine($"{kelimeler[i]} -> {sayilar[i]}");
                }
            }

            Console.ReadKey();
        }

        public void GirilenMetinBosMuKontroluYap()
        {
            string girdi;
            //do
            //{
            //    girdi = Console.ReadLine();

            //    if (string.IsNullOrWhiteSpace(girdi))
            //    {
            //        Console.WriteLine("Lütfen geçerli bir metin giriniz.");
            //    }
            //} while (string.IsNullOrWhiteSpace(girdi));


            do
            {
                girdi = Console.ReadLine();

                if (!string.IsNullOrWhiteSpace(girdi))
                {
                    break;
                }

                Console.WriteLine("Lütfen geçerli bir metin giriniz.");
            } while (true);
            Console.ReadKey();
        }

        public void EnUzunKelimeyiBul()
        {
            //. , ; ' " - ? :
            string metin = Console.ReadLine();
            //metin = metin.Replace(".", "").Replace(",", "").Replace(";", "").Replace("'", "").Replace("\"", "").Replace("-", "").Replace("?", "").Replace(":", "");

            //var kelimeler = metin.Split(' ');

            //string metin = Console.ReadLine().Replace(".", "").Replace(",", "").Replace(";", "").Replace("'", "").Replace("\"", "").Replace("-", "").Replace("?", "").Replace(":", "");


            var kelimeler = metin.Split(new[] { ' ', '.', ',', ';' }, StringSplitOptions.RemoveEmptyEntries);
            string enUzunKelime = "";

            foreach (var kelime in kelimeler)
            {
                if(kelime.Length > enUzunKelime.Length)
                {
                    enUzunKelime = kelime;
                }
            }

            Console.WriteLine($"En uzun kelime: {enUzunKelime}, Harf sayısı: {enUzunKelime.Length}");
        }
        #endregion
        
    }
}
