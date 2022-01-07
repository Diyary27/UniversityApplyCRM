using Microsoft.EntityFrameworkCore;
using University_application_CRM.Models;

namespace University_application_CRM.Data
{
    public class CRMContext : DbContext
    {
        public CRMContext (DbContextOptions<CRMContext> options) : base(options) 
        {
        }

        public DbSet<City> Cities { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<Programs> Programs { get; set; }
        public DbSet<Speciality> Specialities { get; set; }
        public DbSet<StudyField> StudyFields { get; set; }
        public DbSet<University> Universities { get; set; }
        public DbSet<UniversityProgram> UniversityPrograms { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
