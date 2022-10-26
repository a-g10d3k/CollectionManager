namespace Project.Models
{
    public interface IHasPages
    {
        public int Page { get; set; }
        public int MaxPage { get; set; }
        public int PrevPage { get => Page > 1 ? Page - 1 : 1; }
        public int NextPage { get => Page < MaxPage ? Page + 1 : MaxPage; }
    }
}
