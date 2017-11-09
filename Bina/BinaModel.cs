using Bina.Kapi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bina
{
    //BEST PRACTICE
    public class BinaModel
    {
        public BinaModel()
        {

        }

        public BinaModel(string ad)
        {
            Ad = ad;
        }

        public int MyProperty { get; set; }

        private string _ad;

        public string Ad     { get; }


        //private string _renk;


        //public string Renk
        //{
        //    get
        //    {
        //        return _renk;
        //    }
        //    set
        //    {
        //        _renk = value;
        //    }
        //}

        public string Renk { get; set; }

        public BinaKapisi[] BinaKapsi;
        public Pencere[] Pencereler;
        private Daire[] Daireler;

        public string AdSoyle()
        {
            return Ad;
        }

    }
}
