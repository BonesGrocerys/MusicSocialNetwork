using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MusicSocialNetwork.Entities;

    public class Label
    {
    [Key]
    public int Id { get; set; }
    [Column("Name")]
    public string Name { get; set; }
    public List<Album> Albums { get; set; }
    public List<Person> Persons { get; set; }
}

