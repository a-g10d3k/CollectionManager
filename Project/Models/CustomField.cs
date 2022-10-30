using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace Project.Models
{
    public abstract class CustomField
    {
        public const int MaxNameLength = 25;

        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = "error_required_customfield_name")]
        [MaxLength(MaxNameLength, ErrorMessage = "error_maxlength_customfield_name")]
        public string Name { get; set; }

        public int? ItemId { get; set; }
        [ForeignKey("ItemId")]
        public CollectionItem? Item { get; set; }
    }
}
