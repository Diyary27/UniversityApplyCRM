using System.ComponentModel.DataAnnotations;

namespace University_application_CRM.Models
{
    public class University
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int CityId { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public int Founded { get; set; }
        [Required]
        [DataType(DataType.Url)]
        public string Website { get; set; }
        [Required]
        public string Sector { get; set; }
        [Required]
        public int StudentCount { get; set; }
        public string About_fa { get; set; }
        public string About_en { get; set; }
        [Required]
        public string SchoolType { get; set; }
        public bool ActiveInSearch { get; set; }
        public bool ActiveInNewApps { get; set; }

        public List<UniversityProgram> UniversityPrograms { get; set; }
        public City City { get; set; }
    }
}
