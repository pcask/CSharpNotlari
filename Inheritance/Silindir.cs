using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance
{
    class Silindir : Daire
    {
        int _yukseklik;

        public int Yukseklik
        {
            get { return _yukseklik; }
            set { _yukseklik = value; }
        }

        public override double AlanHesapla()
        {
            return (2 * Math.PI * YariCap * Yukseklik) + 2 * base.AlanHesapla();
        }
    }
}
