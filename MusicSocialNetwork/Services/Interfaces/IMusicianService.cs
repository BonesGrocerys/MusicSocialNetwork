using MusicSocialNetwork.Common;
using MusicSocialNetwork.Dto.Musician;
using MusicSocialNetwork.Entities;

namespace MusicSocialNetwork.Services.Interfaces;

public interface IMusicianService
{
    Task<OperationResult<MusicianResponse>> GetMusicianByIdAsync(int musicianId);
    Task<OperationResult<IEnumerable<MusicianResponse>>> GetAllAsync(string SearchText);

    /// <summary>
    /// Отправить заявку на музыканта
    /// </summary>
    /// <param name="musicianId"></param>
    /// <returns></returns>
    Task<OperationResult> SubmitApplicationToMusician(int musicianId, int personId);

    /// <summary>
    /// Принять заявку на музыканта
    /// </summary>
    /// <param name="musicianId"></param>
    /// <returns></returns>
    Task<OperationResult> ApplyApplicationToMusician(int musicianId);

    /// <summary>
    /// Получить музыкантов, ожидающих подтверждение заявки
    /// </summary>
    /// <returns></returns>
    Task<OperationResult<IEnumerable<MusicianResponse>>> GetAllWaiting();
    Task<OperationResult> DisagreeApplicationToMusician(int musicianId);
    Task<OperationResult> SubscribeToMusician(int musicianId, int personId);
    Task<OperationResult<IEnumerable<MusicianResponse>>> GetSubscribedMusician(int personId);
    Task<OperationResult> PersonIsSubscribedToMusician(int personId, int musicianId);
    Task<OperationResult<IEnumerable<MusicianResponse>>> GetMusicianByPersonId(int personId);
    Task<OperationResult<bool>> PersonIsMusician(int personId);
    Task<OperationResult> Unsubscribe(int personId, int musicianId);
}

