namespace Project.Models
{
    public class CollectionDto : IHasPages
    {
        public Collection Collection { get; set; }
        public List<CollectionItem> Items { get; set; }
        public int Page { get; set; } = 1;
        public int MaxPage { get; set; } = 1;
    }
}
