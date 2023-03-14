using AutoMapper;
using MusicSocialNetwork.Common;
using MusicSocialNetwork.Dto.Musician;
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
    }
}
