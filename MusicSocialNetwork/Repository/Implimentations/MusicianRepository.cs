using Microsoft.EntityFrameworkCore;
using MusicSocialNetwork.Database;
using MusicSocialNetwork.Entities;
using MusicSocialNetwork.Models;
using MusicSocialNetwork.Repository.Interfaces;

namespace MusicSocialNetwork.Repository.Implimentations;

public class MusicianRepository : IMusicianRepository
{
    private ApplicationDbContext _context;
    public MusicianRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> CreateAsync(Musician musician)
    {
        await _context.AddAsync(musician);
        await _context.SaveChangesAsync();
        return musician.Id;
    }

    public async Task DeleteAsync(int id)
    {
        var musician = await _context.Musicians.FindAsync(id);
        if (musician != null)
        {
             _context.Musicians.Remove(musician);
        }
    }

    public async Task<Musician?> GetAsync(int id)
    {
        return await _context.Musicians.FindAsync(id);
    }

    public async Task<IEnumerable<Musician>> GetAllAsync(string SearchText)
    {
        var query = _context.Musicians.AsQueryable();
        if (SearchText != null)
        {
            query = query.Where(x => x.Nickname.ToLower().Contains(SearchText.ToLower()));
        }

        return await query.ToListAsync();
    }

    public async Task<Musician?> GetByNicknameAsync(string nickname)
    {
        return await _context.Musicians.FirstOrDefaultAsync(x => x.Nickname == nickname);
    }

    /// <inheritdoc/>
    public async Task LinkPersonToMusician(int musicianId, int personId)
    {
        var musician = await GetAsync(musicianId);
        musician.PersonId = personId;
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Musician musician)
    {
        var  updatedMusician = await _context.Musicians.FindAsync(musician.Id);
        if (updatedMusician is not null)
        {
            updatedMusician.Email = musician.Email;
        }
        await _context.SaveChangesAsync();
    }

    /// <inheritdoc/>
    public async Task SubmitApplicationToMusician(int musicianId)
    {
        var musician = await GetAsync(musicianId);
        musician.Status = MusicianStatus.WAITING;
        await _context.SaveChangesAsync();
    }

    /// <inheritdoc/>
    public async Task ApplyApplicationToMusician(int musicianId)
    {
        var musician = await GetAsync(musicianId);
        musician.Status = MusicianStatus.AGREED;
        await _context.SaveChangesAsync();
    }

    /// <inheritdoc/>
    public async Task DisagreeApplicationToMusician(int musicianId)
    {
        var musician = await GetAsync(musicianId);
        musician.Status = null;
        await _context.SaveChangesAsync();
    }

    /// <inheritdoc/>
    public async Task<IEnumerable<Musician>> GetAllWaiting()
    {
        return await _context.Musicians.Where(x => x.Status == MusicianStatus.WAITING).ToListAsync();
    }

    public async Task SubscribeToMusician(Subscriptions subscriptions)
    {
        await _context.AddAsync(subscriptions);
        await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<Musician>> GetSubscribedMusician(int personId)
    {
        return await _context.Musicians.Include(x => x.Subscribers.Where(x => x.PersonId== personId)).ToListAsync();
    }
}

