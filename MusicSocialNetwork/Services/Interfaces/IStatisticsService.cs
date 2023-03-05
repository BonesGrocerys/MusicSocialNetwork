using MusicSocialNetwork.Common;
using MusicSocialNetwork.Dto.Graph;

namespace MusicSocialNetwork.Services.Interfaces;

    public interface IStatisticsService
    {
       public Task<OperationResult<IEnumerable<GraphResponse>>> GetGraphDataByMusicianListenCountAsync(int musicianId, DayInterval interval);
       public Task<OperationResult<IEnumerable<GraphResponse>>> GetGraphDataByMusicianListenersCountAsync(int musicianId, DayInterval interval);
    
    }

