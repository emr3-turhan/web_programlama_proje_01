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
            IEnumerable<AnaBilimDali> anaBilimDaliList = await _anaBilimDaliRepository.GetAll();
            return View(anaBilimDaliList);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CreateAnaBilimDaliViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var anaBilimDali = new AnaBilimDali
                {
                    Name = viewModel.Name
                };

                _anaBilimDaliRepository.Add(anaBilimDali);
                return RedirectToAction("Index");
            }

            return View(viewModel);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var anaBilimDali = await _anaBilimDaliRepository.GetByIdAsync(id);

            if (anaBilimDali == null)
            {
                return NotFound();
            }

            var editViewModel = new EditAnaBilimDaliViewModel
            {
                AnaBilimDaliId = anaBilimDali.AnaBilimDaliId,
                Name = anaBilimDali.Name
                // Diğer özellikleri buraya ekleyebilirsiniz
            };

            return View(editViewModel);
        }

        [HttpPost]
        public IActionResult Edit(EditAnaBilimDaliViewModel editViewModel)
        {
            if (ModelState.IsValid)
            {
                var anaBilimDali = new AnaBilimDali
                {
                    AnaBilimDaliId = editViewModel.AnaBilimDaliId,
                    Name = editViewModel.Name
                    // Diğer özellikleri buraya ekleyebilirsiniz
                };

                _anaBilimDaliRepository.Update(anaBilimDali);
                return RedirectToAction("Index");
            }

            return View(editViewModel);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var anaBilimDali = await _anaBilimDaliRepository.GetByIdAsync(id);

            if (anaBilimDali == null)
            {
                return NotFound();
            }

            return View(anaBilimDali);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var anaBilimDali = _anaBilimDaliRepository.GetByIdAsync(id).Result;

            if (anaBilimDali != null)
            {
                _anaBilimDaliRepository.Delete(anaBilimDali);
                return RedirectToAction("Index");
            }

            return NotFound();
        }
    }


}
