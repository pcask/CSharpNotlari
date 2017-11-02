using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp.Learn.Namsespace
{
    class Operators
    {
        public void OperatorsMethod()
        {
            int a = 5;
            int b = 2;

            float x = 2.5f;

            int y = a / b;
            float z = a / b;

            //int e = a / x;//HATA: int/float işlemi float sonuç döndürür. Float değer int değere atanamayacağı için hata alınır. 

            float f = a / x;
        }
    }
}
