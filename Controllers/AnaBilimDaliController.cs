using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using web_programlama_proje_001.Data;
using web_programlama_proje_001.Interfaces;
using web_programlama_proje_001.Models;
using web_programlama_proje_001.ViewModels;

namespace web_programlama_proje_001.Controllers
{
    public class AnaBilimDaliController : Controller
    {
        private readonly IAnaBilimDaliRepository _anaBilimDaliRepository;

        public AnaBilimDaliController(IAnaBilimDaliRepository anaBilimDaliRepository)
        {
            _anaBilimDaliRepository = anaBilimDaliRepository;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<AnaBilimDali> AnaBilimDalis = await _anaBilimDaliRepository.GetAll();
            return View(AnaBilimDalis);
        }

        public async Task<IActionResult> Details(int id)
        {
            // Id'ye göre AnaBilimDali'yi bul
            AnaBilimDali anaBilimDali = await _anaBilimDaliRepository.GetByIdAsync(id);

            if (anaBilimDali == null)
            {
                return NotFound();
            }

            // AnaBilimDali modelini DetailsAnaBilimDaliViewModel'e dönüştür
            var viewModel = new DetailsAnaBilimDaliViewModel
            {
                AnaBilimDaliId = anaBilimDali.AnaBilimDaliId,
                Name = anaBilimDali.Name,
                // Diğer özellikleri ekle...
            };

            return View(viewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            AnaBilimDali anaBilimDali = await _anaBilimDaliRepository.GetByIdAsync(id);

            if (anaBilimDali == null)
            {
                return NotFound();
            }

            // AnaBilimDali modelini EditAnaBilimDaliViewModel'e dönüştür
            var viewModel = new EditAnaBilimDaliViewModel
            {
                AnaBilimDaliId = anaBilimDali.AnaBilimDaliId,
                Name = anaBilimDali.Name,
                // Diğer özellikleri ekleyebilirsiniz...
            };

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditAnaBilimDaliViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                // ViewModel'i AnaBilimDali modeline dönüştür
                AnaBilimDali anaBilimDali = new AnaBilimDali
                {
                    AnaBilimDaliId = viewModel.AnaBilimDaliId,
                    Name = viewModel.Name,
                    // Diğer özellikleri ekleyebilirsiniz...
                };

                // Düzenlenmiş AnaBilimDali'yi güncelle
                _anaBilimDaliRepository.Update(anaBilimDali);

                return RedirectToAction("Details", new { id = viewModel.AnaBilimDaliId });
            }

            // ModelState geçerli değilse, formu tekrar göster
            return View(viewModel);
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            AnaBilimDali anaBilimDali = await _anaBilimDaliRepository.GetByIdAsync(id);

            if (anaBilimDali == null)
            {
                return NotFound();
            }

            return View(anaBilimDali);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            AnaBilimDali anaBilimDali = await _anaBilimDaliRepository.GetByIdAsync(id);

            if (anaBilimDali == null)
            {
                return NotFound();
            }

            // AnaBilimDali'yi sil
            _anaBilimDaliRepository.Delete(anaBilimDali);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CreateAnaBilimDaliViewModel model)
        {
            if (ModelState.IsValid)
            {
                AnaBilimDali yeniAnaBilimDali = new AnaBilimDali
                {
                    Name = model.Name
                    // Diğer özellikleri ekleyebilirsiniz...
                };

                _anaBilimDaliRepository.Add(yeniAnaBilimDali);

                return RedirectToAction("Index");
            }

            return View(model);
        }



    }


}
