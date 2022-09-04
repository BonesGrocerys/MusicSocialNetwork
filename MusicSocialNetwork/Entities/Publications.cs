using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace MusicSocialNetwork.Entities;

public class Publications
{
    [Key]
    public int id { get; set; }
    [Column("PublicationsText")]
    public string PublicationsText { get; set; }
    [Column("PublicationsPhoto")]
    public string PublicationsPhoto { get; set; }
    public int MusicianId { get; set; }
    public Musician Musician { get; set; }

}

