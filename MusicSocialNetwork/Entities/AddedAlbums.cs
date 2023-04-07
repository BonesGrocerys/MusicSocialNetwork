using System.ComponentModel.DataAnnotations;

namespace MusicSocialNetwork.Entities;

    public class AddedAlbums
    {
        [Key]
        public int Id { get; set; }
        public int AlbumId { get; set; }
        public Album Album  { get; set; }
        public int PersonId { get; set; }
        public Person Person  { get; set; }
    }

