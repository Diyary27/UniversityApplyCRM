using Microsoft.AspNetCore.Mvc;
using University_application_CRM.Data;
using University_application_CRM.Models;

namespace University_application_CRM.Controllers
{
    public class SpecialitiesController : Controller
    {
        private CRMContext _context;
        public SpecialitiesController(CRMContext context)
        {
            _context = context;
        }


        // GET: CountriesController
        public IActionResult Index(int id)
        {
            var specialities = _context.Specialities.Where(s => s.StudyFieldId == id);
            return View(specialities);
        }


        // GET: CountriesController/Create
        public IActionResult Create(int id)
        {
            var speciality = new Speciality() { StudyFieldId = id};
            return View(speciality);
        }

        // POST: CountriesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Speciality speciality)
        {
            //if (!ModelState.IsValid)
            //{
            //    return View(country);
            //}

            var Speciality = new Speciality()
            {
                StudyFieldId = speciality.StudyFieldId,
                Name_en = speciality.Name_en,
                Name_fa = speciality.Name_fa
            };
            _context.Specialities.Add(Speciality);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index), new { id = Speciality.StudyFieldId });
        }

        // GET: CountriesController/Edit/5
        public IActionResult Edit(int id)
        {
            var speciality = _context.Specialities.Where(i => i.Id == id).FirstOrDefault();
            return View(speciality);
        }

        // POST: CountriesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Speciality speciality)
        {
            var Speciality = _context.Specialities.Where(i => i.Id == speciality.Id).FirstOrDefault();

            Speciality.Name_en = speciality.Name_en;
            Speciality.Name_fa = speciality.Name_fa;
            _context.SaveChanges();
            return RedirectToAction(nameof(Index), new {id = speciality.StudyFieldId});
        }

        // GET: CountriesController/Delete/5
        public IActionResult Delete(int id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var speciality = _context.Specialities.Where(i => i.Id == id).FirstOrDefault();
            if (speciality == null)
            {
                return NotFound();
            }
            return View(speciality);
        }

        // POST: CountriesController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var speciality = _context.Specialities.Find(id);
            _context.Remove(speciality);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index), new { id = speciality.StudyFieldId });
        }
    }
}
