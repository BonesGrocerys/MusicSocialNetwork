﻿using Microsoft.AspNetCore.Mvc;
using MusicSocialNetwork.Common;
using MusicSocialNetwork.Dto.Album;
using MusicSocialNetwork.Dto.Track;

namespace MusicSocialNetwork.Services.Interfaces
{
    public interface ITrackService
    {
        Task<OperationResult<TrackResponse>> GetById(int id);

        Task<OperationResult> CreateAsync(TrackCreateRequest request);

        Task<OperationResult> CreateAlbumAsync(AlbumCreateReqeust request);

        Task CreateTrackFile(AlbumCreateReqeust file);

        Task<Stream> GetTrackFileAsync(int id);

        Task<OperationResult<IEnumerable<TrackResponse>>> GetTracks();
    }
}
