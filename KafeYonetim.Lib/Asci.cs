using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KafeYonetim.Lib
{
    public class Asci : Calisan
    {
        public Asci(string isim, DateTime girisTarihi): base(isim, girisTarihi)
        {

        }

        public void SiparisiHazirla()
        {
            Console.WriteLine("Siparis hazırlandı");
        }
    }
}
