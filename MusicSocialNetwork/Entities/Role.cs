using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MusicSocialNetwork.Entities
{
    public class Role
    {
        [Key]
        public int Id { get; set; }

        [Column("title")]
        public string Title { get; set; }
    }
}
