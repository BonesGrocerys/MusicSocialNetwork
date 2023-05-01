using Microsoft.AspNetCore.Mvc;
using MusicSocialNetwork.Common;
using MusicSocialNetwork.Repository.Interfaces;
using MusicSocialNetwork.Services.Interfaces;

namespace MusicSocialNetwork.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatisticsController : Controller
    {
        private readonly ITrackService _trackService;
        private readonly IStatisticsService _statisticsService;
        private readonly IPlaylistService _playlistService;
        private readonly IMusicianService _musicianService;
        
        public StatisticsController(ITrackService trackService, IStatisticsService statisticsService, IPlaylistService playlistService, IMusicianService musicianService)
        {
            _trackService = trackService;
            _statisticsService = statisticsService;
            _playlistService = playlistService;
            _musicianService = musicianService;
      
        }

        [HttpPost("get-graph-musician-count-listen/{musicianId}")]
        public async Task<IActionResult> GetGraphDataByMusicianListenCountAsync(int musicianId, DayInterval interval)
        {
            var response = await _statisticsService.GetGraphDataByMusicianListenCountAsync(musicianId, interval);
            if (response.Success)
                return Ok(response);


            return BadRequest(response);
        }

        [HttpPost("get-graph-musician-count-listeners/{musicianId}")]
        public async Task<IActionResult> GetGraphDataByMusicianListenersCountAsync(int musicianId, DayInterval interval)
        {
            var response = await _statisticsService.GetGraphDataByMusicianListenersCountAsync(musicianId, interval);
            if (response.Success)
                return Ok(response);


            return BadRequest(response);
        }

        [HttpGet("get-saves-count-track-by-musician")]
        public async Task<IActionResult> GetSavesCountTrackByMusician(int trackId)
        {
            var response = await _statisticsService.GetSavesCountTrackByMusician(trackId);
            if (response.Success)
                return Ok(response);


            return BadRequest(response);
        }

        [HttpGet("get-saves-count-all-tracks-by-musician")]
        public async Task<IActionResult> GetSavesCountAllTracksByMusician(int musicianId)
        {
            var response = await _statisticsService.GetSavesCountAllTracksByMusician(musicianId);
            if (response.Success)
                return Ok(response);


            return BadRequest(response);
        }

        [HttpGet("get-popular-tracks")]
        public async Task<IActionResult> GetPopularTracks()
        {
            var response = await _statisticsService.GetPopularTracksAsync();
            if (response.Success)
                return Ok(response);


            return BadRequest(response);
        }

        [HttpGet("get-popular-tracks-by-genre")]
        public async Task<IActionResult> GetPopularTracksByGenre(int genreId)
        {
            var response = await _statisticsService.GetPopularTracksByGenreAsync(genreId);
            if (response.Success)
                return Ok(response);
            return BadRequest(response);
        }

        [HttpGet("get-all-auditions-count-by-musicianId")]
        public async Task<IActionResult> GetAllAuditionsCountByMusicianId(int musicianId)
        {
            var response = await _statisticsService.GetAllAuditionsCountByMusicianId(musicianId);
            if (response.Success)
                return Ok(response);
            return BadRequest(response);
        }
    }
}
