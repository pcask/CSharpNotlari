using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance
{
    class Daire: Nokta
    {
        int _yariCap;

        public int YariCap
        {
            get { return _yariCap; }
            set { _yariCap = value; }
        }

        public virtual double AlanHesapla()
        {
            return Math.PI * YariCap * YariCap;
        }
    }
}
