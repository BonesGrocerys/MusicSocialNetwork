using Microsoft.AspNetCore.Mvc;
using MusicSocialNetwork.Repository.Interfaces;
using MusicSocialNetwork.Services.Interfaces;

namespace MusicSocialNetwork.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MusicianController : Controller
    {
        private readonly ITrackService _trackService;
        private readonly IStatisticsService _statisticsService;
        private readonly IPlaylistService _playlistService;
        private readonly IMusicianService _musicianService;
        private readonly IPersonRepository _personRepository;
        public MusicianController(ITrackService trackService, IStatisticsService statisticsService, IPlaylistService playlistService, IMusicianService musicianService, IPersonRepository personRepository)
        {
            _trackService = trackService;
            _statisticsService = statisticsService;
            _playlistService = playlistService;
            _musicianService = musicianService;
            _personRepository = personRepository;
        }

        [HttpGet("personIsMusician")]
        public async Task<IActionResult> PersonIsMusician(int personId)
        {
            var response = await _personRepository.PersonIsMusician(personId);

            return Ok(response);
        }

        [HttpGet("submit-application-to-musician")]
        public async Task<IActionResult> SubmitApplicationToMusician(int musicianId, int personId)
        {
            var response = await _musicianService.SubmitApplicationToMusician(musicianId, personId);
            if (response.Success)
                return Ok(response);

            return BadRequest(response);
        }

        [HttpGet("apply-application-to-musician")]
        public async Task<IActionResult> ApplyApplicationToMusician(int musicianId)
        {
            var response = await _musicianService.ApplyApplicationToMusician(musicianId);
            if (response.Success)
                return Ok(response);

            return BadRequest(response);
        }

        [HttpGet("disagree-application-to-musician")]
        public async Task<IActionResult> DisagreeApplicationToMusician(int musicianId)
        {
            var response = await _musicianService.DisagreeApplicationToMusician(musicianId);
            if (response.Success)
                return Ok(response);

            return BadRequest(response);
        }

        [HttpGet("get-all-musician")]
        public async Task<IActionResult> GetAllMusician(string SearchText)
        {
            var response = await _musicianService.GetAllAsync(SearchText);
            if (response.Success)
                return Ok(response);

            return BadRequest(response);
        }
        [HttpGet("get-musician-by-id")]
        public async Task<IActionResult> GetMusicianByIdAsync(int musicianId)
        {
            var response = await _musicianService.GetMusicianByIdAsync(musicianId);
            if (response.Success)
                return Ok(response);


            return BadRequest(response);
        }

        [HttpGet("get-all-waiting-musician")]
        public async Task<IActionResult> GetAllWaitingMusician()
        {
            var response = await _musicianService.GetAllWaiting();
            if (response.Success)
                return Ok(response);

            return BadRequest(response);
        }

        [HttpPost("subscribe-to-musician")]
        public async Task<IActionResult> SubscribeToMusician(int musicianId, int personId)
        {
            var response = await _musicianService.SubscribeToMusician(musicianId, personId);
            if (response.Success)
                return Ok(response);

            return BadRequest(response);
        }

        [HttpGet("get-all-subscribed-musician")]
        public async Task<IActionResult> GetAllSubscribedMusicians(int personId)
        {
            var response = await _musicianService.GetSubscribedMusician(personId);
            if (response.Success)
                return Ok(response);

            return BadRequest(response);
        }
    }
}
