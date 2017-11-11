using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KafeYonetim.Lib
{
    public class Kafe
    {
        // Constructor Metod = İnşa Edici Metod / Yapılandırıcı Metod
        public Kafe(string ad, string acilisSaati, string kapanisSaati)
        {
            Ad = ad;
            AcilisSaati = acilisSaati;
            KapanisSaati = kapanisSaati;

            Durum = KafeDurum.Kapali;

            Urunler = new List<Urun>();
            Calisanlar = new List<Calisan>();
            Masalar = new List<Masa>();
            Siparisler = new List<Siparis>();
        }

        public string Ad { get; private set; }
        public string AcilisSaati { get; private set; }
        public string KapanisSaati { get; private set; }
        public KafeDurum Durum { get; private set; }
        public List<Calisan> Calisanlar { get; set; }
        public List<Urun> Urunler { get; set; }
        public List<Masa> Masalar { get; set; }
        public List<Siparis> Siparisler { get; set; }

        public void Ac()
        {
            Durum = KafeDurum.Acik;
            Console.WriteLine("Kafemiz Açılmıştır");

            foreach (var calisan in Calisanlar)
            {
                calisan.MesaiyeBasla();
            }
        }

        public void Kapat()
        {
            Durum = KafeDurum.Kapali;
            Console.WriteLine("Kafemiz Kapanmıştır");
        }


        public Garson UygunGarsonuBul(CalisanDurum yeniDurum)
        {
            foreach (var calisan in Calisanlar)
            {
                if (!(calisan is Garson))
                {
                    continue;
                }

                if (calisan.MesaideMi && calisan.Durum == CalisanDurum.Uygun)
                {
                    calisan.Durum = yeniDurum;
                    return (Garson)calisan;
                }
            }
            return null;
        }
        public Asci UygunAsciBul(CalisanDurum yeniDurum)
        {
            foreach (var calisan in Calisanlar)
            {
                if (!(calisan is Asci))
                {
                    continue;
                }

                if (calisan.MesaideMi && calisan.Durum == CalisanDurum.Uygun)
                {
                    calisan.Durum = yeniDurum;
                    return (Asci)calisan;
                }
            }
            return null;
        }
    }

}
