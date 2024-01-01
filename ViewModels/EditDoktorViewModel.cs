using System.ComponentModel.DataAnnotations;

namespace web_programlama_proje_001.ViewModels
{
    public class EditDoktorViewModel
    {
        public int DoktorId { get; set; }

        [Required(ErrorMessage = "Doktor adı zorunludur.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Poliklinik seçimi zorunludur.")]
        public int PoliklinikId { get; set; }
    }
}
