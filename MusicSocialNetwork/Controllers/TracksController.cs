﻿using Microsoft.AspNetCore.Authorization;
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
    private readonly ITrackRepository _trackRepository;
    public TracksController(ITrackService trackService, IStatisticsService statisticsService, IPlaylistService playlistService, IMusicianService musicianService, IPersonRepository personRepository, ITrackRepository trackRepository)
    {
        _trackService = trackService;
        _statisticsService = statisticsService;
        _playlistService = playlistService;
        _musicianService = musicianService;
        _personRepository = personRepository;
        _trackRepository = trackRepository;
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

   

    [HttpGet("trackIsAdded")]
    public async Task<IActionResult> TrackIdAdded(int trackId, int personId)
    {
        var response = await _trackService.TrackIsAdded(trackId, personId);

        return Ok(response);
    }

    [HttpDelete("delete-track")]
    public async Task<ActionResult<OperatingSystem>> DeleteTrack(int trackId)
    {
        var result = await _trackService.DeleteTrack(trackId);
        if (result.Success)
            return Ok(result);

        return BadRequest(result);
    }
}

