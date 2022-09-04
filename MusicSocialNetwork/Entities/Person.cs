using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MusicSocialNetwork.Entities;

public class Person
{
    [Key]
    public int Id { get; set; }
    [Column("Login")]
    public string Login { get; set; }
    [Column("Password")]
    public string Password { get; set; }

    public List<Musician> Musicians { get; set; }
}

