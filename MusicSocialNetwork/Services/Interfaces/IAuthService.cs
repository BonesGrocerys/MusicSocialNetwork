using MusicSocialNetwork.Common;
using MusicSocialNetwork.Dto.Auth;
using MusicSocialNetwork.Dto.Person;

namespace MusicSocialNetwork.Services.Interfaces;

public interface IAuthService
{
    Task<OperationResult<AuthResponse>> AuthenticateAsync(AuthRequest request);

    Task<OperationResult<int>> RegistrationAsync(RegistrationRequest request);

    /// <summary>
    /// Проверяет, содержит ли токен необходимый id пользователя
    /// </summary>
    /// <param name="jwt">Токен аутентификации пользователя</param>
    /// <param name="personId">id пользователя</param>
    /// <returns></returns>
    bool IsPersonId(string jwt, int personId);
    Task<OperationResult<PersonResponse>> GetPersonByLogin(string login);
}

