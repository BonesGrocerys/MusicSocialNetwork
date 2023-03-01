using Microsoft.EntityFrameworkCore;
using System.IO;

namespace MusicSocialNetwork.Dto.Track
{
    public class TrackCreateRequest
    {
        public string Author { get; set; }

        public string Title { get; set; }
        public List<string> Nicknames { get; set; }
        public int AlbumId { get; set; }
        public IFormFile TrackFiles { get; set; }
        

        // запрос с фронта на бэк-энд
    }
}
