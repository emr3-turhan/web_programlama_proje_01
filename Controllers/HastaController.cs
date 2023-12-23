using Microsoft.AspNetCore.Mvc;

namespace web_programlama_proje_001.Controllers
{
    public class HastaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
