using AutoMapper;
using MusicSocialNetwork.Dto.Album;
using MusicSocialNetwork.Dto.Track;
using MusicSocialNetwork.Entities;

namespace MusicSocialNetwork.Mapping
{
    public class TrackMapping : Profile
    {
        public TrackMapping()
        {
            CreateMap<Track, TrackResponse>();
            CreateMap<TrackCreateRequest, Track>();
            CreateMap<AlbumCreateReqeust, Album>();
        }
    }
}
