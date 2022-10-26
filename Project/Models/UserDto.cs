namespace Project.Models
{
    public class UserDto
    {
        public ApplicationUser User { get; set; }
        public List<Collection> Collections { get; set; }
        public bool IsOwner { get; set; } = false;
        public int page { get; set; } = 1;
        public int maxPage { get; set; } = 1;
    }
}
