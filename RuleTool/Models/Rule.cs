using System;
using System.ComponentModel.DataAnnotations;

namespace RuleTool.Models
{
    public class Rule
    {
        public int id { get; set; }
        [Required]
        public string Name { get; set; }
        [Display(Name = "Value")]
        [Required]
        public string FieldLeft { get; set; }
        [Required]
        public string Operator { get; set; }
        [Display(Name = "Value")]
        [Required]
        public string FieldRight { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Creator { get; set; }
        public string Region { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Date of Creation")]
        public DateTime CreationDate { get; set; }

    }
}
