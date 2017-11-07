using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance
{
    class Program
    {
        static void Main(string[] args)
        {
            Daire d = new Daire();
            d.YariCap = 5;
            Console.WriteLine(d.AlanHesapla());

            Silindir s = new Silindir();
            s.YariCap = 5;
            s.Yukseklik = 20;
            Console.WriteLine(s.AlanHesapla());


            // Burada "Silindir has a Daire" ilişkisi var. Aşağıdaki atama işleminden sonra d işaretçisinden nokta ile AlanHesapla metodu çağrıldığında Silindir sınıfındaki override edilmiş metod çalışacaktır.
            d = s;
            Console.WriteLine(d.AlanHesapla());

            Console.ReadLine();
        }
    }
}
