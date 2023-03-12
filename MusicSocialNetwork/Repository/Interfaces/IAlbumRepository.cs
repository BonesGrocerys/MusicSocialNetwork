using MusicSocialNetwork.Entities;

namespace MusicSocialNetwork.Repository.Interfaces;

    public interface IAlbumRepository
    {
    public Task<int> CreateAsync(Album album);
    public Task UpdateAsync(Album album);
    public Task DeleteAsync(int id);

    public Task<IEnumerable<Album>> GetAllAlbumByMusicianIdAsync(int musicianId);
    public Task<IEnumerable<Album>> GetAllAlbumAsync(string searchText);
    public Task<IEnumerable<Album>> GetLastAlbumByMusicianId(int musicianId);
    public Task<byte[]> GetCoverFromLastAlbumByMusicianId(int musicianId);

    
}

