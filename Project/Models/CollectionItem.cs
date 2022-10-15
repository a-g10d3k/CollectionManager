using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project.Models
{
    public class CollectionItem
    {
        public const int MaxNameLength = 50;

        public CollectionItem() { }

        public CollectionItem(Collection collection)
        {
            Collection = collection;
            CopyCustomFields(CustomIntFields, collection.Items[0].CustomIntFields);
            CopyCustomFields(CustomStringFields, collection.Items[0].CustomStringFields);
            CopyCustomFields(CustomTextAreaFields, collection.Items[0].CustomTextAreaFields);
            CopyCustomFields(CustomBoolFields, collection.Items[0].CustomBoolFields);
            CopyCustomFields(CustomDateFields, collection.Items[0].CustomDateFields);
        }

        private void CopyCustomFields<T>(List<T> destination, List<T> origin) where T : CustomField, new()
        {
            foreach (var item in origin)
                destination.Add(new T() { Name = item.Name });
        }

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

        public bool Hidden { get; set; }

        public List<Tag> Tags { get; set; } = new List<Tag>();

        public List<CustomIntField> CustomIntFields { get; set; } = new List<CustomIntField>();
        public List<CustomStringField> CustomStringFields { get; set; } = new List<CustomStringField>();
        public List<CustomTextAreaField> CustomTextAreaFields { get; set; } = new List<CustomTextAreaField>();
        public List<CustomBoolField> CustomBoolFields { get; set; } = new List<CustomBoolField>();
        public List<CustomDateField> CustomDateFields { get; set; } = new List<CustomDateField>();

        public List<Like> Likes { get; set; } = new List<Like>();
        public List<Comment> Comments { get; set; } = new List<Comment>();
        [ForeignKey("CollectionId")]
        public Collection? Collection { get; set; }
    }
}
