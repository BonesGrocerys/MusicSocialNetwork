namespace MusicSocialNetwork.Dto.Playlist;

public class PlaylistUpdateImageRequest
    {
    public int Id { get; set; }
    public IFormFile PlaylistImage { get; set; }
    }

