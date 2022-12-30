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
        return await _context.Tracks.Include(x => x.Musicians).Where(x => x.PersonAddedTracks.Any(y => y.PersonId == personId)).ToListAsync();
    }

    public async Task<IEnumerable<Track>> GetAllTracksAsync()
    {
        return await _context.Tracks.Include(x => x.Musicians).ToListAsync();
    }

    public async Task<IEnumerable<Track>> GetAllTracksToMusician(int musicianId)
    {
        return await _context.Tracks.Where(x => x.Musicians.Any( x => x.Id == musicianId )).ToListAsync();
        //throw new NotImplementedException();
    }

    public async Task<Track> GetAsync(int id)
    {
        return await _context.Tracks.Include(x => x.Musicians).FirstOrDefaultAsync(x => x.Id == id);

    }

    public async Task<IEnumerable<Track>> GetTrackByMusicanIdAsync(int musicanId)
    {
        return await _context.Tracks.Where(t => t.Musicians.Any(x => x.Id == musicanId)).ToListAsync();
        //throw new NotImplementedException();
    }

    public async Task ListenTrackAsync(int trackId)
    {
        var track = await _context.Tracks.FindAsync(trackId);
        track.AuditionsCount += 1;
        await _context.SaveChangesAsync();
    }

    public Task UpdateAsync(Track track)
    {
        throw new NotImplementedException();
    }

    

}

