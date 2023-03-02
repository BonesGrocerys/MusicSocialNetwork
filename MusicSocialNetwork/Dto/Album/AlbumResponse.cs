using MusicSocialNetwork.Dto.Musician;
using MusicSocialNetwork.Dto.Track;

namespace MusicSocialNetwork.Dto.Album;

    public class AlbumResponse
    {
    public int Id { get; set; }

    public string AlbumTitle { get; set; }

    public string Status { get; set; }
    public int? GenreId { get; set; }
    public string GenreTitle { get; set; }

    public int AuditionsCount { get; set; }
    public Byte[] Cover { get; set; }
    public List<MusicianResponse> Musicians { get; set; }
    public List<TrackResponse> Tracks { get; set; }
}

