using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ornekler
{
    class Program
    {
        static void Main(string[] args)
        {
            #region SayiCozumleme

            string gelenDeger = "";

            do
            {
                Console.Write("\nLütfen bir sayı giriniz: ");
                try
                {
                    gelenDeger = Console.ReadLine();
                    int sayi = int.Parse(gelenDeger);
                    Console.WriteLine("***********************");

                    int basamak = 1;
                    while (sayi > 0)
                    {
                        Console.WriteLine(sayi % 10 + " x " + basamak + " = " + (sayi % 10) * basamak);

                        basamak *= 10;
                        sayi /= 10;
                    }
                }
                catch (Exception)
                {
                    if (gelenDeger != "exit")
                    {
                        Console.WriteLine("Doğru formatta bir sayı girmediniz!");
                        Console.Write("***********************\n");
                    }
                }

            } while (gelenDeger != "exit");

            #endregion


        }
    }
}
