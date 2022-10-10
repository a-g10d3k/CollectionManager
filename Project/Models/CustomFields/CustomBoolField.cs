using System.ComponentModel.DataAnnotations;
namespace Project.Models
{
    public class CustomBoolField : CustomField
    {
        public bool Value { get; set; } = false;
    }
}
