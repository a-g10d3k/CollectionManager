namespace Project.Models
{
    public class UserDto : IHasPages
    {
        public ApplicationUser User { get; set; }
        public List<Collection> Collections { get; set; }
        public bool IsOwner { get; set; } = false;
        public int Page { get; set; } = 1;
        public int MaxPage { get; set; } = 1;
    }
}
