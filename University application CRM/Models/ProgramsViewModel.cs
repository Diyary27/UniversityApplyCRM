using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace University_application_CRM.Models
{
    //fixed options
    public enum Level
    {
        Associate,
        Bachelor,
        Master,
        PhD
    }

    public class ProgramsViewModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int SpecialityId { get; set; }
        [Required]
        public int LanguageId { get; set; }
        [Required]
        public IEnumerable<Speciality> Specialities { get; set; }
        [Required]
        public string Speciality { get; set; }
        [Required]
        public IEnumerable<Language> Languages { get; set; }
        [Required]
        public string Language { get; set; }
        [Required]
        public Level Level { get; set; }
        public bool ActiveInSearch { get; set; }
        public bool ActiveInNewApps { get; set; }

        
    }
}
