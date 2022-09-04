using MusicSocialNetwork.Entities;

namespace MusicSocialNetwork.Repository.Interfaces;

public interface ITrackRepository
{
    public Task<IEnumerable<Track>> GetByMusicanIdAsync(int musicanId);
    public Task<Track> GetAsync(int id);
    public Task<int> CreateAsync(Track track);
    public Task UpdateAsync(Track track);
    public Task DeleteAsync(int id);
    public Task ListenTrackAsync(int trackId);
}

