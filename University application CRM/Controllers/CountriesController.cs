using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using University_application_CRM.Data;
using University_application_CRM.Models;

namespace University_application_CRM.Controllers
{
    public class CountriesController : Controller
    {
        private CRMContext _context;
        public CountriesController(CRMContext context)
        {
            _context = context;
        }


        // GET: CountriesController
        public IActionResult Index()
        {
            var countries = _context.Countries;
            return View(countries);
        }


        // GET: CountriesController/Create
        public IActionResult Create()
        {
            var country = new Country();
            return View(country);
        }

        // POST: CountriesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Country country)
        {
            //if (!ModelState.IsValid)
            //{
            //    return View(country);
            //}

            var Country = new Country()
            {
                Name = country.Name,
                Cities = null
            };
            _context.Countries.Add(Country);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        // GET: CountriesController/Edit/5
        public IActionResult Edit(int id)
        {
            var country = _context.Countries.Where(i => i.Id == id).FirstOrDefault();
            return View(country);
        }

        // POST: CountriesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Country country)
        {
            var Country = _context.Countries.Where(i => i.Id == country.Id).FirstOrDefault();
            Country.Name = country.Name;
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        // GET: CountriesController/Delete/5
        public IActionResult Delete(int id)
        {
            if(id == null)
            {
                return NotFound();
            }
            var country = _context.Countries.Where(i => i.Id == id).FirstOrDefault();
            if (country == null)
            {
                return NotFound();
            }
            return View(country);
        }

        // POST: CountriesController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var country = _context.Countries.Find(id);
            _context.Remove(country);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
        
    }
}
