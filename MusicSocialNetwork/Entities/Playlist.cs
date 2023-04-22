using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MusicSocialNetwork.Entities;

public class Playlist
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; }
    
    public List<AddedPlaylists> AddedPlaylists { get; set; }
    public List<PlaylistTrack> TrackAddedPlaylist { get; set; }
    public Person? Person { get; set; }
    public int? PersonId { get; set; }
    public Byte[] PlaylistImage { get; set; }
}

