using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance
{
    public class Daire : Nokta
    {
        public int YariCap { get; set; }

        public virtual double AlanHesapla()
        {
            return Math.PI * YariCap * YariCap;
        }
    }
}
