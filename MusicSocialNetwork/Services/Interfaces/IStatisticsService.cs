using MusicSocialNetwork.Common;
using MusicSocialNetwork.Dto.Graph;
using MusicSocialNetwork.Dto.SavesResponse;
using MusicSocialNetwork.Dto.Track;
using MusicSocialNetwork.Entities;

namespace MusicSocialNetwork.Services.Interfaces;

    public interface IStatisticsService
    {
       public Task<OperationResult<IEnumerable<GraphResponse>>> GetGraphDataByMusicianListenCountAsync(int musicianId, DayInterval interval);
       public Task<OperationResult<IEnumerable<GraphResponse>>> GetGraphDataByMusicianListenersCountAsync(int musicianId, DayInterval interval);
       public Task<OperationResult<CountResponse>> GetSavesCountTrackByMusician(int trackId);
       public Task<OperationResult<CountResponse>> GetSavesCountAllTracksByMusician(int musicianId);
       public Task<OperationResult<IEnumerable<TrackResponse>>> GetPopularTracksAsync();
       public Task<OperationResult<IEnumerable<TrackResponse>>> GetPopularTracksByGenreAsync(int genreId);
       public Task<OperationResult<int>> GetAllAuditionsCountByMusicianId(int musicianId);
}

