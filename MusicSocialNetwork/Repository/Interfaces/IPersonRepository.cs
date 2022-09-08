using MusicSocialNetwork.Entities;

namespace MusicSocialNetwork.Repository.Interfaces;

public interface IPersonRepository
{
    public Task<int> CreateAsync(Person person);
    public Task UpdateAsync(Person person);
    public Task DeleteAsync(int id);
    public Task<Track> GetAllTracksAsync();

}

