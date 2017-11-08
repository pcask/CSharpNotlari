namespace KafeYonetim.Lib
{
    public class Urun
    {
        public Urun(string ad, float fiyat, bool stoktaVarMi)
        {
            Ad = ad;
            Fiyat = fiyat;
            StoktaVarMi = stoktaVarMi;
        }

        public string Ad { get; private set; }
        public float Fiyat { get; private set; }
        public bool StoktaVarMi { get; private set; }
    }
}