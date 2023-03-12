using AutoMapper;
using MusicSocialNetwork.Dto.Playlist;
using MusicSocialNetwork.Entities;

namespace MusicSocialNetwork.Mapping;

    public class PlaylistMapping : Profile
    {
        public PlaylistMapping()
        {
        CreateMap<CreatePlaylistRequest, Playlist>();
        CreateMap<Playlist, PlaylistResponse>()
            .ForMember(dest => dest.Creator, opt => opt.MapFrom(src => src.Person.Name));
    }
    }

