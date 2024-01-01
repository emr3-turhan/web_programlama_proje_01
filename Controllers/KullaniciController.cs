using Microsoft.AspNetCore.Mvc;

namespace web_programlama_proje_001.Controllers
{
    public class KullaniciController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
