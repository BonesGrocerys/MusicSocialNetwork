using System.ComponentModel.DataAnnotations;

namespace MusicSocialNetwork.Entities;

public class Playlist
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; }
    
    public List<AddedPlaylists> AddedPlaylists { get; set; }
    public List<PlaylistTrack> TrackAddedPlaylist { get; set; }
}

