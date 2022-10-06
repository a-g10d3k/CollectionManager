using System.ComponentModel.DataAnnotations;
namespace Project.Models
{
    public class CustomBoolField : CustomField
    {
        [Required]
        public bool Value { get; set; }
    }
}
