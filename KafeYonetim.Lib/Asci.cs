using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KafeYonetim.Lib
{
    public class Asci : Calisan
    {
        public Asci(string isim, DateTime girisTarihi, Kafe kafe): base(isim, girisTarihi, kafe)
        {

        }

        public byte Puan { get; set; }


        public void SiparisiHazirla()
        {
            Console.WriteLine("Siparis hazırlandı");
        }
    }
}
