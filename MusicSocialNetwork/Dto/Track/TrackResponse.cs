using MusicSocialNetwork.Dto.Musician;

namespace MusicSocialNetwork.Dto.Track
{
    public class TrackResponse
    {
        public int Id { get; set; }

        //public string Author { get; set; }

        public string Title { get; set; }

        public int AuditionsCount { get; set; }

        public string Url { get; set; }

        public List<MusicianResponse> Musicians { get; set; }
        public int GenreId { get; set; }
        public Byte[] Cover { get; set; }

        
        // возвращать на клиент
    }
}
