using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace web_programlama_proje_001.Models
{
    public class Doktor
    {
        [Key]
        public int DoktorId { get; set; }

        public string Name { get; set; }

        [ForeignKey("Poliklinik")]
        public int PoliklinikId { get; set; }
        
        public Poliklinik Poliklinik { get; set; }

    }
}
