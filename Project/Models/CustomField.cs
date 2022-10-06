using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace Project.Models
{
    public abstract class CustomField
    {
        public const int MaxNameLength = 25;

        [Required]
        public int Id { get; set; }

        [Required]
        [MaxLength(MaxNameLength)]
        public string Name { get; set; }

        [ForeignKey("ItemID")]
        public CollectionItem Item { get; set; }
    }
}
