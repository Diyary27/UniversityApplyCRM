using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using University_application_CRM.Data;
using University_application_CRM.Models;

namespace University_application_CRM.Controllers
{
    public class UniversitiesController : Controller
    {
        private CRMContext _context;
        public UniversitiesController(CRMContext context)
        {
            _context = context;
        }


        // GET: CountriesController
        public IActionResult Index()
        {
            var university = _context.Universities;
            return View(university);
        }


        // GET: CountriesController/Create
        public IActionResult Create()
        {
            var cityList = _context.Cities.ToList();
            var universityVM = new UniversityViewModel() { Cities = cityList};
            return View(universityVM);
        }

        // POST: CountriesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(UniversityViewModel universityVM)
        {
            //if (!ModelState.IsValid)
            //{
            //    return View(country);
            //}
            var city = _context.Cities.Where(c => c.Name == universityVM.City).FirstOrDefault();
            var university = new University()
            {
                CityId = city.Id,
                Title = universityVM.Title,
                Address = universityVM.Address,
                Founded = universityVM.Founded,
                Sector = universityVM.Sector.ToString(),
                Website = universityVM.Website,
                StudentCount = universityVM.StudentCount,
                About_en = universityVM.About_en,
                About_fa = universityVM.About_fa,
                SchoolType = universityVM.SchoolType.ToString(),
                ActiveInSearch = universityVM.ActiveInSearch,
                ActiveInNewApps = universityVM.ActiveInNewApps
            };
            _context.Universities.Add(university);
            _context.SaveChanges();

            var path = Path.Combine(Directory.GetCurrentDirectory(), 
                "wwwroot", "Images", "UniLogos", university.Id + ".jpg");
            universityVM.UniLogo.CopyTo(new FileStream(path, FileMode.Create));

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
