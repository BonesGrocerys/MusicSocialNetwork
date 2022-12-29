using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MusicSocialNetwork.Entities;

    public class AddedTracks
    {
    [Key]
    public int Id { get; set; }
    //[Column("datetime")]
    //public DateTime DateTime { get; set; }
    public int PersonId { get; set; }
    public Person Person { get; set; }
    public int TrackId { get; set; }
    public Track Track { get; set; }
    }

