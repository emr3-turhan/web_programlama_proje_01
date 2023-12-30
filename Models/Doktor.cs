namespace web_programlama_proje_001.Models
{
    public class Doktor
    {
        public int Id { get; set; }
        public string Adi { get; set; }
        public string Soyadi { get; set; }

        public int PoliklinikId { get; set; }
        public virtual Poliklinik Poliklinik { get; set; }

        public virtual ICollection<CalismaSaati> CalismaSaatleri { get; set; }

        public virtual Kullanici Kullanici { get; set; }
    }
}
