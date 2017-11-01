using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HesapMakinesi
{
    class Program
    {
        static void Main(string[] args)
        {
            do
            {
                Console.Write("Yapmak İstediğiniz İşlemi Yazınız : ");

                string yapilacakIslem = Console.ReadLine();

                string[] ifadeElemanlari = yapilacakIslem.Split(new char[] { '+', '-', '*', '/' });

                //1. Yol) İşlemi Alma
                string islem = yapilacakIslem.Substring(ifadeElemanlari[0].Length, 1);

                //2. Yol) İşlemi Alma
                //string islem2 = yapilacakIslem.Replace(ifadeElemanlari[0], "").Replace(ifadeElemanlari[1], "");

                int birinciEleman = int.Parse(ifadeElemanlari[0]);
                int ikinciEleman = int.Parse(ifadeElemanlari[1]);

                double sonuc = 0;

                switch (islem)
                {
                    case "+":
                        sonuc = birinciEleman + ikinciEleman;
                        break;
                    case "-":
                        sonuc = birinciEleman - ikinciEleman;
                        break;
                    case "*":
                        sonuc = birinciEleman * ikinciEleman;
                        break;
                    case "/":
                        sonuc = birinciEleman / ikinciEleman;
                        break;
                    default:
                        Console.WriteLine("Lütfen Doğru Bir İşlem Giriniz");
                        break;
                }

                Console.WriteLine("İşleminizin Sonucu = " + sonuc);

                Console.WriteLine("Devam Etmek İstiyor Musunuz? Evet(E), Hayır(H)");

            } while (Console.ReadLine().ToUpper() == "E");
        }
    }
}
