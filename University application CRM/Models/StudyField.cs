using System.ComponentModel.DataAnnotations;

namespace University_application_CRM.Models
{
    public class StudyField
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name_en { get; set; }
        [Required]
        public string Name_fa { get; set; }
        public List<Speciality> Specialities { get; set; }
    }
}
