namespace MusicSocialNetwork.Dto.Track
{
    public class TrackCreateRequest
    {
        public string Author { get; set; }

        public string Title { get; set; }
        public string Nickname { get; set; }
        public int AlbumId { get; set; }

        // запрос с фронта на бэк-энд
    }
}
