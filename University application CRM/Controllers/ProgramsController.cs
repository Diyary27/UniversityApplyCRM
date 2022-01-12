using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using University_application_CRM.Data;
using University_application_CRM.Models;

namespace University_application_CRM.Controllers
{
    public class ProgramsController : Controller
    {
        private CRMContext _context;

        public ProgramsController(CRMContext context)
        {
            _context = context;
        }


        public IActionResult Index()
        {
            var programs = _context.Programs.Include(i => i.Speciality).Include(i => i.Language);
            return View(programs);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var specialities = _context.Specialities.ToList();
            var languages = _context.Languages.ToList();

            var programsVM = new ProgramsViewModel()
            {
                Specialities = specialities,
                Languages = languages,
                ActiveInNewApps = true,
                ActiveInSearch = true
            };

            return View(programsVM);
        }

        [HttpPost]
        public IActionResult Create(ProgramsViewModel programsVM)
        {
            var Speciality = _context.Specialities.Where(i => i.Name_en == programsVM.Speciality).FirstOrDefault();
            var Language = _context.Languages.Where(i => i.Name == programsVM.Language).FirstOrDefault();

            var Program = new Programs()
            {
                SpecialityId = Speciality.Id,
                LanguageId = Language.Id,
                Level = programsVM.Level.ToString(),
                ActiveInSearch = programsVM.ActiveInSearch,
                ActiveInNewApps = programsVM.ActiveInNewApps
            };
            _context.Add(Program);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {

            return View();
        }

        [HttpPost]
        public IActionResult Edit(ProgramsViewModel programsVM)
        {

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {

            return View();
        }

        [HttpPost]
        [ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {

            return View();
        }
    }
}
