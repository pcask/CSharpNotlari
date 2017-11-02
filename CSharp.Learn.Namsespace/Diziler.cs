using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CSharp.Learn.Namsespace
{
    public class Diziler
    {

        public void Dizi()
        {
            //Dizi tanımlanırken tip belirtilmesi zorunluıdur
            //Tip belirlendikten sonra diziye sadece o tipte elemanlar atanabilir
            //Dizi oluşturulurken kaç eleman alacağı belirtilmek zorundadır
            //Dizinin eleman sayısı belirlendikten sonra değiştirilemez
            int[] dizi = new int[5];

            var dizi2 = new bool[10];

            var dizi3 = new bool[] { true, true, false };

            var dizi4 = dizi3;

            Console.WriteLine(dizi4[0]);

            dizi4[1] = false;
            Console.WriteLine(dizi3[1]);

            dizi[0] = 0;
            dizi[1] = 4;
            dizi[2] = 1;
            dizi[3] = 16;
            dizi[4] = 9;


            Console.WriteLine("Tek Boyutlu dizi");
            Console.WriteLine($"Length: {dizi.Length}");
            Console.WriteLine($"LongLength: {dizi.LongLength}");
            Console.WriteLine($"Rank: {dizi.Rank}");
            Console.WriteLine();
            int a = dizi[0];
            
            int[,] cokBoyutluDizi = new int[10,3];
            Console.WriteLine("Çok Boyutlu dizi");
            Console.WriteLine($"Length: {cokBoyutluDizi.Length}");
            Console.WriteLine($"LongLength: {cokBoyutluDizi.LongLength}");
            Console.WriteLine($"Rank: {cokBoyutluDizi.Rank}");
            Console.WriteLine();

            Console.WriteLine($"dizi içerisinde 4'ün indexi: {Array.IndexOf(dizi, 4)}");
            Console.WriteLine();

            Array.Sort(dizi);
            Console.WriteLine("Sıralanmış dizi:");
            DiziYazdir(dizi);
            Console.WriteLine();

            Array.Reverse(dizi);
            Console.WriteLine("Ters çevirlmiş dizi:");
            DiziYazdir(dizi);

        }

        void DiziYazdir(int[] dizi)
        {
            for (int d = 0; d < dizi.Length; d++)
            {
                Console.WriteLine(dizi[d]);
            }
        }
    }
}
