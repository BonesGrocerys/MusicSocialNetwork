using System.ComponentModel.DataAnnotations;

namespace MusicSocialNetwork.Entities;

    public class MusicianTracks
    {
    [Key]
    public int Id { get; set; }
    public int MusicianId { get; set; }
    public Musician Musician { get; set; }
    public int TrackId { get; set; }
    public Track Track { get; set; }
}

