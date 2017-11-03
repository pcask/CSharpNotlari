using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstraction
{
    class Soyutlama
    {

    }


    class Televizyon
    {
        public string Tip { get; set; }

        public string Marka { get; set; }
        public string Model { get; set; }

        public string Renk { get; set; }
        public int AgirlikKg { get; set; }

        public int EkranBoyutuInch { get; set; }
        public int EkranBoyutuCm { get; set; }

        public int CozunurlukYatay { get; set; }
        public int CozunurlukDikey { get; set; }

        public bool Wifi { get; set; }
        public bool HDMI { get; set; }
        public bool USB { get; set; }

        public string Mensei { get; set; }
        public byte GarantiSuresiAy { get; set; }


        private bool CalismaDurumu { get; set; }
        private byte SesSeviyesi { get; set; }


        public Dugme[] Dugmeler;

        public bool CalismaDurumuGetir()
        {
            return CalismaDurumu;
        }

        public byte SesSeviyesiGetir()
        {
            return SesSeviyesi;
        }

        public void Ac()
        {
            CalismaDurumu = true;
            Console.WriteLine("Televizyon Açık");
        }

        public void Kapat()
        {
            CalismaDurumu = false;
            Console.WriteLine("Televiz Kapalı");
        }

        public void SesiArttır()
        {
            SesSeviyesi++;
            Console.WriteLine("Ses Arttırılıyor");
        }

        public void SesiAzalt()
        {
            SesSeviyesi--;
            Console.WriteLine("Ses Azaltılıyor");
        }
    }

    public abstract class Dugme
    {
        public string Ad { get; set; }

        public abstract string Bas();
    }

    public class Power : Dugme
    {
        public override string Bas()
        {
            Console.WriteLine("Power Tuşuna Basıldı");
            return "Power Tuşuna Basıldı";
        }
    }
}
