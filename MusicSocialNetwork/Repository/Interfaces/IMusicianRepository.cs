using MusicSocialNetwork.Entities;

namespace MusicSocialNetwork.Repository.Interfaces;

public interface IMusicianRepository
{

    public Task<Musician> GetAsync(int id);
    public Task<Musician> GetByNicknameAsync(string nickname);
    public Task<int> CreateAsync(Musician musician);
    public Task UpdateAsync(Musician musician);
    public Task DeleteAsync(int id);
    public Task GiveAccess(Musician musician);
    public Task<int> GetSubscribersCountAsync(int MusicianId);
}

