using Microsoft.AspNetCore.Mvc;
using University_application_CRM.Data;
using University_application_CRM.Models;

namespace University_application_CRM.Controllers
{
    public class StudyFieldsController : Controller
    {
        private CRMContext _context;
        public StudyFieldsController(CRMContext context)
        {
            _context = context;
        }


        // GET: CountriesController
        public IActionResult Index()
        {
            var studyField = _context.StudyFields;
            return View(studyField);
        }


        // GET: CountriesController/Create
        public IActionResult Create()
        {
            var studyField = new StudyField();
            return View(studyField);
        }

        // POST: CountriesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(StudyField studyField)
        {
            //if (!ModelState.IsValid)
            //{
            //    return View(country);
            //}

            var StudyField = new StudyField()
            {
                Name_en = studyField.Name_en,
                Name_fa = studyField.Name_fa
            };
            _context.StudyFields.Add(StudyField);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        // GET: CountriesController/Edit/5
        public IActionResult Edit(int id)
        {
            var studyField = _context.StudyFields.Where(i => i.Id == id).FirstOrDefault();
            return View(studyField);
        }

        // POST: CountriesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(StudyField studyField)
        {
            var StudyField = _context.StudyFields.Where(i => i.Id == studyField.Id).FirstOrDefault();

            StudyField.Name_en = studyField.Name_en;
            StudyField.Name_fa = studyField.Name_fa;
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
            var studyField = _context.StudyFields.Where(i => i.Id == id).FirstOrDefault();
            if (studyField == null)
            {
                return NotFound();
            }
            return View(studyField);
        }

        // POST: CountriesController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var studyField = _context.StudyFields.Find(id);
            _context.Remove(studyField);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
    }
}
