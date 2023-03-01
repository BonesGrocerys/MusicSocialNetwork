using Microsoft.AspNetCore.Mvc;
using MusicSocialNetwork.Common;
using MusicSocialNetwork.Dto.Album;
using MusicSocialNetwork.Dto.Track;

namespace MusicSocialNetwork.Services.Interfaces
{
    public interface ITrackService
    {
        Task<OperationResult<TrackResponse>> GetById(int id);

        Task<OperationResult> CreateAsync(TrackCreateRequest request);

        Task<OperationResult> CreateAlbumAsync(AlbumCreateReqeust request);

        //Task CreateTrackFile(AlbumCreateReqeust file);

        Task<Stream> GetTrackFileAsync(int id);

        Task<OperationResult<IEnumerable<TrackResponse>>> GetTracks(string searchText);

        Task<OperationResult> AddTrackToPerson(int personId, int trackId);

        Task<OperationResult<IEnumerable<TrackResponse>>> GetAllAddedTracksToPerson(int personId);
        Task<OperationResult> DeleteAddedTrackToPerson(int personId, int trackId);

        Task<OperationResult<IEnumerable<TrackResponse>>> GetAllTracksToMusician(int musicianId);
        Task<OperationResult<IEnumerable<TrackResponse>>> GetRandomTrackAsync();
        //Task<OperationResult> ListenTrackAsync(int trackId);
        Task<OperationResult<IEnumerable<TrackResponse>>> GetTrackGenreAsync(int genreId);
    }
}
