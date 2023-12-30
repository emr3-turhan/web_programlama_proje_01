namespace web_programlama_proje_001.Models
{
    public class CalismaSaati
    {
        public int Id { get; set; }
        public int DoktorId { get; set; }
        public virtual Doktor Doktor { get; set; }

        public DayOfWeek Gun { get; set; }
        public TimeSpan BaslangicSaati { get; set; }
        public TimeSpan BitisSaati { get; set; }
    }
}
