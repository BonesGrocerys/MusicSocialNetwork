using MusicSocialNetwork.Dto.Person;

namespace MusicSocialNetwork.Dto.Auth
{
    #nullable disable
    public class AuthResponse
    {
        public PersonResponse Person { get; set; }

        public string Token { get; set; }
    }
}
