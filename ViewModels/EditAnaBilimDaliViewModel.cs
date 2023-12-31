using System.ComponentModel.DataAnnotations;

namespace web_programlama_proje_001.ViewModels
{
    public class EditAnaBilimDaliViewModel
    {

        public int AnaBilimDaliId { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        public string Name { get; set; }
    }
}
