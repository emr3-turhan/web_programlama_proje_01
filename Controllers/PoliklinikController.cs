using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using web_programlama_proje_001.Interfaces;
using web_programlama_proje_001.Models;
using web_programlama_proje_001.ViewModels;

namespace web_programlama_proje_001.Controllers
{
    public class PoliklinikController : Controller
    {
        private readonly IPoliklinikRepository _poliklinikRepository;
        private readonly IAnaBilimDaliRepository _anaBilimDaliRepository;

        public PoliklinikController(IPoliklinikRepository poliklinikRepository, IAnaBilimDaliRepository anaBilimDaliRepository)
        {
            _poliklinikRepository = poliklinikRepository;
            _anaBilimDaliRepository = anaBilimDaliRepository;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<Poliklinik> poliklinikler = await _poliklinikRepository.GetAll();
            return View(poliklinikler);
        }


        public async Task<IActionResult> Details(int id)
        {
            Poliklinik poliklinik = await _poliklinikRepository.GetByIdAsync(id);

            if (poliklinik == null)
            {
                return NotFound();
            }

            var viewModel = new DetailsPoliklinikViewModel
            {
                PoliklinikId = poliklinik.PoliklinikId,
                Name = poliklinik.Name,
                // Diğer özellikleri ekleyebilirsiniz...
            };

            return View(viewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            Poliklinik poliklinik = await _poliklinikRepository.GetByIdAsync(id);

            if (poliklinik == null)
            {
                return NotFound();
            }

            var viewModel = new EditPoliklinikViewModel
            {
                PoliklinikId = poliklinik.PoliklinikId,
                Name = poliklinik.Name,
                // Diğer özellikleri ekleyebilirsiniz...
            };

            // ViewBag kullanarak AnaBilimDali listesini gönder
            ViewBag.AnaBilimDaliList = await GetAnaBilimDaliSelectListItems();

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditPoliklinikViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                Poliklinik poliklinik = new Poliklinik
                {
                    PoliklinikId = viewModel.PoliklinikId,
                    Name = viewModel.Name,
                    // Diğer özellikleri ekleyebilirsiniz...
                };

                // Düzenlenmiş Poliklinik'yi güncelle
                _poliklinikRepository.Update(poliklinik);

                return RedirectToAction("Details", new { id = viewModel.PoliklinikId });
            }

            // ModelState geçerli değilse, formu tekrar göster
            ViewBag.AnaBilimDaliList = await GetAnaBilimDaliSelectListItems();
            return View(viewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            Poliklinik poliklinik = await _poliklinikRepository.GetByIdAsync(id);

            if (poliklinik == null)
            {
                return NotFound();
            }

            return View(poliklinik);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            Poliklinik poliklinik = await _poliklinikRepository.GetByIdAsync(id);

            if (poliklinik == null)
            {
                return NotFound();
            }

            // Poliklinik'yi sil
            _poliklinikRepository.Delete(poliklinik);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            // ViewBag kullanarak AnaBilimDali listesini gönder
            ViewBag.AnaBilimDaliList = await GetAnaBilimDaliSelectListItems();
            return View();
        }

        [HttpPost]
        public IActionResult Create(CreatePoliklinikViewModel model)
        {
            if (ModelState.IsValid)
            {
                Poliklinik yeniPoliklinik = new Poliklinik
                {
                    Name = model.Name,
                    // Diğer özellikleri ekleyebilirsiniz...
                };

                _poliklinikRepository.Add(yeniPoliklinik);

                return RedirectToAction("Index");
            }

            // ModelState geçerli değilse, formu tekrar göster
            ViewBag.AnaBilimDaliList = GetAnaBilimDaliSelectListItems();
            return View(model);
        }

        private async Task<List<SelectListItem>> GetAnaBilimDaliSelectListItems()
        {
            var anaBilimDaliList = await _anaBilimDaliRepository.GetAll();
            return anaBilimDaliList
                .Select(abd => new SelectListItem { Value = abd.AnaBilimDaliId.ToString(), Text = abd.Name })
                .ToList();
        }
    }

}
