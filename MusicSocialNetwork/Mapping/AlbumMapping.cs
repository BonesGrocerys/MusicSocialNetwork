using AutoMapper;
using MusicSocialNetwork.Dto.Album;
using MusicSocialNetwork.Dto.Musician;
using MusicSocialNetwork.Dto.Track;
using MusicSocialNetwork.Entities;


namespace MusicSocialNetwork.Mapping
{
    public class AlbumMapping : Profile
    {
        public AlbumMapping() 
        {
            CreateMap<Album, AlbumResponse>()
                .ForMember(dest => dest.GenreTitle, opt => opt.MapFrom(src => src.Genre.Name));
                //.ForMember(x => x.Cover, opt => opt.Ignore()); 
        }
    }
}
