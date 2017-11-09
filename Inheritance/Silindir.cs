using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance
{
    public class Silindir : Daire
    {
        public int Yukseklik { get; set; }

        public override double AlanHesapla()
        {
            return (2 * Math.PI * YariCap * Yukseklik) + 2 * base.AlanHesapla();
        }
    }
}
