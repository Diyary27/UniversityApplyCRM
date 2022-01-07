using System.ComponentModel.DataAnnotations;

namespace University_application_CRM.Models
{
    //static options
    public enum Sector
    {
        Public = 1,
        Private = 2
    }
    public enum SchoolType
    {
        College = 1,
        High_School = 2,
        Institution = 3,
        University = 4
    }

    public class UniversityViewModel
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
        public Sector Sector { get; set; }
        [Required]
        public int StudentCount { get; set; }
        public string About_fa { get; set; }
        public string About_en { get; set; }
        [Required]
        public SchoolType SchoolType { get; set; }
        [Required]
        [DataType(DataType.Upload)]
        public IFormFile UniLogo { get; set; }
        public bool ActiveInSearch { get; set; }
        public bool ActiveInNewApps { get; set; }

        public List<UniversityProgram> UniversityPrograms { get; set; }
        public IEnumerable<City> Cities { get; set; }
        public string City { get; set; }
    }
}
