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
    [Column("Name")]
    //public string Status { get; set; }
    public string Name { get; set; }
    public Role Role { get; set; }
    public int RoleId { get; set; }
    //public Label? Label { get; set; }
    //public int? LabelId { get; set; }

    public List<Musician> Musicians { get; set; }
    public List<AddedTracks> MyTracks { get; set; }
    public List<Subscriptions> SubscribeMusician { get; set; }
    public List<AddedPlaylists> MyPlaylists { get; set; }
    public List<Album> AddedAlbums { get; set; }
    public List<ListenPerson> ListenPerson { get; set; }
    public List<Playlist> Playlists { get; set; }
}

