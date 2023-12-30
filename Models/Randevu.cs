namespace web_programlama_proje_001.Models
{
    public class Randevu
    {
        public int Id { get; set; }
        public DateTime Tarih { get; set; }

        public int DoktorId { get; set; }
        public int HastaId { get; set; }

        public virtual Doktor Doktor { get; set; }
        public virtual Hasta Hasta { get; set; }
    }
}
