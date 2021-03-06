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
            var university = _context.Universities.Where(i => i.Id == id)
                .Include(c => c.City).FirstOrDefault();

            var cityList = _context.Cities.ToList();

            var universityVM = new UniversityViewModel()
            {
                Id = university.Id,
                Title = university.Title,
                Address = university.Address,
                Founded = university.Founded,
                Sector = Enum.Parse<Sector>(university.Sector),
                Website = university.Website,
                StudentCount = university.StudentCount,
                About_en = university.About_en,
                About_fa = university.About_fa,
                Cities = cityList,
                City = university.City.Name,
                SchoolType = Enum.Parse<SchoolType>(university.SchoolType),
                ActiveInSearch = university.ActiveInSearch,
                ActiveInNewApps = university.ActiveInNewApps
            };
            return View(universityVM);
        }

        // POST: CountriesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(UniversityViewModel universityVM)
        {
            var university = _context.Universities.Find(universityVM.Id);
            university.Title = universityVM.Title;
            university.Address = universityVM.Address;
            university.Founded = universityVM.Founded;
            university.Sector = universityVM.Sector.ToString();
            university.Website = universityVM.Website;
            university.StudentCount = universityVM.StudentCount;
            university.About_en = universityVM.About_en;
            university.About_fa = universityVM.About_fa;
            university.SchoolType = universityVM.SchoolType.ToString();
            university.ActiveInSearch = universityVM.ActiveInSearch;
            university.ActiveInNewApps = universityVM.ActiveInNewApps;
            _context.SaveChanges();

            var path = Path.Combine(Directory.GetCurrentDirectory(),
                "wwwroot", "Images", "UniLogos", university.Id + ".jpg");
            universityVM.UniLogo.CopyTo(new FileStream(path, FileMode.Create));

            return RedirectToAction(nameof(Index));
        }

        // GET: CountriesController/Delete/5
        public IActionResult Delete(int id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var university = _context.Universities.Where(i => i.Id == id)
                .Include(c => c.City).FirstOrDefault();

            var cityList = _context.Cities.ToList();

            var universityVM = new UniversityViewModel()
            {
                Id = university.Id,
                Title = university.Title,
                Address = university.Address,
                Founded = university.Founded,
                Sector = Enum.Parse<Sector>(university.Sector),
                Website = university.Website,
                StudentCount = university.StudentCount,
                About_en = university.About_en,
                About_fa = university.About_fa,
                Cities = cityList,
                City = university.City.Name,
                SchoolType = Enum.Parse<SchoolType>(university.SchoolType),
                ActiveInSearch = university.ActiveInSearch,
                ActiveInNewApps = university.ActiveInNewApps
            };
            return View(universityVM);
        }

        // POST: CountriesController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var university = _context.Universities.Find(id);
            _context.Remove(university);
            _context.SaveChanges();

            var path = Path.Combine(Directory.GetCurrentDirectory(),
                "wwwroot", "Images", "UniLogos", university.Id + ".jpg");
            System.IO.File.Delete(path);

            return RedirectToAction(nameof(Index));
        }
    }
}
