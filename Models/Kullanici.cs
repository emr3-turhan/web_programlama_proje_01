using System.ComponentModel.DataAnnotations;

namespace web_programlama_proje_001.Models
{
    public class Kullanici
    {
        [Key]
        public int KullaniciId { get; set; }

        public string KullaniciAdi { get; set; }
        public string Sifre { get; set; }
        public string Email { get; set; }

        // Roller için kullanılabilir
        public List<Rol> Roller { get; set; }
    }
}
