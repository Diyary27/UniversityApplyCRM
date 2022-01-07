using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using University_application_CRM.Data;
using University_application_CRM.Models;

namespace University_application_CRM.Controllers
{
    public class LanguagesController : Controller
    {
        private CRMContext _context;
        public LanguagesController(CRMContext context)
        {
            _context = context;
        }


        // GET: CountriesController
        public IActionResult Index()
        {
            var languages = _context.Languages;
            return View(languages);
        }


        // GET: CountriesController/Create
        public IActionResult Create()
        {
            var country = new Language();
            return View(country);
        }

        // POST: CountriesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Language language)
        {
            //if (!ModelState.IsValid)
            //{
            //    return View(country);
            //}

            var Language = new Language()
            {
                Name = language.Name,
            };
            _context.Languages.Add(Language);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        // GET: CountriesController/Edit/5
        public IActionResult Edit(int id)
        {
            var language = _context.Languages.Where(i => i.Id == id).FirstOrDefault();
            return View(language);
        }

        // POST: CountriesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Language language)
        {
            var Language = _context.Languages.Where(i => i.Id == language.Id).FirstOrDefault();
            Language.Name = language.Name;
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        // GET: CountriesController/Delete/5
        public IActionResult Delete(int id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var language = _context.Languages.Where(i => i.Id == id).FirstOrDefault();
            if (language == null)
            {
                return NotFound();
            }
            return View(language);
        }

        // POST: CountriesController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var language = _context.Languages.Find(id);
            _context.Remove(language);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
    }
}
