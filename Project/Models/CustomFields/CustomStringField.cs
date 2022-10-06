using System.ComponentModel.DataAnnotations;
namespace Project.Models
{
    public class CustomStringField : CustomField
    {
        public const int MaxValueLength = 50;

        [Required]
        [MaxLength(MaxValueLength)]
        public string Value { get; set; }
    }
}
