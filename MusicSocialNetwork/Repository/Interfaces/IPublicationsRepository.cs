using MusicSocialNetwork.Entities;

namespace MusicSocialNetwork.Repository.Interfaces;

public interface IPublicationsRepository
{
    public Task<IEnumerable<Publications>> GetByMusicanIdAsync(int musicanId);
    public Task<Publications> GetAsync(int id);
    public Task<int> CreateAsync(Publications publication);
    public Task UpdateAsync(Publications publication);
    public Task DeleteAsync(int id);

}

