namespace web_programlama_proje_001.Models
{
    public class Poliklinik
    {
        public int Id { get; set; }
        public string Adi { get; set; }

        public int AnaBilimDaliId { get; set; }
        public virtual AnaBilimDali AnaBilimDali { get; set; }

        public virtual ICollection<Doktor> Doktorlar
        {
            get; set;
        }
    }
}
