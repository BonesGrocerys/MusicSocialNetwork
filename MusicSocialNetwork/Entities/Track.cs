using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MusicSocialNetwork.Entities;

public class Track
{
    [Key]
    public int Id { get; set; }
    [Column("author")]
    public string Author { get; set; }
    [Column("title")]
    public string Title { get; set; }
    [Column("auditions_count")]
    public int AuditionsCount { get; set; }
   
    public int AlbumId { get; set; }
    public Album Album { get; set; }
    
    public List<AddedTracks> PersonAddedTracks { get; set; }
    public List<PlaylistTrack> PlaylistAddedTracks { get; set; }
    public List<Musician> Musicians { get; set; }
    public Genre? Genre { get; set; }
    public int? GenreId { get; set; }

}

