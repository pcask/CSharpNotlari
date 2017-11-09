using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bina.Kapi
{
    public class Kilit
    {
        private string KilitSifre;
        internal string Materyal;

        public bool KilitiAcmayiDene(string anahtar)
        {
            if(KilitSifre == anahtar)
            {
                Console.WriteLine("Anahtar uydu. Giriş başarılı.");
                return true;
            } else {
                Console.WriteLine("Anahtar uymadı. Giriş BAŞARISIZ.");
                return false;
            }
        }
    }
}
