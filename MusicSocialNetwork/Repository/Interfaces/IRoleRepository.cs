using MusicSocialNetwork.Entities;

namespace MusicSocialNetwork.Repository.Interfaces
{
    public interface IRoleRepository
    {
        Task<IEnumerable<Role>> GetAllAsync();

        Task<Role> GetByIdAsync(int id);
    }
}
