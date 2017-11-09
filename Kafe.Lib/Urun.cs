namespace KafeYonetim.Lib
{
    public class Urun
    {
        public Urun(string ad, float fiyat, bool stoktaVarMi)
        {
            Ad = ad;
            Fiyat = fiyat;
            StoktaVarmi = stoktaVarMi;
        }

        public string Ad { get; private set; }
        public float Fiyat { get; private set; }
        public bool StoktaVarmi { get; set; }
    }
}