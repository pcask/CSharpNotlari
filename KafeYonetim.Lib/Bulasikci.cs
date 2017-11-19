using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KafeYonetim.Lib
{
    public class Bulasikci : Calisan
    {
        public Bulasikci(string ad, DateTime iseGirisTarihi, Kafe kafe) : base(ad, iseGirisTarihi, kafe)
        {

        }

        public byte TemizlikPuani { get; set; }

        public void BulasiklariYika()
        {
            Console.WriteLine("Bulaşıklar Yıkandı..");
        }
    }
}
