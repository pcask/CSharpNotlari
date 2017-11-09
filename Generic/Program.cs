using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generic
{
    class Program
    {
        static void Main(string[] args)
        {
            var genericDizi = new StackGeneric<int>();

            var kaynakDizi = new int[] { 1, 2, 5};

            foreach (var item in kaynakDizi)
            {
                genericDizi.Push(item);
            }

            var genericDizi2 = new StackGeneric<string>();

            var kaynakDizi2 = new string[] { "sdfsdf", "ssdfdf", "sdfsdf"};

            foreach (var item in kaynakDizi2)
            {
                genericDizi2.Push(item);
            }

            var genericDizi3 = new StackGeneric<bool>();

            var kaynakDizi3 = new bool[7];
            kaynakDizi3[0] = true;
            kaynakDizi3[1] = false;
            kaynakDizi3[2] = true;


            foreach (var item in kaynakDizi3)
            {
                genericDizi3.Push(item);
            }

            Console.WriteLine($"bool default: {default(bool)}");
            Console.WriteLine($"int default: {default(int)}");
            Console.WriteLine($"object default: {default(object)}");

            genericDizi3.Pop();

            var kvp = new KeyValueGeneric<int, List<string>>();

            kvp.Key =  10;
            kvp.Value = new List<string> { "sdfsdf", "sdfsdf", "mjhkhjk" };

            Console.WriteLine(kvp);

            var kvp2 = new KeyValueGeneric<bool,int>();

            kvp2.Key = true;
            kvp2.Value = 56486;

            Console.WriteLine(kvp2);
        }
    }
}
