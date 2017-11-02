using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp.Learn.Namsespace
{
    class Program
    {
        static void Main(string[] args)
        {
            byte a = 10;
            //a = 256;
            //a = "a";

            int x = a;

            //a = x;

            float y = 5.2f;
            //x =y;
            y = x;

            string s = "abscd";
            //char[] cs = new[] { 'a', 'b', 's', 'c', 'd' };

            char c = 'c';

            c = s[0];

            var di = new Diziler();
            di.Dizi();

            var so = new StringOperations();
            //so.StringMetodlari();
            //so.GirilenMetinBosMuKontroluYap();
            //so.EnUzunKelimeyiBul();
        }
    }
}
