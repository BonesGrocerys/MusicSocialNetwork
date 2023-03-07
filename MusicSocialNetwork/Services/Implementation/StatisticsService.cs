﻿using AutoMapper;
using MusicSocialNetwork.Common;
using MusicSocialNetwork.Dto.Graph;
using MusicSocialNetwork.Dto.SavesResponse;
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

        public async Task<OperationResult<CountResponse>> GetSavesCountTrackByMusician(int musicianId, int trackId)
        {
            var graph = await _statisticsRepository.GetSavesCountTrackByMusician(musicianId, trackId);
            return new OperationResult<CountResponse>(graph);
        }  
    }
}
