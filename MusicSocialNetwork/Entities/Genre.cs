using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MusicSocialNetwork.Entities;

public class Genre
{
    [Key]
    public int Id { get; set; }
    [Column("genre")]
    public string Name { get; set; } 
    public List<Album> Albums { get; set; } = new List<Album>();
    //public List<Track> Tracks { get; set; } = new List<Track>();
    
}

