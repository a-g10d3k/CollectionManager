using System.ComponentModel.DataAnnotations;
namespace Project.Models
{
    public class CustomTextAreaField : CustomField
    {
        public const int MaxValueLength = 300;

        [Required]
        [MaxLength(MaxValueLength)]
        public string Value { get; set; }
    }
}
