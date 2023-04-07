using Microsoft.EntityFrameworkCore;
using MusicSocialNetwork.Database;
using MusicSocialNetwork.Entities;
using MusicSocialNetwork.Models;
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

    public async Task<Person> GetByLogin(string login)
    {
        return await _context.Persons.FirstOrDefaultAsync(x => x.Login == login);
    }

    public async Task<bool> PersonIsMusician(int personId)
    {
        var person = await _context.Persons.Include(x => x.Musicians).FirstOrDefaultAsync(x => x.Id == personId);
        
        return person.Musicians.Any(x => x.Status == MusicianStatus.AGREED);

    }

    public Task UpdateAsync(Person person)
    {
        throw new NotImplementedException();
    }
}



