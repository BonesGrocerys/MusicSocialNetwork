using System.ComponentModel.DataAnnotations;

namespace MusicSocialNetwork.Entities;

    public class AddedPlaylists
    {
    [Key]
    public int Id { get; set; }
    public int PersonId { get; set; }
    public Person Person { get; set; }
    public int PlaylistId { get; set; }
    public Playlist Playlist { get; set; } 
    }

