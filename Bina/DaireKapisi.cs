using System;

namespace Bina.Kapi
{
    //Derived Class
    //Sub Class
    // DaireKapisi class'i yazılırken Kapi class'ından inherit edildiği için DaireKapisi Kapi class'ının Derived/Sub Class'ıdır.
    public class DaireKapisi : Kapi
    {
        public string Durbun;
        public string SurmeKilit;

        public override void KapiyiAc()
        {
            Console.WriteLine("Kapı içeri doğru hareket ettir.");
            base.KapiyiAc();
        }

        public void KapiyiKapat()
        {
            Console.WriteLine("Daire kapısı kapandı.");
            base.KapiyiKapat();
        }

        public override void KapidanGir(string kim)
        {
            Console.WriteLine($"{kim} daire kapısından girdi.");
        }

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