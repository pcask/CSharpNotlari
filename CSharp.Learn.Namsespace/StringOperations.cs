using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp.Learn.Namsespace
{
    class StringOperations
    {

        public void KelimeSayisiBul()
        {
            Console.WriteLine("Lütfen Paragraf Giriniz");

            string paragraf = Console.ReadLine();

            string[] kelimeler = paragraf.Split(' ');

            string[,] kelimeVeSayisi = new string[kelimeler.Length, 2];

            bool dahaOnceEklenmisMi = false;
            byte adim = 0;
            for (int i = 0; i < kelimeler.Length; i++)
            {
                int sayac = 1;
                dahaOnceEklenmisMi = false;

                for (int j = 0; j < kelimeler.Length; j++)
                {
                    if (kelimeVeSayisi[j, 0] == kelimeler[i])
                    {
                        dahaOnceEklenmisMi = true;
                        break;
                    }
                }

                if (dahaOnceEklenmisMi)
                    continue;

                for (int k = i + 1; k < kelimeler.Length; k++)
                {
                    if (kelimeler[i] == kelimeler[k])
                        sayac++;
                }

                kelimeVeSayisi[adim, 0] = kelimeler[i];
                kelimeVeSayisi[adim, 1] = sayac.ToString();

                adim++;
            }

            for (int i = 0; i < kelimeVeSayisi.GetLength(0); i++)
            {
                for (int k = 0; k < kelimeVeSayisi.GetLength(1); k++)
                {
                    if (kelimeVeSayisi[i, k] != null)
                    {
                        Console.Write(kelimeVeSayisi[i, k] + " ");
                    }
                }
            }
        }

        public void GirisKontrol()
        {
            do
            {
                Console.Write("Lütfen Geçerli Bir Metin Giriniz :");
            } while (string.IsNullOrWhiteSpace(Console.ReadLine().Trim()));
        }

        public void KelimeHarfSayisi()
        {

            Console.WriteLine("Lütfen Bir Makale Giriniz");

            //string girilenMakale = Console.ReadLine().Replace(",", "").Replace(".", "").Replace(";", "").Replace(":", "").Trim();

            // Boşluğa göre split yaparken gelen empty değerlerini almamak için StringSplitOptions.RemoveEmptyEntries kullanılır.
            string[] kelimeler = Console.ReadLine().Split(new char[] { ' ', '.', ',', ':', ';', '!' }, StringSplitOptions.RemoveEmptyEntries);
            int enBuyukHarfSayisi = 0;
            string kelime = "";

            for (int i = 0; i < kelimeler.Length; i++)
            {
                if (enBuyukHarfSayisi < kelimeler[i].Length)
                {
                    enBuyukHarfSayisi = kelimeler[i].Length;
                    kelime = kelimeler[i];
                }
            }

            Console.WriteLine("En çok harf sayisi {0} ile {1} kelimesine aittir", enBuyukHarfSayisi, kelime);

        }
    }
}

