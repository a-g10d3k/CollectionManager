using System.ComponentModel.DataAnnotations;
namespace Project.Models
{
    public class CustomIntField : CustomField
    {
        public int? Value { get; set; }
    }
}
