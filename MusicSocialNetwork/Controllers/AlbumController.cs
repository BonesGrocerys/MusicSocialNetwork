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
            if (response.Success) 
            return Ok(response);

            return BadRequest(response);
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

        [HttpPost("add-album-to-person")]
        public async Task<IActionResult> AddAlbumToPerson(int albumId, int personId)
        {
            var response = await _albumService.AddAlbumToPerson(albumId, personId);
            return Ok(response);
        }

        [HttpGet("get-all-added-albums-by-personId")]
        public async Task<IActionResult> GetAllAddedAlbumsToPersonId(int personId)
        {
            var response = await _albumService.GetAllAddedAlbumsByPersonId(personId);
            if (response.Success)
                return Ok(response);
            return BadRequest(response);
        }

        [HttpDelete("delete-album-from-person")]
        public async Task<ActionResult<OperatingSystem>> DeleteAlbumFromPerson(int albumId, int personId)
        {
            var result = await _albumService.DeleteAddedAlbumFromPerson(albumId, personId);
            if (result.Success)
                return Ok(result);

            return BadRequest(result);
        }

        [HttpPut("publish-album")]
        public async Task<IActionResult> PublishAlbum(int albumId)
        {
            var response = await _albumService.PublishAlbum(albumId);
            return Ok(response);
        }

        [HttpGet("get-no-published-albums")]
        public async Task<IActionResult> GetAllNoPublishedAlbumsByMusician(int musicianId)
        {
            var response = await _albumService.GetNoPublishedAlbumsByMusician(musicianId);
            if (response.Success)
                return Ok(response);
            return BadRequest(response);
        }

        [HttpDelete("delete-album")]
        public async Task<ActionResult<OperatingSystem>> DeleteAlbum(int albumId)
        {
            var result = await _albumService.DeleteAlbum(albumId);
            if (result.Success)
                return Ok(result);

            return BadRequest(result);
        }

        [HttpGet("AlbumIsAdded")]
        public async Task<IActionResult> AlbumIdAdded(int albumId, int personId)
        {
            var response = await _albumService.AlbumIsAdded(albumId, personId);

            return Ok(response);
        }
    }
}
