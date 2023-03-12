namespace MusicSocialNetwork.Repository.Interfaces;
using MusicSocialNetwork.Entities;
public interface IPlaylistRepository
    {
    public Task<int> CreateAsync(Playlist playlist);
    public Task UpdateAsync(Playlist playlist);
    public Task DeleteAsync(int id);
    public Task<IEnumerable<Playlist>> GetPlaylistsByPersonAsync(int personId);
}

