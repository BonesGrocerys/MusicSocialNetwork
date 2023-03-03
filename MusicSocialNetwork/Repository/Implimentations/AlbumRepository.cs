using Microsoft.EntityFrameworkCore;
using MusicSocialNetwork.Database;
using MusicSocialNetwork.Entities;
using MusicSocialNetwork.Repository.Interfaces;
using System.Runtime.CompilerServices;

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

        album.ReleaseDate = DateOnly.FromDateTime(DateTime.UtcNow);
        await _context.AddAsync(album);
        await _context.SaveChangesAsync();
        return album.Id;
    }

    public Task DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }


    public async Task<IEnumerable<Album>> GetAllAlbumByMusicianIdAsync(int musicianId)
    {
        return await _context.Albums
            .Where(x => x.Musicians.Any(x => x.Id == musicianId))
            .Include(x => x.Musicians)
            .Include(x => x.Genre)
            .Include(x => x.Tracks)
                .ThenInclude( y => y.Musicians)
            .ToListAsync();
            

    }

    public async Task<IEnumerable<Album>> GetAllAlbumAsync(string searchText)
    {
        var query = _context.Albums
            .Include(x => x.Musicians)
            .Include(x => x.Genre)
            .Include(x => x.Tracks)
                .ThenInclude(x => x.Musicians)
            .AsQueryable();
        if (searchText != null)
        {
            query = query.Where(x => x.AlbumTitle.ToLower().Contains(searchText.ToLower()) ||
                x.Musicians.Any(y => y.Nickname.ToLower().Contains(searchText.ToLower())));
        }

        return await query.ToListAsync();
    }

    public Task UpdateAsync(Album album)
    {
        throw new NotImplementedException();
    }
}

