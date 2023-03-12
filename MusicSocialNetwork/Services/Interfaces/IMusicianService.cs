using MusicSocialNetwork.Common;
using MusicSocialNetwork.Dto.Musician;

namespace MusicSocialNetwork.Services.Interfaces;

    public interface IMusicianService
    {
     Task<OperationResult<MusicianResponse>> GetMusicianByIdAsync(int musicianId);
}

