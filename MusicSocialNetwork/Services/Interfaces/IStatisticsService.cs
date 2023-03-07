using MusicSocialNetwork.Common;
using MusicSocialNetwork.Dto.Graph;
using MusicSocialNetwork.Dto.SavesResponse;

namespace MusicSocialNetwork.Services.Interfaces;

    public interface IStatisticsService
    {
       public Task<OperationResult<IEnumerable<GraphResponse>>> GetGraphDataByMusicianListenCountAsync(int musicianId, DayInterval interval);
       public Task<OperationResult<IEnumerable<GraphResponse>>> GetGraphDataByMusicianListenersCountAsync(int musicianId, DayInterval interval);
       public Task<OperationResult<CountResponse>> GetSavesCountTrackByMusician(int trackId);
       public Task<OperationResult<CountResponse>> GetSavesCountAllTracksByMusician(int musicianId);
}

