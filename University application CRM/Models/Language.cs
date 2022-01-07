﻿using System.ComponentModel.DataAnnotations;

namespace University_application_CRM.Models
{
    public class Language
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public List<Programs> Programs { get; set; }
    }
}