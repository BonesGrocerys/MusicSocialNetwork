using AutoMapper;
using MusicSocialNetwork.Common;
using MusicSocialNetwork.Dto.Musician;
using MusicSocialNetwork.Entities;
using MusicSocialNetwork.Repository.Interfaces;
using MusicSocialNetwork.Services.Interfaces;

namespace MusicSocialNetwork.Services.Implementation
{
    public class MusicianService : IMusicianService
    {
        private readonly IMapper _mapper;
        private readonly IMusicianRepository _musicianRepository;
        private readonly IAlbumRepository _albumRepository;
        private readonly IStatisticsRepository _statisticsRepository;

        public MusicianService(IMapper mapper, IMusicianRepository musicianRepository, IAlbumRepository albumRepository, IStatisticsRepository statisticsRepository)
        {
            
            _mapper = mapper;
            _musicianRepository = musicianRepository;
            _albumRepository = albumRepository;
            _statisticsRepository = statisticsRepository;

        }


        public async Task<OperationResult<MusicianResponse>> GetMusicianByIdAsync(int musicianId)
        {
            var musician = await _musicianRepository.GetAsync(musicianId);
            var response = _mapper.Map<MusicianResponse>(musician);
            
            response.MusicianCover = await _albumRepository.GetCoverFromLastAlbumByMusicianId(musicianId);
            response.MonthlyListeners = await _statisticsRepository.GetMusicianMonthlyListeners(musicianId);
            
            return new OperationResult<MusicianResponse>(response);
        }

        /// <inheritdoc/>
        public async Task<OperationResult> SubmitApplicationToMusician(int musicianId, int personId)
        {
            await _musicianRepository.SubmitApplicationToMusician(musicianId);
            await _musicianRepository.LinkPersonToMusician(musicianId, personId);
            return OperationResult.OK;
        }

        /// <inheritdoc/>
        public async Task<OperationResult> ApplyApplicationToMusician(int musicianId)
        {
            await _musicianRepository.ApplyApplicationToMusician(musicianId);
            return OperationResult.OK;
        }

        /// <inheritdoc/>
        public async Task<OperationResult<IEnumerable<MusicianResponse>>> GetAllAsync(string SearchText)
        {
            var musicians = await _musicianRepository.GetAllAsync(SearchText);
            var response = _mapper.Map<IEnumerable<MusicianResponse>>(musicians);
            foreach (var musician in response)
            {
                musician.MusicianCover = await _albumRepository.GetCoverFromLastAlbumByMusicianId(musician.Id);
            }
            return new OperationResult<IEnumerable<MusicianResponse>>(response);
        }

        public async Task<OperationResult> DisagreeApplicationToMusician(int musicianId)
        {
            await _musicianRepository.DisagreeApplicationToMusician(musicianId);
            return OperationResult.OK;
        }

        public async Task<OperationResult<IEnumerable<MusicianResponse>>> GetAllWaiting()
        {
            var musicians = await _musicianRepository.GetAllWaiting();
            var response = _mapper.Map<IEnumerable<MusicianResponse>>(musicians);
            foreach (var musician in response)
            {
                musician.MusicianCover = await _albumRepository.GetCoverFromLastAlbumByMusicianId(musician.Id);
            }
            return new OperationResult<IEnumerable<MusicianResponse>>(response);
        }
    }
}
