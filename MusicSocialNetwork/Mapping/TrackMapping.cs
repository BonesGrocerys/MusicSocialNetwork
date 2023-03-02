using AutoMapper;
using MusicSocialNetwork.Dto.Album;
using MusicSocialNetwork.Dto.Musician;
using MusicSocialNetwork.Dto.Track;
using MusicSocialNetwork.Entities;
using System.Net.NetworkInformation;

namespace MusicSocialNetwork.Mapping
{
    public class TrackMapping : Profile
    {
        public TrackMapping()
        {
            CreateMap<Track, TrackResponse>()
            .ForMember(dest => dest.Url, opt => opt.MapFrom(src => $"http://192.168.0.109:7205/api/Tracks/get-track-file/{src.Id}.mp3"))
            .ForMember(dest => dest.GenreId, opt => opt.MapFrom( src => src.Album.GenreId));
            //.ForMember(dest => dest.Cover, opt => opt.MapFrom(src => src.Album.Cover))
            CreateMap<TrackCreateRequest, Track>();
            CreateMap<AlbumCreateReqeust, Album>().ForMember(x => x.Cover, opt => opt.Ignore());
            CreateMap<Musician, MusicianResponse>();
            //CreateMap<Track, TrackInAlbumResponse>();
        }
    }
}
