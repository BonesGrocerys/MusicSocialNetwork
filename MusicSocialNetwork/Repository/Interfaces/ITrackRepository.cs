using MusicSocialNetwork.Entities;

namespace MusicSocialNetwork.Repository.Interfaces;

public interface ITrackRepository
{
    public Task<IEnumerable<Track>> GetTrackByMusicanIdAsync(int musicanId);
    public Task<Track> GetAsync(int id);
    public Task<int> CreateAsync(Track track);
    public Task UpdateAsync(Track track);
    public Task DeleteAsync(int id);
    public Task ListenTrackAsync(int trackId);
    public Task<IEnumerable<Track>> GetAllTracksAsync();
    public Task<IEnumerable<Track>> GetAddedTracksPerson(int personId);
    public Task<IEnumerable<Track>> GetAllTracksToMusician(int musicianId);
}

