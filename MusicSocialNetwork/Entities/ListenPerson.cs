 using System.ComponentModel.DataAnnotations;
namespace MusicSocialNetwork.Entities;
   

    public class ListenPerson
    {
    public int Id { get; set; }
    public DateTime DateTime { get; set; }
    public Track Track { get; set; }
    public int TrackId { get; set; }
    public Person Person { get; set; }
    public int PersonId { get; set; }
    }

