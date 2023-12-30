namespace web_programlama_proje_001.Models
{
    public class AnaBilimDali
    {

        public class AnaBilimDali
        {
            public int Id { get; set; }
            public string Adi { get; set; }

            public virtual ICollection<Poliklinik> Poliklinikler { get; set; }
        }
    }
}
