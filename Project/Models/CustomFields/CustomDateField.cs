using System.ComponentModel.DataAnnotations;
namespace Project.Models
{
    public class CustomDateField : CustomField
    {
        [DataType(DataType.DateTime)]
        public DateTime? Value { get; set; }
    }
}
