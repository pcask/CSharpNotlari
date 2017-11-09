using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bina;
using Bina.Kapi;

namespace BinaYonetim
{
    class Program
    {
        static void Main(string[] args)
        {
            BinaModel model = new BinaModel("BEM Kurs Binası");

            model.Renk = "Yeşil";

            model.Ad = "123456789123456700000";

            Console.WriteLine(model.Ad);

            var kapi = new Kapi();
            var kapi2 = new Kapi();

            var binaKapisi = new BinaKapisi();

            var daireKapisi = new DaireKapisi();

            var gelismisDaireKapisi = new GelismisDaireKapisi();

            Console.WriteLine("Kapı");
            kapi.KapiyiAc();

            Console.WriteLine("Bina");
            binaKapisi.KapiyiAc();
            binaKapisi.KapidanGir("Ben");
            binaKapisi.KapiyiKapat();

            Console.WriteLine("\nDaire");
            daireKapisi.KapiyiAc();
            daireKapisi.KapidanGir("Ben");
            daireKapisi.KapiyiKapat();

            Console.WriteLine("\nGelişmiş Daire");
            gelismisDaireKapisi.KapiyiAc();
            gelismisDaireKapisi.KapidanGir("Ben");
            gelismisDaireKapisi.KapiyiKapat();

            var oturmaOdasi = new GenelAmacliOda();

            Console.ReadKey();
        }
    }
}
