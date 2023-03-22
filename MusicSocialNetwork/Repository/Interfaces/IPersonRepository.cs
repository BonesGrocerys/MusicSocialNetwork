using MusicSocialNetwork.Entities;

namespace MusicSocialNetwork.Repository.Interfaces;

public interface IPersonRepository
{
    Task<int> CreateAsync(Person person);
    Task UpdateAsync(Person person);
    Task DeleteAsync(int id);
    Task<Musician> GetAllMusicianAsync();

    Task<Person> GetByLogin(string login);

    Task<bool> PersonIsMusician(int personId);
}

