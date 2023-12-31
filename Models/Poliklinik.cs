using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace web_programlama_proje_001.Models
{
    public class Poliklinik
    {
        [Key]
        public int PoliklinikId { get; set; }
        public string Name { get; set; }

        [ForeignKey("AnaBilimDali")]
        public int AnaBilimDaliId { get; set; }

        public AnaBilimDali AnaBilimDali { get; set; }

        public List<Doktor> Doktorlar { get; set; }
    }
}
