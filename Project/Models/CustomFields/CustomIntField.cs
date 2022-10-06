using System.ComponentModel.DataAnnotations;
namespace Project.Models
{
    public class CustomIntField : CustomField
    {
        [Required]
        public int Value { get; set; }
    }
}
