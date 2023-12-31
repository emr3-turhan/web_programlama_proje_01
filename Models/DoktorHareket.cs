using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace web_programlama_proje_001.Models
{
    public class DoktorHareket
    {
        [Key]
        public int DoktorHareketId { get; set; }

        public DateTime HareketTarihi { get; set; }
        public string HareketAciklama { get; set; }

        [ForeignKey("Doktor")]
        public int DoktorId { get; set; }
        public Doktor Doktor { get; set; }
    }
}
