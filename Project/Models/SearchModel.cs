using Microsoft.AspNetCore.Mvc;

namespace Project.Models
{
    public class SearchModel
    {
        public List<Collection> Collections { get; set; } = new List<Collection>();
        public List<CollectionItem> Items { get; set; } = new List<CollectionItem>();
    }
}
