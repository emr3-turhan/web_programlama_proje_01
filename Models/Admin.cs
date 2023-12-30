namespace web_programlama_proje_001.Models
{
    public class Admin
    {
        public int Id { get; set; }

        public virtual Kullanici Kullanici { get; set; }

        public string Sifre {  get; set; }
    }
}
