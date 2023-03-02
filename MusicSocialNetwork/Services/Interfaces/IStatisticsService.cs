using MusicSocialNetwork.Common;
using MusicSocialNetwork.Dto.Graph;

namespace MusicSocialNetwork.Services.Interfaces;

    public interface IStatisticsService
    {
       public Task<OperationResult<IEnumerable<GraphResponse>>> GetGraphDataByMusicianAsync(int MusicianId);

    }

