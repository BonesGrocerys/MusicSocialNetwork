using AutoMapper;
using MusicSocialNetwork.Common;
using MusicSocialNetwork.Dto.Playlist;
using MusicSocialNetwork.Dto.Track;
using MusicSocialNetwork.Entities;
using MusicSocialNetwork.Repository.Interfaces;
using MusicSocialNetwork.Services.Interfaces;

namespace MusicSocialNetwork.Services.Implementation;

public class PlaylistService : IPlaylistService
{
    private readonly IMapper _mapper;
    private readonly IPlaylistRepository _playlistRepository;

    public PlaylistService(IPlaylistRepository playlistRepository, IMapper mapper )
    { 
        _playlistRepository = playlistRepository;
        _mapper = mapper;
       
    }
    public async Task<OperationResult> CreateAsync(CreatePlaylistRequest request)
    {
        if ( request.Name == null)
        {
            return new OperationResult(OperationCode.Error, $"Необходимо указать имя плейлиста");
        }
        var playlist = _mapper.Map<Playlist>(request);
        playlist.PersonId = request.PersonId;
        await _playlistRepository.CreateAsync(playlist);

        

        return new OperationResult(OperationCode.Ok, $"Плейлист успешно создан");
    }

    public async Task<OperationResult<IEnumerable<PlaylistResponse>>> GetPlaylistsByPersonAsync(int personId)
    {
        var playlist = await _playlistRepository.GetPlaylistsByPersonAsync(personId);
        if ( playlist == null || !playlist.Any())
        {
            return OperationResult<IEnumerable<PlaylistResponse>>.Fail(OperationCode.EntityWasNotFound, "Не найдено ни одного плейлиста");
        }
        var response = _mapper.Map<IEnumerable<PlaylistResponse>>(playlist);
        return new OperationResult<IEnumerable<PlaylistResponse>>(response);
    }
}

