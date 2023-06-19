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
    public Task<IEnumerable<Track>> GetTracksFromAlbumId(int albumId);
    public Task AddAlbumToPerson(AddedAlbums addedAlbums);
    public Task<IEnumerable<Album>> GetAllAddedAlbumsByPersonId(int personId);
    public Task DeleteAddedAlbumFromPerson (int albumId,int personId);
    public Task<bool> PublishAlbum(int albumId);
    public Task<IEnumerable<Album>> GetNoPublishedAlbumsByMusician(int musicianId);
    public Task<bool> AlbumIsAdded(int albumId, int personId);
    public Task<IEnumerable<Genre>> GetAllGenres();
}

