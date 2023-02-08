using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MusicSocialNetwork.Dto.Album;
using MusicSocialNetwork.Dto.Track;
using MusicSocialNetwork.Entities;
using MusicSocialNetwork.Services.Interfaces;

namespace MusicSocialNetwork.Controllers;

//[Authorize(AuthenticationSchemes = "Bearer")]
[Route("api/[controller]")]
[ApiController]
public class TracksController : ControllerBase
{
    private readonly ITrackService _trackService;

    public TracksController(ITrackService trackService)
    {
        _trackService = trackService;
    }

    [HttpGet("get-by-id/{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var response = await _trackService.GetById(id);
        if (response.Success)
            return Ok(response);

        return BadRequest(response);
    }

    [HttpPost("create-track")]
    public async Task<IActionResult> Create([FromForm]TrackCreateRequest request)
    {
        var response = await _trackService.CreateAsync(request);
        return Ok(response);
    }

    [HttpPost("create-album")]
    public async Task<IActionResult> CreateAlbum(AlbumCreateReqeust request)
    {

        var response =  await _trackService.CreateAlbumAsync(request);
        return Ok(response);
    }

    [HttpPost("create-track-file")]
    public async Task<IActionResult> CreateTracks([FromForm]AlbumCreateReqeust request)
    {

        await _trackService.CreateTrackFile(request);
        var test = Request;
        return Ok();
    }

    [HttpGet("get-track-file/{id}.mp3")]
    public async Task<IActionResult> GetTrackFile(int id)
    {
        var resp = await _trackService.GetTrackFileAsync(id);

        return File(resp, "audio/mpeg", $"{id}.mp3", true);
    }

    [HttpGet("get-tracks")]
    public async Task<IActionResult> GetTracks(string searchText)
    {
        var resp = await _trackService.GetTracks(searchText);

        return Ok(resp);
    }

    [HttpGet("add-track-to-peson")]
    public async Task<IActionResult> AddTrackToPerson(int personId, int trackId)
    {
        
        var response = await _trackService.AddTrackToPerson(personId, trackId);
        if (response.Success)
            return Ok(response);

        return BadRequest(response);
    }

    [HttpGet("get-all-added-tracks-person/{personId}")]
    public async Task<IActionResult> GetAllAddedTracksPerson(int personId)
    {
        
        var response = await _trackService.GetAllAddedTracksToPerson(personId);
        if (response.Success)
            return Ok(response);


        return BadRequest(response);
    }

    [HttpDelete("delete")]
    public async Task<ActionResult<OperatingSystem>> DeleteAddedTrackToPerson(int personId, int trackId)
    {
        var result = await _trackService.DeleteAddedTrackToPerson(personId ,trackId );
        if (result.Success)
            return Ok(result);

        return BadRequest(result);
    }

    [HttpGet("get-all-tracks-to-musician/{musicianId}")]
    public async Task<IActionResult> GetAllTracksToMusician(int musicianId)
    {
        var response = await _trackService.GetAllTracksToMusician(musicianId);
        if (response.Success)
            return Ok(response);


        return BadRequest(response);
    }
}



