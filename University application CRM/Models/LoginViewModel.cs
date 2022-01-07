using System.ComponentModel.DataAnnotations;

namespace University_application_CRM.Models
{
    public class LoginViewModel
    {
        [Required]
        [MaxLength(50)]
        public string UserName { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [MaxLength(50)]
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}
