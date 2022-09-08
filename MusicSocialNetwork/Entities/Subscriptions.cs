using System.ComponentModel.DataAnnotations;

namespace MusicSocialNetwork.Entities;

public class Subscriptions
{
    [Key]
    public int id { get; set; }
    public int PersonId { get; set; }
    public Person Person { get; set; }

    public int MusicianId { get; set; }
    public Musician Musician { get; set; }

    public DateTime Date { get; set; }
    
}

