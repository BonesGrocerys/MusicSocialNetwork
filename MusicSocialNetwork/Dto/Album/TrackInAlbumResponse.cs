using MusicSocialNetwork.Dto.Musician;

namespace MusicSocialNetwork.Dto.Album
{
    public class TrackInAlbumResponse
    {
        public int Id { get; set; }

        //public string Author { get; set; }

        public string Title { get; set; }

        public int AuditionsCount { get; set; }

        public string Url { get; set; }

        public List<MusicianResponse> Musicians { get; set; }

    }
}
