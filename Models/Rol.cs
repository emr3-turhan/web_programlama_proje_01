using System.ComponentModel.DataAnnotations;

namespace web_programlama_proje_001.Models
{
    public class Rol
    {
        [Key]
        public int RolId { get; set; }

        public string RolAdi { get; set; }
    }
}
