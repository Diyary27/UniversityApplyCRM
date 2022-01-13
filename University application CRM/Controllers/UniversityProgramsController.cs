using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using University_application_CRM.Data;
using University_application_CRM.Models;

namespace University_application_CRM.Controllers
{
    public class UniversityProgramsController : Controller
    {
        private CRMContext _context;

        public UniversityProgramsController(CRMContext context)
        {
            _context = context;
        }

        [Route("/Universities/{id}/Index")]
        public IActionResult Index([FromRoute]int id)
        {
            var uniprograms = _context.UniversityPrograms.Where(i => i.UniversityId == id)
                .Include(i => i.Program).ThenInclude(i => i.Speciality)
                .Include(i => i.Program).ThenInclude(i => i.Language).ToList();

            return View(uniprograms);
        }

        [HttpGet]
        [Route("/Universities/{id}/Create")]
        public IActionResult Create([FromRoute] int id)
        {
            var programs = _context.Programs.Include(i => i.Speciality).Include(i => i.Language).ToList();

            var UniProgramsVM = new UniversityProgramViewModel()
            {
                UniversityId = id,
                Programs = programs
            };

            return View(UniProgramsVM);
        }

        [HttpPost]
        [Route("/UniversityPrograms/{id}/Create")]
        public IActionResult Create(UniversityProgramViewModel UniProgramVM)
        {
            var Speciality = _context.Specialities.Where(i => i.Name_en == UniProgramVM.ProgramName).FirstOrDefault();
            var Program = _context.Programs.Where(n => n.SpecialityId == Speciality.Id).FirstOrDefault();

            var UniProgram = new UniversityProgram()
            {
                UniversityId = UniProgramVM.UniversityId,
                ProgramId = Program.Id,
                TuitionFee = UniProgramVM.TuitionFee,
                TuitionFeeDis = UniProgramVM.TuitionFeeDis,
                Commission = UniProgramVM.Commission,
                AdmissionReq_en = UniProgramVM.AdmissionReq_en,
                AdmissionReq_fa = UniProgramVM.AdmissionReq_fa,
                CareerPath_en = UniProgramVM.CareerPath_en,
                CareerPath_fa = UniProgramVM.CareerPath_fa,
                Description_en = UniProgramVM.Description_en,
                Description_fa = UniProgramVM.Description_fa,
                StudyYears = UniProgramVM.StudyYears,
                TuitionUnit = UniProgramVM.TuitionUnit.ToString(),
                ActiveInNewApps = UniProgramVM.ActiveInNewApps,
                ActiveInSearch = UniProgramVM.ActiveInSearch
            };

            _context.Add(UniProgram);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index), new {id = UniProgramVM.UniversityId});
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
