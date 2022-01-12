using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace University_application_CRM.Models
{

    public class Programs
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int SpecialityId { get; set; }
        [Required]
        public int LanguageId { get; set; }
        [Required]
        public string Level { get; set; }
        public bool ActiveInSearch { get; set; }
        public bool ActiveInNewApps { get; set; }

        [ForeignKey("SpecialityId")]
        public Speciality Speciality { get; set; }
        [ForeignKey("LanguageId")]
        public Language Language { get; set; }
        public List<UniversityProgram> UniversityPrograms { get; set; }
    }
}
