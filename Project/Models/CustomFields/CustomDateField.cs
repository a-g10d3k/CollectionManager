using System.ComponentModel.DataAnnotations;
namespace Project.Models
{
    public class CustomDateField : CustomField
    {
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime Value { get; set; }
    }
}
