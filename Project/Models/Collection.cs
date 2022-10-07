using System.ComponentModel.DataAnnotations;

namespace Project.Models
{
    public class Collection
    {
        public const int MaxNameLength = 50;
        public const int MaxDescriptionLength = 1000;
        public const string AllowedTopics = "Books|Stamps|Coins";
        [Required]
        public int Id { get; set; }

        [Required]
        [MaxLength(MaxNameLength)]
        public string Name { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime Created { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime Modified { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        [MaxLength(MaxDescriptionLength)]
        public string Description { get; set; }

        [Required]
        [RegularExpression(AllowedTopics)] 
        public string Topic { get; set; }

        [MaxLength(5 * 1_000_000)]
        public byte[]? Image { get; set; }

        public List<CollectionItem> Items { get; set; } = new List<CollectionItem>();

        public string? AuthorId { get; set; }
        public ApplicationUser? Author { get; set; }
    }
}
