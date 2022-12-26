using AutoMapper;
using MusicSocialNetwork.Dto.Auth;
using MusicSocialNetwork.Dto.Person;
using MusicSocialNetwork.Entities;

namespace MusicSocialNetwork.Mapping
{
    public class AuthMapping : Profile
    {
        public AuthMapping()
        {
            CreateMap<RegistrationRequest, Person>();
            CreateMap<Person, PersonResponse>();
        }
    }
}
