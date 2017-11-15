namespace KafeYonetim.Lib
{
    public class Urun
    {
        public Urun(int Id, string ad, float fiyat, bool stoktaVarMi)
        {
            ID = Id;
            Ad = ad;
            Fiyat = fiyat;
            StoktaVarMi = stoktaVarMi;
        }

        public int ID { get; private set; }
        public string Ad { get; private set; }
        public float Fiyat { get; private set; }
        public bool StoktaVarMi { get; private set; }
    }
}