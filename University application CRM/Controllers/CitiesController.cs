using Microsoft.AspNetCore.Mvc;
using University_application_CRM.Data;
using University_application_CRM.Models;

namespace University_application_CRM.Controllers
{
    public class CitiesController : Controller
    {
        private CRMContext _context;
        public CitiesController(CRMContext context)
        {
            _context = context;
        }

        public IActionResult Index(int id)
        {
            var cities = _context.Cities.Where(i => i.CountryId == id);
            return View(cities);
        }

        // GET: CitiesController/Create
        public IActionResult Add(int countryid)
        {
            var city = new City() { CountryId = countryid };
            return View(city);
        }

        // POST: CitiesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add(City city)
        {
            var City = new City()
            {
                CountryId = city.CountryId,
                Name = city.Name
            };
            _context.Add(City);
            _context.SaveChanges();
            return RedirectToAction("Index", new { id = city.CountryId });
        }

        // GET: CitiesController/Edit/5
        public IActionResult Edit(int id)
        {
            var city = _context.Cities.Where(i => i.Id == id).FirstOrDefault();
            return View(city);
        }

        // POST: CitiesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(City city)
        {
            var City = _context.Cities.Where(i => i.Id == city.Id).FirstOrDefault();
            City.Name = city.Name;
            _context.SaveChanges();
            return RedirectToAction("Index", new { id = city.CountryId });
        }

        // GET: CitiesController/Delete/5
        public IActionResult Delete(int id)
        {
            var city = _context.Cities.Where(i => i.Id == id).FirstOrDefault();
            return View(city);
        }

        // POST: CitiesController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var city = _context.Cities.Where(i => i.Id == id).FirstOrDefault();
            _context.Cities.Remove(city);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
