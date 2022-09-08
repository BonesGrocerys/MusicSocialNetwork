using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MusicSocialNetwork.Entities;

public class Album
{
    [Key]
    public int Id { get; set; }
    [Column("album_title")]
    public string AlbumTitle { get; set; }

    [Column("release_date")]
    public DateOnly ReleaseDate { get; set; }
    [Column("Status")]
    public string Status { get; set; }
    public List<Genre> Genres { get; set; }
    public List<Track> Tracks { get; set; }
    public List<Musician> Musicians { get; set; }
    public List<Person> Persons { get; set; }
    

}

