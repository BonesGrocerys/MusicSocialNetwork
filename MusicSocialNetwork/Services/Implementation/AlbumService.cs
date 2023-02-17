﻿using AutoMapper;
using MusicSocialNetwork.Common;
using MusicSocialNetwork.Dto.Album;
using MusicSocialNetwork.Entities;
using MusicSocialNetwork.Repository.Interfaces;
using MusicSocialNetwork.Services.Interfaces;

namespace MusicSocialNetwork.Services.Implementation
{
    public class AlbumService: IAlbumService
    {

        private readonly ITrackRepository _trackRepository;

        private readonly IAlbumRepository _albumRepository;
        private readonly IAddedTracksRepository _addedTracksRepository;
        private readonly IMusicianRepository _musicianRepository;

        private readonly IMapper _mapper;

        public AlbumService(ITrackRepository trackRepository, IMapper mapper, IAlbumRepository albumRepository, IAddedTracksRepository addedTracksRepository, IMusicianRepository musicianRepository)
        {
            _trackRepository = trackRepository;
            _mapper = mapper;
            _albumRepository = albumRepository;
            _addedTracksRepository = addedTracksRepository;
            _musicianRepository = musicianRepository;
        }

        public async Task<OperationResult> CreateAlbumAsync(AlbumCreateReqeust request)
        {
            var album = _mapper.Map<Album>(request);
            List<Musician> musicians = new List<Musician>();
            foreach (var author in request.Nicknames)
            {
                var musician = await _musicianRepository.GetByNicknameAsync(author);
                if (musician != null)
                {
                    musicians.Add(musician);
                }
                else
                {
                    musicians.Add(new Musician
                    {
                        Nickname = author,
                    });
                }

            }
            album.Musicians = musicians;
            await _albumRepository.CreateAsync(album);
            return new OperationResult(OperationCode.Ok, $"Альбом успешно создан");
        }

        public async Task<OperationResult<IEnumerable<AlbumResponse>>> GetAllAlbums(string SearchText)
        {
            var album = await _albumRepository.GetAllAlbumAsync(SearchText);
            var response = _mapper.Map<IEnumerable<AlbumResponse>>(album);
            return new OperationResult<IEnumerable<AlbumResponse>>(response);
        }

        public async Task<OperationResult<IEnumerable<AlbumResponse>>> GetAllAlbumsToMusician(int musicianId)
        {
            var album = await _albumRepository.GetAllAlbumByMusicianIdAsync(musicianId);
            var response = _mapper.Map<IEnumerable<AlbumResponse>>(album);
            return new OperationResult<IEnumerable<AlbumResponse>>(response);
        }
    }
}