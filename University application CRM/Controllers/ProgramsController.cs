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
            var Program = _context.Programs.Where(i => i.Id == id)
                .Include(i => i.Speciality).Include(i => i.Language).FirstOrDefault();

            var specialities = _context.Specialities.ToList();
            var languages = _context.Languages.ToList();

            var programsVM = new ProgramsViewModel()
            {
                Specialities = specialities,
                Speciality = Program.Speciality.Name_en,
                Languages = languages,
                Language = Program.Language.Name,
                Level = Enum.Parse<Level>(Program.Level),
                ActiveInSearch = Program.ActiveInSearch,
                ActiveInNewApps = Program.ActiveInNewApps
            };

            return View(programsVM);
        }

        [HttpPost]
        public IActionResult Edit(ProgramsViewModel programsVM)
        {
            var Speciality = _context.Specialities.Where(i => i.Name_en == programsVM.Speciality).FirstOrDefault();
            var Language = _context.Languages.Where(i => i.Name == programsVM.Language).FirstOrDefault();
            var Program = _context.Programs.Find(programsVM.Id);
            
            Program.SpecialityId = Speciality.Id;
            Program.LanguageId = Language.Id;
            Program.Level = programsVM.Level.ToString();
            Program.ActiveInSearch = programsVM.ActiveInSearch;
            Program.ActiveInNewApps = programsVM.ActiveInNewApps;

            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var Program = _context.Programs.Find(id);

            return View(Program);
        }

        [HttpPost]
        [ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var Program = _context.Programs.Find(id);
            _context.Programs.Remove(Program);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
