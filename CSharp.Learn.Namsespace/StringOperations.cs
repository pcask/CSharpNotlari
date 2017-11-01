using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp.Learn.Namsespace
{
    class StringOperations
    {

        public void StringOp()
        {

            Console.WriteLine("Lütfen Paragraf Giriniz");

            string paragraf = Console.ReadLine();

            string[] kelimeler = paragraf.Split(' ');

            string[,] kelimeVeSayisi = new string[kelimeler.Length, 2];

            bool dahaOnceEklenmisMi = false;

            for (int i = 0; i < kelimeler.Length; i++)
            {
                int sayac = 1;

                for (int k = i + 1; k < kelimeler.Length; k++)
                {

                    if (kelimeler[i] == kelimeler[k])
                    {
                        for (int j = 0; j < kelimeVeSayisi.GetLength(0); j++)
                        {
                            if (kelimeVeSayisi[j, 0] == kelimeler[i])
                                dahaOnceEklenmisMi = true;
                        }

                        if (!dahaOnceEklenmisMi)
                        {
                            sayac++;

                            dahaOnceEklenmisMi = false;
                        }
                    }
                }

                kelimeVeSayisi[i, 0] = kelimeler[i];
                kelimeVeSayisi[i, 1] = sayac.ToString();
            }

            Console.WriteLine("deneme");
        }
    }
}

