namespace Project.Models
{
    public class CollectionItemDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
        public List<Tag> Tags { get; set; } = new List<Tag>();
        public List<CustomIntField> CustomIntFields { get; set; } = new List<CustomIntField>();
        public List<CustomStringField> CustomStringFields { get; set; } = new List<CustomStringField>();
        public List<CustomTextAreaField> CustomTextAreaFields { get; set; } = new List<CustomTextAreaField>();
        public List<CustomBoolField> CustomBoolFields { get; set; } = new List<CustomBoolField>();
        public List<CustomDateField> CustomDateFields { get; set; } = new List<CustomDateField>();
        public bool Liked { get; set; }
        public List<Comment> Comments { get; set; } = new List<Comment>();
        public ApplicationUser? CurrentUser { get; set; }
        public bool IsAdmin { get; set; }

        public int LikeCount { get; set; }
        public Collection? Collection { get; set; }
    }
}
