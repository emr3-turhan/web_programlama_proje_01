using Microsoft.Extensions.Hosting;
using System.Data;

namespace web_programlama_proje_001.Models
{
    public class Kullanici
    {
        public int Id { get; set; }
        public string Adi { get; set; }
        public string Soyadi { get; set; }
        public string Email { get; set; }
        public string Sifre { get; set; }

        //public Role KullaniciTipi { get; set; }

        public virtual Doktor Doktor { get; set; }
        public virtual Hasta Hasta { get; set; }
        public virtual Admin Admin { get; set; }
    }
}
