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
        return await _context.Tracks.Where(x => x.PersonAddedTracks.Any(y => y.PersonId == personId)).ToListAsync();
    }

    public async Task<IEnumerable<Track>> GetAllTracksAsync()
    {
        return await _context.Tracks.ToListAsync();
    }

    public async Task<Track> GetAsync(int id)
    {
        return await _context.Tracks.FindAsync(id);
    }

    public async Task<IEnumerable<Track>> GetByMusicanIdAsync(int musicanId)
    {
        //return await _context.Tracks.Where(t => t.Musicians == musicanId).ToListAsync();
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

