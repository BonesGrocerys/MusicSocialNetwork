﻿using Microsoft.EntityFrameworkCore;
using MusicSocialNetwork.Database;
using MusicSocialNetwork.Entities;
using MusicSocialNetwork.Repository.Interfaces;

namespace MusicSocialNetwork.Repository.Implimentations;

public class AlbumRepository : IAlbumRepository
{
    private ApplicationDbContext _context;
        
        public AlbumRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> CreateAsync(Album album)
    {
        await _context.AddAsync(album);
        await _context.SaveChangesAsync();
        return album.Id;
    }

    public Task DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<Album>> GetAlbumByMusicianIdAsync(int musicianId)
    {
        return await _context.Albums.Where(x => x.Musicians.Any(x => x.Id == musicianId )).ToListAsync();
        //throw new NotImplementedException();
    }

    public Task UpdateAsync(Album album)
    {
        throw new NotImplementedException();
    }
}

