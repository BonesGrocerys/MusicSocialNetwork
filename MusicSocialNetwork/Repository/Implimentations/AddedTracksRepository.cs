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
        await _context.SaveChangesAsync();
    }

    public async Task DeleteTrackAsync(int id)
    {
        var track = await _context.AddedTracks.FindAsync(id);
        if (track != null)
        {
            _context.AddedTracks.Remove(track);
        }
        await _context.SaveChangesAsync();

    }

    
}

