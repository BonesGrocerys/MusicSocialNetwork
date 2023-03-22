﻿using MusicSocialNetwork.Common;
using MusicSocialNetwork.Dto.Musician;
using MusicSocialNetwork.Entities;

namespace MusicSocialNetwork.Services.Interfaces;

public interface IMusicianService
{
    Task<OperationResult<MusicianResponse>> GetMusicianByIdAsync(int musicianId);
    Task<OperationResult<IEnumerable<MusicianResponse>>> GetAllAsync();

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
}

