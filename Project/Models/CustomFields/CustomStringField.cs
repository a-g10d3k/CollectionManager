using System.ComponentModel.DataAnnotations;
namespace Project.Models
{
    public class CustomStringField : CustomField
    {
        public const int MaxValueLength = 50;

        [MaxLength(MaxValueLength, ErrorMessage = "error_maxlength_customfield_string")]
        public string? Value { get; set; }
    }
}
