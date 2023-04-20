namespace MusicSocialNetwork.Dto.Playlist;

    public class CreatePlaylistRequest
    {
    public IFormFile PlaylistImage { get; set; }
    public string Name { get; set; }
    public int PersonId { get; set; }
    }

