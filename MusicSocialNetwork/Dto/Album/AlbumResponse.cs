using MusicSocialNetwork.Dto.Track;

namespace MusicSocialNetwork.Dto.Album;

    public class AlbumResponse
    {
    public int Id { get; set; }

    public string AlbumTitle { get; set; }

    public string Status { get; set; }

    public int AuditionsCount { get; set; }
    public List<TrackResponse> Tracks { get; set; }
}

