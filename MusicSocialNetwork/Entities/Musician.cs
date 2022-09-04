using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MusicSocialNetwork.Entities;


public class Musician
{
    [Key]
    public int Id { get; set; }
    [Column("Musician_name")]
    public string Name { get; set; }
    [Column("Email")]
    public string Email { get; set; }
    public  List<Track> TrackList { get; set; }
    public  List<Publications> PublicationsList { get; set; }
    public int PersonId { get; set; }
    public Person Person { get; set; }

}

