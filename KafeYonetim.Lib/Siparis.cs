namespace KafeYonetim.Lib
{
    public class Siparis
    {
        public int SiparisNo { get; private set; }
        public Kalem[] Kalemler { get; set; }
        public Garson SiparisiAlanGarson { get; set; }
        public Asci SiparisiHazirlayanAsci { get; set; }
        public string Not { get; set; }
        public Masa Masa { get; set; }
        public float ToplamFiyat
        {
            get
            {
                float toplam = 0f;
                foreach (var kalem in Kalemler)
                {
                    toplam += kalem.Urun.Fiyat * kalem.Adet;
                }

                return toplam;
            }
        }
    }
}