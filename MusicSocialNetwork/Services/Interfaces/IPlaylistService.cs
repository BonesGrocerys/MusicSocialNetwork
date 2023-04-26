using MusicSocialNetwork.Common;
using MusicSocialNetwork.Dto.Playlist;
using MusicSocialNetwork.Dto.Track;

namespace MusicSocialNetwork.Services.Interfaces;

    public interface IPlaylistService
    {
    Task<OperationResult> CreateAsync(CreatePlaylistRequest request);
    Task<OperationResult<IEnumerable<PlaylistResponse>>> GetPlaylistsByPersonAsync(int personId);
    Task<OperationResult> AddTrackToPlaylist(int trackId, int playlistId);
    Task<OperationResult<IEnumerable<TrackResponse>>> GetTracksFromPlaylistId(int playlistId);
    Task<OperationResult> AddPlaylistToPerson(int playlistId, int personId);
    Task<OperationResult<IEnumerable<PlaylistResponse>>> GetAllAddedPlaylistsByPersonAsync(int personId);
    Task<OperationResult> DeleteAddedPlaylistFromPerson(int playlistId, int personId);
    Task<OperationResult> UpdatePlaylistName(PlaylistUpdateNameRequest playlistDto);
    Task<OperationResult> UpdatePlaylistImage(PlaylistUpdateImageRequest playlistDto);
    Task<OperationResult> DeletePlaylistAsync(int playlistId);
    Task<OperationResult> DeleteTrackFromPlaylistAsync(int playlistId, int trackId);
    Task<OperationResult> PlaylistBelongsToUser(int playlistId, int personId);
}

