namespace MusicSocialNetwork.Repository.Interfaces;
using MusicSocialNetwork.Entities;
public interface IPlaylistRepository
    {
    public Task<int> CreateAsync(Playlist playlist);
    public Task DeletePlaylistAsync(int id);
    public Task DeleteTrackFromPlaylistAsync(int playlistId, int trackId);
    public Task<IEnumerable<Playlist>> GetPlaylistsByPersonAsync(int personId);
    public Task AddTrackToPlaylist(PlaylistTrack playlistTrack);
    public Task<IEnumerable<Track>> GetTracksByPlaylistId(int playlistId);
    public Task AddPlaylistToPerson(AddedPlaylists addedPlaylists);
    public Task<IEnumerable<Playlist>> GetAllAddedPlaylistsByPersonAsync(int personId);
    public Task DeleteAddedPlaylistFromPerson(int playlistId, int personId);
    public Task<bool> UpdatePlaylistName(Playlist playlist);
    public Task<bool> UpdatePlaylistImage(Playlist playlist);
    public Task<bool> PlaylistBelongsToUser(int playlistId, int personId);
    public Task<IEnumerable<Playlist>> GetAllPlaylistAsync(string searchText);
}

