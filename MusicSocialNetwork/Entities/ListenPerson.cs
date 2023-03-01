 using System.ComponentModel.DataAnnotations;
namespace MusicSocialNetwork.Entities;
   

    public class ListenPerson
    {
    public int Id { get; set; }
    public DateTime DateTime { get; set; }
    public Track Track { get; set; }

    public Person Person { get; set; }
    }

