using System.ComponentModel.DataAnnotations;

namespace web_programlama_proje_001.ViewModels
{
    public class EditPoliklinikViewModel
    {
        public int PoliklinikId { get; set; }

        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "AnaBilimDali is required")]
        public int AnaBilimDaliId { get; set; }
        // Diğer alanları ekleyebilirsiniz...
    }
}
