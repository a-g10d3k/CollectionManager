namespace Project.Models
{
    public class HomePageModel
    {
        public List<CollectionItem> RecentItems { get; set; } = new List<CollectionItem>();
        public List<Collection> LargestCollections { get; set; } = new List<Collection>();
    }
}
