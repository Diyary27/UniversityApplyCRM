using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace University_application_CRM.Models
{
    public class Speciality
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int StudyFieldId { get; set; }
        [Required]
        public string Name_fa { get; set; }
        [Required]
        public string Name_en { get; set; }

        [ForeignKey("StudyFieldId")]
        public StudyField StudyField { get; set; }
    }
}
