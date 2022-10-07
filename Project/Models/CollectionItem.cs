using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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

        public List<Tag> Tags { get; set; } = new List<Tag>();

        public List<CustomIntField> CustomIntFields { get; set; } = new List<CustomIntField>();
        public List<CustomStringField> CustomStringFields { get; set; } = new List<CustomStringField>();
        public List<CustomTextAreaField> CustomTextAreaFields { get; set; } = new List<CustomTextAreaField>();
        public List<CustomBoolField> CustomBoolFields { get; set; } = new List<CustomBoolField>();
        public List<CustomDateField> CustomDateFields { get; set; } = new List<CustomDateField>();

        [ForeignKey("CollectionId")]
        public Collection? Collection { get; set; }
    }
}
