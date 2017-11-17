using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KafeYonetim.Lib
{
    class Gorev
    {
        public Gorev(string gorev)
        {
            GorevAdi = gorev;
        }

        public string GorevAdi { get; private set; }
        public int ID { get; set; }
    }
}
