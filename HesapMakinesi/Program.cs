using System;
using System.Collections.Generic;
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
                Console.Write("İşlemi giriniz: ");
                var islem = Console.ReadLine();

                var islemSayi = islem.Split(new[] { '+', '-', '*', '/' });

                var sayi1 = int.Parse(islemSayi[0]);
                var sayi2 = int.Parse(islemSayi[1]);

                if (islem.IndexOf('+') > -1)
                {
                    Console.WriteLine(sayi1 + sayi2);
                }
                else if (islem.IndexOf('-') > -1)
                {
                    Console.WriteLine(sayi1 - sayi2);
                }
                else if (islem.IndexOf('*') > -1)
                {
                    Console.WriteLine(sayi1 * sayi2);
                }
                else if (islem.IndexOf('/') > -1)
                {
                    Console.WriteLine(sayi1 / sayi2);
                }

                Console.Write("devam etmek istiyor musunuz? ");

            } while (Console.ReadLine() == "e");
        }
    }
}
