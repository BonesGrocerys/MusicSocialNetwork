namespace MusicSocialNetwork.Common
{
    public class Pagination<T>
    {
        public List<T> Items { get; set; }

        public int TotalCount { get; set; }
    }
}
