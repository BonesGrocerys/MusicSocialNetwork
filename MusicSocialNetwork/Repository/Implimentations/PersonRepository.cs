using MusicSocialNetwork.Database;
using MusicSocialNetwork.Entities;
using MusicSocialNetwork.Repository.Interfaces;

namespace MusicSocialNetwork.Repository.Implimentations;

public class PersonRepository : IPersonRepository
{
    private ApplicationDbContext _context;
    public PersonRepository(ApplicationDbContext context)
    {
        _context = context;
    }

   

    public async Task<int> CreateAsync(Person person)
    {
        await _context.AddAsync(person);
        await _context.SaveChangesAsync();
        return person.Id;
    }

    public Task DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<Musician> GetAllMusicianAsync()
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(Person person)
    {
        throw new NotImplementedException();
    }
}



