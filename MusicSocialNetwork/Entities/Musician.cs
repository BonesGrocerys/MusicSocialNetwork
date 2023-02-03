using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MusicSocialNetwork.Entities;


public class Musician
{
    [Key]
    public int Id { get; set; }
    [Column("nickname")]
    public string Nickname { get; set; }
    [Column("email")]
    public string Email { get; set; }
    //public  List<MusicianAlbum> MusicianAlbums { get; set; }

    public  List<Publications> PublicationsList { get; set; }
    public int? PersonId { get; set; }
    public Person? Person { get; set; }

    public List<Subscriptions> Subscribers { get; set; } 
    //public List<MusicianTracks> MusicianTracks { get; set; }
    public List<MusicianAlbum> MusicianAlbum { get; set; }
    public List<Track> Tracks { get; set; }
}

