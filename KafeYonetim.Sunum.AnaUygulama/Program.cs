using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KafeYonetim.Data;

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
    }
}
