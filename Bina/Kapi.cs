using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bina
{
    //Base Class
    //Super Class
    //DaireKapisi ve BinaKapisi class'ları yazılırken bu class'tan türetildikleri için Kapi class'i DaireKapisi ve BinaKapisi İçin Base/Super class'tır.
    public class Kapi
    {
        public string Govde;
        public string Kulp;
        public string Kilit;

        public void KapiyiAc()
        {
            Console.WriteLine("Kapı açıldı.");
        }

        public void KapiyiKapat()
        {
            Console.WriteLine("Kapı kapandı.");
        }
    }
}
