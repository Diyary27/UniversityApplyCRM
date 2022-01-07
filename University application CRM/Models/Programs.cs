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

    public class Programs
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int SpecialityId { get; set; }
        [Required]
        public int LanguageId { get; set; }
        [Required]
        public Level Level { get; set; }
        public bool ActiveInSearch { get; set; }
        public bool ActiveInNewApps { get; set; }

        [ForeignKey("SpecialityId")]
        public Speciality Speciality { get; set; }
        [ForeignKey("LanguageId")]
        public Language Language { get; set; }
        public List<UniversityProgram> UniversityPrograms { get; set; }
    }
}
