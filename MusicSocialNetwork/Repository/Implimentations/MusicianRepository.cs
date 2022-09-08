using MusicSocialNetwork.Database;
using MusicSocialNetwork.Entities;
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

    public async Task<int> GetSubscribersCountAsync(int musicianId)
    {
        //return await _context.Subscriptions.Where(s => s.MusicianId == musicianId ).Count();
        throw new NotImplementedException();
    }

    public async Task UpdateAsync(Musician musician)
    {
        var  updatedMusician = await _context.Musicians.FindAsync(musician.Id);
        if (updatedMusician is not null)
        {
            updatedMusician.Nickname = musician.Nickname;
            updatedMusician.Email = musician.Email;
        }
        await _context.SaveChangesAsync();
    }
}

