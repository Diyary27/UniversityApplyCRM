using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace University_application_CRM.Models
{
    public enum TuitionUnit
    {
        Whole_Study,
        Year,
        Month
    }

    public class UniversityProgramViewModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int ProgramId { get; set; }
        [Required]
        public string ProgramName { get; set; }
        [Required]
        public IEnumerable<Programs> Programs { get; set; }
        [Required]
        public int UniversityId { get; set; }
        [Required]
        public decimal TuitionFee { get; set; }
        public decimal TuitionFeeDis { get; set; }
        public decimal Commission { get; set; }
        public string AdmissionReq_fa { get; set; }
        public string AdmissionReq_en { get; set; }
        public string CareerPath_fa { get; set; }
        public string CareerPath_en { get; set; }
        public string Description_fa { get; set; }
        public string Description_en { get; set; }
        [Required]
        public int StudyYears { get; set; }
        [Required]
        public TuitionUnit TuitionUnit { get; set; }
        public bool ActiveInSearch { get; set; }
        public bool ActiveInNewApps { get; set; }


        [ForeignKey("UniversityId")]
        public University University { get; set; }
        [ForeignKey("ProgramId")]
        public Programs Program { get; set; }

    }
}
