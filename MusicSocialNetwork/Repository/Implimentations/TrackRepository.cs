


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

    public Task<int> CreateAsync(Track track)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<Track> GetAsync(int id)
    {
        return await _context.Tracks.FindAsync(id);
    }

    public async Task<IEnumerable<Track>> GetByMusicanIdAsync(int musicanId)
    {
        //return await _context.Tracks.Where(t => t.MusicianId == musicanId).ToListAsync();
        throw new NotImplementedException();
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

