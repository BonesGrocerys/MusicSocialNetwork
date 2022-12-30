using AutoMapper;
using MusicSocialNetwork.Dto.Album;
using MusicSocialNetwork.Dto.Musician;
using MusicSocialNetwork.Dto.Track;
using MusicSocialNetwork.Entities;

namespace MusicSocialNetwork.Mapping
{
    public class TrackMapping : Profile
    {
        public TrackMapping()
        {
            CreateMap<Track, TrackResponse>()
            .ForMember(dest => dest.Url, opt => opt.MapFrom(src => $"http://172.20.10.2:7205/api/Tracks/get-track-file/{src.Id}.mp3"));
            CreateMap<TrackCreateRequest, Track>();
            CreateMap<AlbumCreateReqeust, Album>();
            CreateMap<Musician, MusicianResponse>();
        }
    }
}
