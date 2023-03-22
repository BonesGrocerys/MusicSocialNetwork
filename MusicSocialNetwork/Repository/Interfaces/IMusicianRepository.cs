using MusicSocialNetwork.Entities;

namespace MusicSocialNetwork.Repository.Interfaces;

public interface IMusicianRepository
{
    public Task<Musician> GetAsync(int id);
    public Task<IEnumerable<Musician>> GetAllAsync();
    public Task<Musician> GetByNicknameAsync(string nickname);
    public Task<int> CreateAsync(Musician musician);
    public Task UpdateAsync(Musician musician);
    public Task DeleteAsync(int id);
    public Task DisagreeApplicationToMusician(int musicianId);

    /// <summary>
    /// Получить музыкантов, ожидающих подтверждение заявки
    /// </summary>
    /// <returns></returns>
    public Task<IEnumerable<Musician>> GetAllWaiting();
    
    /// <summary>
    /// Отправить заявку на музыканта (меняет статус на "В рассмотрении")
    /// </summary>
    /// <param name="musicianId"></param>
    /// <returns></returns>
    public Task SubmitApplicationToMusician(int musicianId);

    /// <summary>
    /// Принять заявку на музыканта (меняет статус на "Одобрена")
    /// </summary>
    /// <param name="musicianId"></param>
    /// <returns></returns>
    public Task ApplyApplicationToMusician(int musicianId);

    /// <summary>
    /// Привязать пользователя к музыканту
    /// </summary>
    /// <param name="musicianId"></param>
    /// <param name="personId"></param>
    /// <returns></returns>
    Task LinkPersonToMusician(int musicianId, int personId);
}

