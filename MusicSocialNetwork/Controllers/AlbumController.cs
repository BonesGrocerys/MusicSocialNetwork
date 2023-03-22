using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MusicSocialNetwork.Dto.Album;
using MusicSocialNetwork.Dto.Track;
using MusicSocialNetwork.Services.Implementation;
using MusicSocialNetwork.Services.Interfaces;

namespace MusicSocialNetwork.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlbumController : ControllerBase
    {

        private readonly ITrackService _trackService;
        private readonly IAlbumService _albumService;

        public AlbumController(ITrackService trackService, IAlbumService albumService)
        {
            _trackService = trackService;
            _albumService = albumService;
        }
        [HttpPost("create-album")]
        public async Task<IActionResult> Create([FromForm]AlbumCreateReqeust request)
        {
            var response = await _albumService.CreateAlbumAsync(request);
            return Ok(response);
        }

        [HttpGet("get-albums-to-musician/{musicianId}")]
        public async Task<IActionResult> GetAllAlbumsToMusician(int musicianId)
        {
            var resp = await _albumService.GetAllAlbumsToMusician(musicianId);

            return Ok(resp);
        }

        [HttpGet("get-all-albums")]
        public async Task<IActionResult> GetAllAlbums(string SearchText)
        {
            var resp = await _albumService.GetAllAlbums(SearchText);

            return Ok(resp);
        }

        [HttpGet("get-last-album-by-musician-id/{musicianId}")]
        public async Task<IActionResult> GetLastAlbumByMusicianId(int musicianId)
        {
            var response = await _albumService.GetLastAlbumByMusicianId(musicianId);
            if (response.Success)
                return Ok(response);


            return BadRequest(response);
        }

        [HttpGet("get-tracks-from-albumId")]
        public async Task<IActionResult> GetTracksFromAlbumId(int albumId)
        {
            var response = await _albumService.GetTracksFromAlbumId(albumId);
            if (response.Success)
                return Ok(response);


            return BadRequest(response);
        }


    }
}
