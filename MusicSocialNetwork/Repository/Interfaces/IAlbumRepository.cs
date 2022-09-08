﻿using MusicSocialNetwork.Entities;

namespace MusicSocialNetwork.Repository.Interfaces;

    public interface IAlbumRepository
    {
    public Task<int> CreateAsync(Album album);
    public Task UpdateAsync(Album album);
    public Task DeleteAsync(int id);

    }

