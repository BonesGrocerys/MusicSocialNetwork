﻿using MusicSocialNetwork.Common;
using MusicSocialNetwork.Dto.Album;
using MusicSocialNetwork.Dto.Track;

namespace MusicSocialNetwork.Services.Interfaces
{
    public interface IAlbumService
    {
       Task<OperationResult> CreateAlbumAsync(AlbumCreateReqeust request);
       Task<OperationResult<IEnumerable<AlbumResponse>>> GetAllAlbumsToMusician(int musicianId);
       Task<OperationResult<IEnumerable<AlbumResponse>>> GetAllAlbums(string SearchText);
    }
}