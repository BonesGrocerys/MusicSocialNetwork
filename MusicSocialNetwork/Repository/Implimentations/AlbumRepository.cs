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
        album.Status =  "waiting";
        await _context.AddAsync(album);
        await _context.SaveChangesAsync();
        return album.Id;
    }

    public async Task DeleteAsync(int id)
    {
        var album = await _context.Albums.Where(x => x.Id == id).ToListAsync();
        if (album != null)
        {
            _context.RemoveRange(album);
        }
        await _context.SaveChangesAsync();
    }


    public async Task<IEnumerable<Album>> GetAllAlbumByMusicianIdAsync(int musicianId)
    {
        return await _context.Albums.Where(x => x.Status == "success")
            .Where( x => x.Musicians.Any(x => x.Id == musicianId))
            .Include(x => x.Musicians)
            .Include(x => x.Genre)
            .Include(x => x.Tracks)
            .Include(x => x.Musicians)
                //.ThenInclude( y => y.Musicians)
            .ToListAsync();
    }

    public async Task<IEnumerable<Album>> GetAllAlbumAsync(string searchText)
    {
        var query = _context.Albums.Where(x => x.Status == "success")
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

    public async Task<IEnumerable<Album>> GetLastAlbumByMusicianId(int musicianId)
    {
        return await _context.Albums.Where(x => x.Status == "success")
        .Where(x => x.Musicians.Any(x => x.Id == musicianId))
        .Include(x => x.Musicians)
        .Include(x => x.Genre)
        .Include(x => x.Tracks)
            .ThenInclude(y => y.Musicians)
        .OrderByDescending(x => x.ReleaseDate) // Сортировка по дате релиза
        .Take(1)
        .ToListAsync();
    }

    public async Task<byte[]> GetCoverFromLastAlbumByMusicianId(int musicianId)
    {
        var LastCover = await _context.Albums.Where(x => x.Status == "success")
        .Where(x => x.Musicians.Any(x => x.Id == musicianId))
        .Include(x => x.Musicians)
        .Include(x => x.Genre)
        .Include(x => x.Tracks)
            .ThenInclude(y => y.Musicians)
        .OrderByDescending(x => x.ReleaseDate)
        .FirstOrDefaultAsync();

        return LastCover?.Cover;
    }

    public async Task<IEnumerable<Track>> GetTracksFromAlbumId(int albumId)
    {
        return await _context.Tracks.Where(x => x.AlbumId == albumId)
            .Include(x => x.Musicians).ThenInclude(x => x.Albums)
            .ToListAsync();   
    }

    public async Task AddAlbumToPerson(AddedAlbums addedAlbums)
    {
        await _context.AddAsync(addedAlbums);
        await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<Album>> GetAllAddedAlbumsByPersonId(int personId)
    {
        return await _context.Albums.Where(x => x.AddedAlbums.Any(x => x.PersonId == personId)).Include(x => x.Musicians).ToListAsync();
    }

    public async Task DeleteAddedAlbumFromPerson(int albumId, int personId)
    {
        var album = await _context.AddedAlbums.Where(x => x.AlbumId == albumId && x.PersonId == personId).ToListAsync();
        if (album != null)
        {
            _context.AddedAlbums.RemoveRange(album);
        }
        await _context.SaveChangesAsync();
    }

    public async Task<bool> PublishAlbum(int albumId)
    {
        var album = await _context.Albums.Where(x => x.Id == albumId).FirstOrDefaultAsync();
            if ( album!= null )
        {
            album.Status = "success";
            await _context.SaveChangesAsync();
        }
            return true;
    }

    public async Task<IEnumerable<Album>> GetNoPublishedAlbumsByMusician(int musicianId)
    {
        return await _context.Albums.Where(x => x.Status == "waiting")
            .Where(x => x.Musicians.Any(x => x.Id == musicianId))
            .Include(x => x.Musicians)
            .Include(x => x.Genre)
            .Include(x => x.Tracks)
            .Include(x => x.Musicians)
            //.ThenInclude( y => y.Musicians)
            .ToListAsync();
    }

    public async Task<bool> AlbumIsAdded(int albumId, int personId)
    {
        var album = await _context.AddedAlbums.FirstOrDefaultAsync(x => x.AlbumId == albumId && x.PersonId == personId);
        return album != null;
    }

    public async Task<IEnumerable<Genre>> GetAllGenres()
    {
        return await _context.Genres.ToListAsync();
    }
}

