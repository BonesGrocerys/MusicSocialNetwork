﻿using MusicSocialNetwork.Common;
using MusicSocialNetwork.Dto.Playlist;
using MusicSocialNetwork.Dto.Track;

namespace MusicSocialNetwork.Services.Interfaces;

    public interface IPlaylistService
    {
    Task<OperationResult> CreateAsync(CreatePlaylistRequest request);
    Task<OperationResult<IEnumerable<PlaylistResponse>>> GetPlaylistsByPersonAsync(int personId);
    Task<OperationResult> AddTrackToPlaylist(int trackId, int playlistId);
    Task<OperationResult<IEnumerable<TrackResponse>>> GetTracksFromPlaylistId(int playlistId);


}
