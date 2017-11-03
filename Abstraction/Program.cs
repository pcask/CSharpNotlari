using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstraction
{
    class Program
    {
        static void Main(string[] args)
        {
            Televizyon tv = new Televizyon();

            tv.Tip = "LED";
            tv.Marka = "LG";
            tv.Model = "LG015A7";
            tv.Renk = "Siyah";
            tv.AgirlikKg = 155;
            tv.EkranBoyutuInch = 105;
            tv.EkranBoyutuCm = 267;
            tv.CozunurlukYatay = 5120;
            tv.CozunurlukYatay = 2160;
            tv.Mensei = "Güney Kore";
            tv.GarantiSuresiAy = 24;

            tv.Wifi = true;
            tv.HDMI = true;
            tv.USB = true;

            Power powerDugmesi = new Power();
            powerDugmesi.Ad = "POWER";

            tv.Dugmeler = new Dugme[] { powerDugmesi };

            tv.Dugmeler[0].Bas();

            Console.ReadLine();

        }
    }
}
