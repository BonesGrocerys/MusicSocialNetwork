using Microsoft.AspNetCore.Mvc;
using MusicSocialNetwork.Repository.Interfaces;

namespace MusicSocialNetwork.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TracksController : ControllerBase
{
    private readonly ITrackRepository _repository;
public TracksController(ITrackRepository repository)
    {
        _repository = repository;
    }

    [HttpGet("Listen/{id}")]
    public async Task<IActionResult> Listen(int id)
    {
       await _repository.ListenTrackAsync(id);
        return Ok("Заебись");
    }
}



