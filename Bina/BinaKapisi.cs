using System;

namespace Bina
{
    //Derived Class
    //Sub Class
    // BinaKapisi class'i yazılırken Kapi class'ından inherit edildiği için BinaKapisi Kapi class'ının Derived/Sub Class'ıdır.
    public class BinaKapisi : Kapi
    {
        public string Otomatik;

        /* Kapi class'ının inheritance edilmesi sonucu BinaKapisi class'ına kazandırılan öğeler
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
        
        
        */
    }
}