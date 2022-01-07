using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace University_application_CRM.Models
{
    public class City
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int CountryId { get; set; }
        [Required]
        public string Name { get; set; }

        [ForeignKey("CountryId")]
        public Country Country { get; set; }
    }
}
