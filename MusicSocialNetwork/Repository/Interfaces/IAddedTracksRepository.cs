using MusicSocialNetwork.Entities;

namespace MusicSocialNetwork.Repository.Interfaces;

public interface IAddedTracksRepository
    {
    public Task AddTracksAsync(AddedTracks addedTracks);
    
    public Task DeleteTrackAsync(int personId, int trackId);

    Task<bool> TrackIdAdded(int personId, int trackId);
    }

