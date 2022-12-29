using System.ComponentModel.DataAnnotations;

namespace MusicSocialNetwork.Entities;

    public class MusicianAlbum
    {
    [Key]
    public int Id { get; set; }
    public int MusicianId { get; set; }
    public Musician Musician { get; set; }
    public int AlbumId { get; set; }
    public Album Album { get; set; }
    }

