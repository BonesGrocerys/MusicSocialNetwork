using MusicSocialNetwork.Common;
using MusicSocialNetwork.Dto.Graph;
using MusicSocialNetwork.Dto.SavesResponse;
using MusicSocialNetwork.Entities;

namespace MusicSocialNetwork.Repository.Interfaces
{
    public interface IStatisticsRepository
    {
        public Task<int> GetAuditionsTrackCountAsync(int id);
        public Task<IEnumerable<Track>> GetPopularTracksAsync();
        public Task<IEnumerable<GraphResponse>> GetGraphDataByMusicianListenCountAsync(int musicianId, DayInterval interval);
        public Task<IEnumerable<GraphResponse>> GetGraphDataByMusicianListenersCountAsync(int musicianId, DayInterval interval);
        public Task<CountResponse> GetSavesCountTrackByMusician(int musicianId, int trackId);
    }
}
