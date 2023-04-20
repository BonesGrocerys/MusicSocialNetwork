using Microsoft.AspNetCore.Mvc;
using MusicSocialNetwork.Dto.Playlist;
using MusicSocialNetwork.Services.Interfaces;

namespace MusicSocialNetwork.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlaylistController : Controller
    {
        private readonly ITrackService _trackService;
        private readonly IStatisticsService _statisticsService;
        private readonly IPlaylistService _playlistService;
        private readonly IMusicianService _musicianService;

        public PlaylistController(ITrackService trackService, IStatisticsService statisticsService, IPlaylistService playlistService, IMusicianService musicianService)
        {
            _trackService = trackService;
            _statisticsService = statisticsService;
            _playlistService = playlistService;
            _musicianService = musicianService;
        }

        [HttpPost("create-playlist")]
        public async Task<IActionResult> CreatePlaylist([FromForm] CreatePlaylistRequest request)
        {
            var response = await _playlistService.CreateAsync(request);
            return Ok(response);
        }

        [HttpGet("get-playlists-by-personId")]
        public async Task<IActionResult> GetPlaylistsByPersonAsync(int personId)
        {
            var response = await _playlistService.GetPlaylistsByPersonAsync(personId);
            if (response.Success)
                return Ok(response);


            return BadRequest(response);
        }

        [HttpGet("get-all-added-playlists-by-personId")]
        public async Task<IActionResult> GetAllAddedPlaylistsByPersonAsync(int personId)
        {
            var response = await _playlistService.GetAllAddedPlaylistsByPersonAsync(personId);
            if (response.Success)
                return Ok(response);


            return BadRequest(response);
        }

        [HttpGet("get-tracks-from-playlistId")]
        public async Task<IActionResult> GetTracksFromPlaylistId(int playlistId)
        {
            var response = await _playlistService.GetTracksFromPlaylistId(playlistId);
            if (response.Success)
                return Ok(response);


            return BadRequest(response);
        }

        [HttpPost("add-track-to-playlist")]
        public async Task<IActionResult> AddTrackToPlaylist(int trackId, int playlistId)
        {
            var response = await _playlistService.AddTrackToPlaylist(trackId, playlistId);
            if (response.Success)
                return Ok(response);

            return BadRequest(response);
        }

        [HttpPost("add-playlist-to-person")]
        public async Task<IActionResult> AddPlaylistToPerson(int playlistId, int personId)
        {
            var response = await _playlistService.AddPlaylistToPerson(playlistId, personId);
            if (response.Success)
                return Ok(response);

            return BadRequest(response);
        }

        [HttpDelete("delete-added-playlist-from-person")]
        public async Task<ActionResult<OperatingSystem>> DeleteAddedPlaylistFromPerson(int playlistId, int personId)
        {
            var result = await _playlistService.DeleteAddedPlaylistFromPerson(playlistId, personId);
            if (result.Success)
                return Ok(result);

            return BadRequest(result);
        }

    }
}
