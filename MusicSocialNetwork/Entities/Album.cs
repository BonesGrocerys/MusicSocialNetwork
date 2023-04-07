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
    [Column("status")]
    public string Status { get; set; }
    [Column("auditions_count")]
    public int AuditionsCount { get; set; }
    public Genre? Genre { get; set; }
    public int? GenreId { get; set; }
    //public Label? Label { get; set; }
    //public int? LabelId { get; set; }
    public List<Track> Tracks { get; set; }
    public List<AddedAlbums> AddedAlbums { get; set; }
    public List<Musician> Musicians { get; set;}
    [Column("cover")]
    public Byte[] Cover { get; set; }
}

