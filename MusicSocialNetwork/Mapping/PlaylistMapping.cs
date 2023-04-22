using AutoMapper;
using MusicSocialNetwork.Dto.Playlist;
using MusicSocialNetwork.Entities;

namespace MusicSocialNetwork.Mapping;

public class PlaylistMapping : Profile
{
    public PlaylistMapping()
    {

        CreateMap<Playlist, PlaylistResponse>()
            .ForMember(dest => dest.Creator, opt => opt.MapFrom(src => src.Person.Name))
            .ForMember(dest => dest.CreatorId, opt => opt.MapFrom(src => src.Person.Id));
        CreateMap<CreatePlaylistRequest, Playlist>().ForMember(x => x.PlaylistImage, opt => opt.Ignore()); ;
      

    }
}

