using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MusicSocialNetwork.Common;
using MusicSocialNetwork.Dto.Album;
using MusicSocialNetwork.Dto.Track;
using MusicSocialNetwork.Entities;
using MusicSocialNetwork.Repository.Interfaces;
using MusicSocialNetwork.Services.Interfaces;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace MusicSocialNetwork.Services.Implementation
{
    public class TrackService : ITrackService
    {
        private readonly ITrackRepository _trackRepository;

        private readonly IAlbumRepository _albumRepository;

        private readonly IMapper _mapper;

        public TrackService(ITrackRepository trackRepository, IMapper mapper, IAlbumRepository albumRepository)
        {
            _trackRepository = trackRepository;
            _mapper = mapper;
            _albumRepository = albumRepository;
        }

        public async Task<OperationResult> CreateAsync(TrackCreateRequest request)
        {
            var track = _mapper.Map<Track>(request);
            await _trackRepository.CreateAsync(track);
            return new OperationResult(OperationCode.Ok, "Трек успешно создан");
        }

        public async Task<OperationResult<TrackResponse>> GetById(int id)
        {
            var track = await _trackRepository.GetAsync(id);
            var response = _mapper.Map<TrackResponse>(track);

            if (response == null) 
                return OperationResult<TrackResponse>.Fail(OperationCode.EntityWasNotFound, "Трек не найден");

            return new OperationResult<TrackResponse>(response);
        }
        public async Task<OperationResult> CreateAlbumAsync(AlbumCreateReqeust request)
        {
            var album = _mapper.Map<Album>(request);
            await _albumRepository.CreateAsync(album);
            return new OperationResult(OperationCode.Ok, "Альбом успешно создан");
        }

        public async Task CreateTrackFile(AlbumCreateReqeust request)
        {
            var tracksDtoList = request.Tracks;
            var tracksFiles = request.TrackFiles;

            for(int i = 0; i < request.Tracks.Count; i++)
            {
                var track = _mapper.Map<Track>(tracksDtoList[i]);
                var createdId = await _trackRepository.CreateAsync(track);

                var stream = tracksFiles[i].OpenReadStream();
                using var fileStream = File.Create($"C:\\Users\\shpackyous\\Desktop\\{createdId}.m4a");
                stream.Seek(0, SeekOrigin.Begin);
                stream.CopyTo(fileStream);
            }
        }

        public async  Task<Stream> GetTrackFileAsync(int id)
        {
            var path = $"C:\\Users\\shpackyous\\Desktop\\{id}.m4a";
            var stream = File.OpenRead(path);
            return stream;
        }

        public async Task<OperationResult<IEnumerable<TrackResponse>>> GetTracks()
        {
            var tracks = await _trackRepository.GetAllTracksAsync();
            var response = _mapper.Map<IEnumerable<TrackResponse>>(tracks);
            return new OperationResult<IEnumerable<TrackResponse>>(response);
        }
    }
}
