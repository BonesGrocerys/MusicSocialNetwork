using MusicSocialNetwork.Dto.Track;

namespace MusicSocialNetwork.Dto.Album
{
    public class AlbumCreateReqeust
    {
        public string AlbumTitle { get; set; }

        //public string Status { get; set; }
        public List<string> Nicknames { get; set; }
        public int? GenreId { get; set; }
        public IFormFile Cover { get; set; }


        //public IFormFileCollection TrackFiles { get; set; }

        //public List<TrackCreateRequest> Tracks { get; set; }
    }
}
