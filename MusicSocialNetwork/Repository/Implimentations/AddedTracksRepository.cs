using Microsoft.EntityFrameworkCore;
using MusicSocialNetwork.Database;
using MusicSocialNetwork.Entities;
using MusicSocialNetwork.Repository.Interfaces;

namespace MusicSocialNetwork.Repository.Implimentations;

public class AddedTracksRepository : IAddedTracksRepository
{
    private ApplicationDbContext _context;

    public AddedTracksRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task AddTracksAsync(AddedTracks addedTracks)
    {
        await _context.AddAsync(addedTracks);
        //addedTracks.DateTime = DateTime.Now;
        await _context.SaveChangesAsync();
    }

    public async Task DeleteTrackAsync(int personId, int trackId)
    {
        var tracks = await _context.AddedTracks.Where( x => x.PersonId == personId && x.TrackId == trackId).ToListAsync();
        if (tracks != null)
        {
            _context.AddedTracks.RemoveRange(tracks);
        }
        await _context.SaveChangesAsync();

    }

    public async Task<bool> TrackIdAdded(int personId, int trackId)
    {
        return await _context.AddedTracks.FirstOrDefaultAsync(x => x.PersonId == personId && x.TrackId == trackId) != null;
    }
}

