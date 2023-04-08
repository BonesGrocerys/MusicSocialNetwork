using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MusicSocialNetwork.Common;
using MusicSocialNetwork.Dto.Album;
using MusicSocialNetwork.Dto.Playlist;
using MusicSocialNetwork.Dto.Track;
using MusicSocialNetwork.Entities;
using MusicSocialNetwork.Repository.Interfaces;
using MusicSocialNetwork.Services.Interfaces;

namespace MusicSocialNetwork.Controllers;

//[Authorize(AuthenticationSchemes = "Bearer")]
[Route("api/[controller]")]
[ApiController]
public class TracksController : ControllerBase
{
    private readonly ITrackService _trackService;
    private readonly IStatisticsService _statisticsService;
    private readonly IPlaylistService _playlistService;
    private readonly IMusicianService _musicianService;
    private readonly IPersonRepository _personRepository;
    public TracksController(ITrackService trackService, IStatisticsService statisticsService, IPlaylistService playlistService, IMusicianService musicianService, IPersonRepository personRepository)
    {
        _trackService = trackService;
        _statisticsService = statisticsService;
        _playlistService = playlistService;
        _musicianService = musicianService;
        _personRepository = personRepository;
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
    public async Task<IActionResult> Create([FromForm] TrackCreateRequest request)
    {
        var response = await _trackService.CreateAsync(request);
        return Ok(response);
    }

    //[HttpPost("create-album")]
    //public async Task<IActionResult> CreateAlbum(AlbumCreateReqeust request)
    //{

    //    var response =  await _trackService.CreateAlbumAsync(request);
    //    return Ok(response);
    //}

    //[HttpPost("create-track-file")]
    //public async Task<IActionResult> CreateTracks([FromForm]AlbumCreateReqeust request)
    //{

    //    await _trackService.CreateTrackFile(request);
    //    var test = Request;
    //    return Ok();
    //}

    [HttpGet("get-track-file/{id}.mp3")]
    public async Task<IActionResult> GetTrackFile(int id)
    {
        var resp = await _trackService.GetTrackFileAsync(id);

        return File(resp, "audio/mpeg", $"{id}.mp3", true);
    }

    [HttpGet("get-all-tracks")]
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

    [HttpDelete("delete-track-to-person")]
    public async Task<ActionResult<OperatingSystem>> DeleteAddedTrackToPerson(int personId, int trackId)
    {
        var result = await _trackService.DeleteAddedTrackToPerson(personId, trackId);
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

    [HttpGet("get-random-track")]
    public async Task<IActionResult> GetRandomTrack()
    {
        var response = await _trackService.GetRandomTrackAsync();
        if (response.Success)
            return Ok(response);


        return BadRequest(response);
    }

    [HttpPost("listen-track")]
    public async Task<IActionResult> ListenTrack(int trackId, int personId)
    {
        var response = await _trackService.ListenTrackAsync(trackId, personId);
        if (response.Success)
            return Ok(response);


        return BadRequest(response);
    }

    [HttpGet("get-genre-track/{genreId}")]
    public async Task<IActionResult> GetTrackGenre(int genreId)
    {
        var response = await _trackService.GetTrackGenreAsync(genreId);
        if (response.Success)
            return Ok(response);


        return BadRequest(response);
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

    [HttpGet("get-musician-by-id")]
    public async Task<IActionResult> GetMusicianByIdAsync(int musicianId)
    {
        var response = await _musicianService.GetMusicianByIdAsync(musicianId);
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

    [HttpGet("get-tracks-from-playlistId")]
    public async Task<IActionResult> GetTracksFromPlaylistId(int playlistId)
    {
        var response = await _playlistService.GetTracksFromPlaylistId(playlistId);
        if (response.Success)
            return Ok(response);


        return BadRequest(response);
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
    public async Task<IActionResult> GetAllMusician()
    {
        var response = await _musicianService.GetAllAsync();
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

    [HttpPost("add-playlist-to-person")]
    public async Task<IActionResult> AddPlaylistToPerson(int playlistId, int personId)
    {
        var response = await _playlistService.AddPlaylistToPerson(playlistId, personId);
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

    [HttpDelete("delete-added-playlist-from-person")]
    public async Task<ActionResult<OperatingSystem>> DeleteAddedPlaylistFromPerson(int playlistId, int personId)
    {
        var result = await _playlistService.DeleteAddedPlaylistFromPerson(playlistId, personId);
        if (result.Success)
            return Ok(result);

        return BadRequest(result);
    }
}

