using System.ComponentModel.DataAnnotations;

namespace MusicSocialNetwork.Entities;

    public class PlaylistTrack
    {
    [Key]
    public int Id { get; set; }
    public int playlistId { get; set; }
    public Playlist playlist { get; set; }
    public int trackId { get; set; }
    public Track track { get; set; }
}

