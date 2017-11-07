using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bina;

namespace BinaYonetim
{
    class Program
    {
        static void Main(string[] args)
        {
            BinaModel model = new BinaModel();

            model.Ad = "BEM Kurs Binası";
            model.Renk = "Yeşil";

            var kapi = new Kapi();
            var kapi2 = new Kapi();

            var binaKapisi = new BinaKapisi();

            var daireKapisi = new DaireKapisi();

            var gelismisDaireKapisi = new GelismisDaireKapisi();

            Console.ReadKey();
        }
    }
}
