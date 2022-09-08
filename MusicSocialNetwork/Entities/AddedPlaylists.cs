using System.ComponentModel.DataAnnotations;

namespace MusicSocialNetwork.Entities;

    public class AddedPlaylists
    {
    [Key]
    public int Id { get; set; }
    public int PersonId { get; set; }
    public Person Person { get; set; }
    public int PlaylistsId { get; set; }
    public Playlists Playlists { get; set; } 
    }

