using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MusicSocialNetwork.Entities;

public class Person
{
    [Key]
    public int Id { get; set; }
    [Column("Login")]
    public string Login { get; set; }
    [Column("Password")]
    public string Password { get; set; }
    [Column("Status")]
    //public string Status { get; set; }

    public List<Musician> Musicians { get; set; }
    public List<AddedTracks> MyTracks { get; set; }
    public List<Subscriptions> SubscribeMusician { get; set; }
    public List<AddedPlaylists> MyPlaylists { get; set; }
    public List<Album> AddedAlbums { get; set; }
}

