namespace web_programlama_proje_001.Models
{
    public class Hasta
    {
        public int Id { get; set; }
        public string Adi { get; set; }
        public string Soyadi { get; set; }
        public string TcKimlikNo { get; set; }

        public virtual Kullanici Kullanici { get; set; }
    }
}
