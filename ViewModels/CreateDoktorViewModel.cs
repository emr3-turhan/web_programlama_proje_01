using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace web_programlama_proje_001.ViewModels
{
    public class CreateDoktorViewModel
    {
        [Required(ErrorMessage = "Doktor adı zorunludur.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Poliklinik seçimi zorunludur.")]
        public int PoliklinikId { get; set; }
    }

}
