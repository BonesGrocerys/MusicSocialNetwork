using MusicSocialNetwork.Entities;

namespace MusicSocialNetwork.Repository.Interfaces;

public interface IAddedTracksRepository
    {
    public Task AddTracksAsync(AddedTracks addedTracks);
    public Task<IEnumerable<AddedTracks>> GetAllAddedTracksAsync(int personId);
    public Task DeleteTrackAsync(int id);
    }

