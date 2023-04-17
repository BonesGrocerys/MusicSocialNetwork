using MusicSocialNetwork.Common;
using MusicSocialNetwork.Dto.Album;
using MusicSocialNetwork.Dto.Track;

namespace MusicSocialNetwork.Services.Interfaces
{
    public interface IAlbumService
    {
       Task<OperationResult<int>> CreateAlbumAsync(AlbumCreateReqeust request);
       Task<OperationResult<IEnumerable<AlbumResponse>>> GetAllAlbumsToMusician(int musicianId);
       Task<OperationResult<IEnumerable<AlbumResponse>>> GetAllAlbums(string SearchText);

       Task<OperationResult<IEnumerable<AlbumResponse>>> GetLastAlbumByMusicianId(int musicianId);
       Task<OperationResult<IEnumerable<TrackResponse>>> GetTracksFromAlbumId(int albumId);
       Task<OperationResult> AddAlbumToPerson(int albumId, int personId);
       Task<OperationResult<IEnumerable<AlbumResponse>>> GetAllAddedAlbumsByPersonId(int personId);
       Task<OperationResult> DeleteAddedAlbumFromPerson(int albumId, int personId);

    }
}
