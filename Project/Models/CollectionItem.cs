using System.ComponentModel.DataAnnotations;

namespace Project.Models
{
    public class CollectionItem
    {
        public const int MaxNameLength = 50;

        [Required]
        public int Id { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [MaxLength(MaxNameLength)]
        public string Name { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime Created { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime Modified { get; set; }

        public ICollection<Tag> Tags;

        public ICollection<CustomField> CustomFields { get; set; }
    }
}
