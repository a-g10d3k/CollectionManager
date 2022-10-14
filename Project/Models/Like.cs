using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project.Models
{
    public class Like
    {
        [Required]
        public int Id { get; set; }

        public string? UserId { get; set; }

        public int ItemId { get; set; }
        [ForeignKey("ItemId")]
        public CollectionItem Item { get; set; }
    }
}
