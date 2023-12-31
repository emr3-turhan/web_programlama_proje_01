using System.ComponentModel.DataAnnotations;

namespace web_programlama_proje_001.Models
{
    public class Hasta
    {

        [Key]
        public int HastaId { get; set; }

        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string TCKimlikNo { get; set; }
        public string Telefon { get; set; }


    }
}
