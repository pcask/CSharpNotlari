using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bina.Kapi
{
    public class GelismisDaireKapisi: DaireKapisi
    {
        public string Kamera;

        public void BeniTanirsanKapiyiAc(string kim)
        {
            if(kim == "ben")
            {
                Console.WriteLine("Tanıdım.");
                base.KapiyiAc();
            }
            else
            {
                Console.WriteLine("TANIMADIM.");
            }
        }

        public override void KapiyiAc()
        {
            Console.WriteLine("Kapı dönerek açıldı.");
            base.KapiyiAc();
        }
    }
}
