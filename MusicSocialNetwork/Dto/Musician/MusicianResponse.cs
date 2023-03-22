using MusicSocialNetwork.Models;

namespace MusicSocialNetwork.Dto.Musician;

public class MusicianResponse
{
    public int Id { get; set; }
    public string Nickname { get; set; }
    public string Email { get; set; }
    public int? MonthlyListeners { get; set; }
    public Byte[]? MusicianCover { get; set; }
    public MusicianStatus Status { get; set; }
}

