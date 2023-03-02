using Microsoft.EntityFrameworkCore;
using MusicSocialNetwork.Database;
using MusicSocialNetwork.Entities;
using MusicSocialNetwork.Repository.Interfaces;

namespace MusicSocialNetwork.Repository.Implimentations;


public class TrackRepository : ITrackRepository
{
    private readonly ApplicationDbContext _context;

    public TrackRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> CreateAsync(Track track)
    {
        await _context.AddAsync(track);
        await _context.SaveChangesAsync();
        return track.Id;
    }

    public Task DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<Track>> GetAddedTracksPerson(int personId)
    {
        return await _context.Tracks
            .Include(x => x.Musicians)
            .Where(x => x.PersonAddedTracks
            .Any(y => y.PersonId == personId))
            .Include(x => x.Album)
            .ToListAsync();
    }

    public async Task<IEnumerable<Track>> GetAllTracksAsync(string searchText)
    {
       var query = _context.Tracks.Include(x => x.Musicians).Include(x => x.Album).AsQueryable();
        if (searchText != null)
        {
            query = query.Where(x => x.Title.ToLower().Contains(searchText.ToLower()) ||
                x.Musicians.Any( y => y.Nickname.ToLower().Contains(searchText.ToLower())));
        }

        return await query.ToListAsync();
    }

    public async Task<IEnumerable<Track>> GetAllTracksToMusician(int musicianId)
    {
        return await _context.Tracks
            .Where(x => x.Musicians
            .Any(x => x.Id == musicianId))
            .Include(x => x.Album)
            .Include(x => x.Musicians)
            .ToListAsync();
        
    }

    public async Task<Track> GetAsync(int id)
    {
        return await _context.Tracks.Include(x => x.Musicians).FirstOrDefaultAsync(x => x.Id == id);

    }

    public async Task<IEnumerable<Track>> GetRandomTrackAsync()
    {
        var end = _context.Tracks.Max(x => x.Id);
        var rnd = new Random();
        var dice = rnd.Next(1, end+1);
        var randomTrack = await _context.Tracks.Where(x => x.Id == dice).Include(x => x.Album).Include(x => x.Musicians).ToListAsync();
        while (randomTrack == null)
        {
            dice = rnd.Next(1, end + 1);
            randomTrack = await _context.Tracks.Where(x => x.Id == dice).Include(x => x.Album).Include(x => x.Musicians).ToListAsync();
        }
        
        return randomTrack;
    }

    public async Task<IEnumerable<Track>> GetTrackByMusicanIdAsync(int musicanId)
    {
        return await _context.Tracks
            .Where(t => t.Musicians
            .Any(x => x.Id == musicanId))
            //.Include(x => x.ListenPerson.Count(x => x.TrackId == 1 ))
            .Include(x => x.Album)
            .Include(x => x.Musicians)
            .ToListAsync();
        
        
    }

    public async Task<IEnumerable<Track>> GetTrackGenreAsync(int genreId)
    {
        return await _context.Tracks
            .Where(e => e.Album.GenreId == genreId)
            .Include(x => x.Album)
            .Include(x => x.Musicians)
            .ToListAsync();
    }

    public async Task ListenTrackAsync(ListenPerson listenPerson)
    {
        
        await _context.AddAsync(listenPerson);
        await _context.SaveChangesAsync();
        return;
    }


    public Task UpdateAsync(Track track)
    {
        throw new NotImplementedException();
    }



}