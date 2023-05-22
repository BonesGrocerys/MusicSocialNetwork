using AutoMapper;
using MusicSocialNetwork.Common;
using MusicSocialNetwork.Dto.Graph;
using MusicSocialNetwork.Dto.SavesResponse;
using MusicSocialNetwork.Dto.Track;
using MusicSocialNetwork.Entities;
using MusicSocialNetwork.Repository.Interfaces;
using MusicSocialNetwork.Services.Interfaces;

namespace MusicSocialNetwork.Services.Implementation
{
    public class StatisticsService: IStatisticsService
    {

        private readonly ITrackRepository _trackRepository;

        private readonly IAlbumRepository _albumRepository;
        private readonly IAddedTracksRepository _addedTracksRepository;
        private readonly IMusicianRepository _musicianRepository;
        private readonly IStatisticsRepository _statisticsRepository;
        private readonly IMapper _mapper;

        public StatisticsService(ITrackRepository trackRepository, IMapper mapper, IAlbumRepository albumRepository, IAddedTracksRepository addedTracksRepository, IMusicianRepository musicianRepository, IStatisticsRepository statisticsRepository)
        {
            _trackRepository = trackRepository;
            _mapper = mapper;
            _albumRepository = albumRepository;
            _addedTracksRepository = addedTracksRepository;
            _musicianRepository = musicianRepository;
            _statisticsRepository = statisticsRepository;
        }

        public async Task<OperationResult<int>> GetAllAuditionsCountByMusicianId(int musicianId)
        {
            var count = await _statisticsRepository.GetAllAuditionsCountByMusicianId(musicianId);
            return new OperationResult<int>(count);
        }

        public async Task<OperationResult<IEnumerable<GraphResponse>>> GetGraphDataByMusicianListenCountAsync(int musicianId, DayInterval interval)
        {
            var graph = await _statisticsRepository.GetGraphDataByMusicianListenCountAsync(musicianId, interval);
            return new OperationResult<IEnumerable<GraphResponse>>(graph);
        }

        public async Task<OperationResult<IEnumerable<GraphResponse>>> GetGraphDataByMusicianListenersCountAsync(int musicianId, DayInterval interval)
        {
            var graph = await _statisticsRepository.GetGraphDataByMusicianListenersCountAsync(musicianId, interval);
            return new OperationResult<IEnumerable<GraphResponse>>(graph);
        }

        public async Task<OperationResult<double>> GetMoney(int musicianId, DayInterval interval)
        {
            var count = await _statisticsRepository.GetMoney(musicianId, interval);
            return new OperationResult<double>(count);
        }

        public async Task<OperationResult<IEnumerable<TrackResponse>>> GetPopularTracksAsync()
        {
            var popularTracks = await _statisticsRepository.GetPopularTracksAsync();
            var response = _mapper.Map<IEnumerable<TrackResponse>>(popularTracks);
            foreach (var item in response)
            {

                item.AuditionsCount = await _statisticsRepository.GetAuditionsTrackCountAsync(item.Id);
                var saves = await _statisticsRepository.GetSavesCountTrackByMusician(item.Id);
                item.SavesCount = saves.Count;
            }
            return new OperationResult<IEnumerable<TrackResponse>>(response);
        }

        public async Task<OperationResult<IEnumerable<TrackResponse>>> GetPopularTracksByGenreAsync(int genreId)
        {
            var popularTracks = await _statisticsRepository.GetPopularTracksByGenreAsync(genreId);
            var response = _mapper.Map<IEnumerable<TrackResponse>>(popularTracks);
            foreach (var item in response)
            {

                item.AuditionsCount = await _statisticsRepository.GetAuditionsTrackCountAsync(item.Id);
                var saves = await _statisticsRepository.GetSavesCountTrackByMusician(item.Id);
                item.SavesCount = saves.Count;
            }
            return new OperationResult<IEnumerable<TrackResponse>>(response);
        }

        public async Task<OperationResult<CountResponse>> GetSavesCountAllTracksByMusician(int musicianId)
        {
            var graph = await _statisticsRepository.GetSavesCountAllTracksByMusician(musicianId);
            
            return new OperationResult<CountResponse>(graph);
        }

        public async Task<OperationResult<CountResponse>> GetSavesCountTrackByMusician(int trackId)
        {
            var graph = await _statisticsRepository.GetSavesCountTrackByMusician(trackId);
            //var response = _mapper.Map<CountResponse>(graph);
            return new OperationResult<CountResponse>(graph);
        }

        public async Task<OperationResult<int>> GetTotalListenCountByMusicianAsync(int musicianId, DayInterval dayInterval)
        {
            var count = await _statisticsRepository.GetTotalListenCountByMusicianAsync(musicianId, dayInterval);
            return new OperationResult<int>(count);
        }

        public async Task<OperationResult<int>> GetTotalListenersCountByMusicianAsync(int musicianId, DayInterval dayInterval)
        {
            var count = await _statisticsRepository.GetTotalListenersCountByMusicianAsync(musicianId, dayInterval);
            return new OperationResult<int>(count);
        }
    }
}
