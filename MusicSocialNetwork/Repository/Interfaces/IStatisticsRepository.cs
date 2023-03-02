using MusicSocialNetwork.Dto.Graph;
using MusicSocialNetwork.Entities;

namespace MusicSocialNetwork.Repository.Interfaces
{
    public interface IStatisticsRepository
    {
        public Task<int> GetAuditionsTrackCountAsync(int id);
        public Task<IEnumerable<Track>> GetPopularTracksAsync();
        public Task<IEnumerable<GraphResponse>> GetGraphDataByMusicianAsync(int MusicianId);
    }
}
