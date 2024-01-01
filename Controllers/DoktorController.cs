using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using web_programlama_proje_001.Interfaces;
using web_programlama_proje_001.Models;
using web_programlama_proje_001.ViewModels;

namespace web_programlama_proje_001.Controllers
{
    public class DoktorController : Controller
    {
        private readonly IDoktorRepository _doktorRepository;
        private readonly IPoliklinikRepository _poliklinikRepository;

        public DoktorController(IDoktorRepository doktorRepository, IPoliklinikRepository poliklinikRepository)
        {
            _doktorRepository = doktorRepository;
            _poliklinikRepository = poliklinikRepository;
        }

        public async Task<IActionResult> Index()
        {
            var doktorList = await _doktorRepository.GetAll();
            return View(doktorList);
        }

        public IActionResult Create()
        {
            ViewBag.Polikliniklar = new SelectList((System.Collections.IEnumerable)_poliklinikRepository.GetAll(), "PoliklinikId", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CreateDoktorViewModel doktorVM)
        {
            if (ModelState.IsValid)
            {
                var doktor = new Doktor
                {
                    Name = doktorVM.Name,
                    PoliklinikId = doktorVM.PoliklinikId
                };

                _doktorRepository.Add(doktor);

                return RedirectToAction("Index");
            }

            ViewBag.Polikliniklar = new SelectList((System.Collections.IEnumerable)_poliklinikRepository.GetAll(), "PoliklinikId", "Name", doktorVM.PoliklinikId);
            return View(doktorVM);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var doktor = await _doktorRepository.GetByIdAsync(id);

            if (doktor == null)
            {
                return NotFound();
            }

            var doktorVM = new EditDoktorViewModel
            {
                DoktorId = doktor.DoktorId,
                Name = doktor.Name,
                PoliklinikId = doktor.PoliklinikId
            };

            ViewBag.Polikliniklar = new SelectList((System.Collections.IEnumerable)_poliklinikRepository.GetAll(), "PoliklinikId", "Name", doktorVM.PoliklinikId);
            return View(doktorVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, EditDoktorViewModel doktorVM)
        {
            if (id != doktorVM.DoktorId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var doktor = new Doktor
                {
                    DoktorId = doktorVM.DoktorId,
                    Name = doktorVM.Name,
                    PoliklinikId = doktorVM.PoliklinikId
                };

                _doktorRepository.Update(doktor);

                return RedirectToAction("Index");
            }

            ViewBag.Polikliniklar = new SelectList((System.Collections.IEnumerable)_poliklinikRepository.GetAll(), "PoliklinikId", "Name", doktorVM.PoliklinikId);
            return View(doktorVM);
        }

        public async Task<IActionResult> Details(int id)
        {
            var doktor = await _doktorRepository.GetByIdAsync(id);

            if (doktor == null)
            {
                return NotFound();
            }

            return View(doktor);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var doktor = await _doktorRepository.GetByIdAsync(id);

            if (doktor == null)
            {
                return NotFound();
            }

            return View(doktor);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var doktor = _doktorRepository.GetByIdAsync(id).Result;

            if (doktor == null)
            {
                return NotFound();
            }

            _doktorRepository.Delete(doktor);

            return RedirectToAction("Index");
        }
    }

}
