using System.ComponentModel.DataAnnotations;
namespace Project.Models
{
    public class CustomTextAreaField : CustomField
    {
        public const int MaxValueLength = 300;

        [MaxLength(MaxValueLength, ErrorMessage = "error_maxlength_customfield_textarea")]
        public string? Value { get; set; }
    }
}
