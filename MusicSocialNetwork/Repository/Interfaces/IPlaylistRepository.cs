﻿namespace MusicSocialNetwork.Repository.Interfaces;
using MusicSocialNetwork.Entities;
public interface IPlaylistRepository
    {
    public Task<int> CreateAsync(Playlist playlist);
    public Task UpdateAsync(Playlist playlist);
    public Task DeleteAsync(int id);
    public Task<IEnumerable<Playlist>> GetPlaylistsByPersonAsync(int personId);
    public Task AddTrackToPlaylist(PlaylistTrack playlistTrack);
    public Task<IEnumerable<Track>> GetTracksByPlaylistId(int playlistId);
    public Task AddPlaylistToPerson(AddedPlaylists addedPlaylists);
    public Task<IEnumerable<Playlist>> GetAllAddedPlaylistsByPersonAsync(int personId);
    public Task DeleteAddedPlaylistFromPerson(int playlistId, int personId);
}

