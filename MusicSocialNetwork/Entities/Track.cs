using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MusicSocialNetwork.Entities;

public class Track
{
    [Key]
    public int Id { get; set; }
    [Column("title")]
    public string Title { get; set; }
    [Column("auditions_count")]
    public int AuditionsCount { get; set; }
    public int MusicianId { get; set; }
    public Musician Musician { get; set; }
}

