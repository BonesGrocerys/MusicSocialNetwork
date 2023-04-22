using MusicSocialNetwork.Dto.Person;
using MusicSocialNetwork.Dto.Track;

namespace MusicSocialNetwork.Dto.Playlist
{
    public class PlaylistResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Creator { get; set; }
        public int CreatorId { get; set; }
        public Byte[] PlaylistImage { get; set; }
        public List<TrackResponse> Tracks { get; set; }
    }
}
