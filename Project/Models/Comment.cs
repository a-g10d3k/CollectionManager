using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project.Models
{
    public class Comment
    {
        public const int MaxLength = 200;
        [Required]
        public int Id { get; set; }

        public string? UserId { get; set; }
        public string? UserName { get; set; }

        public int ItemId { get; set; }
        [ForeignKey("ItemId")]
        public CollectionItem Item { get; set; }

        [Required]
        [MaxLength(MaxLength)]
        public string Text { get; set; }

        public DateTime Created { get; set; }
    }
}
