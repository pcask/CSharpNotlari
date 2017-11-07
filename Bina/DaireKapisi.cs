using System;

namespace Bina
{
    //Derived Class
    //Sub Class
    // DaireKapisi class'i yazılırken Kapi class'ından inherit edildiği için DaireKapisi Kapi class'ının Derived/Sub Class'ıdır.
    public class DaireKapisi : Kapi
    {
        public string Durbun;
        public string SurmeKilit;

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