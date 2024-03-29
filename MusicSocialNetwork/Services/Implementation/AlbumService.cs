﻿using AutoMapper;
using MusicSocialNetwork.Common;
using MusicSocialNetwork.Database;
using MusicSocialNetwork.Dto.Album;
using MusicSocialNetwork.Dto.Genre;
using MusicSocialNetwork.Dto.Track;
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
        private readonly IStatisticsRepository _statisticsRepository;
        private readonly IMapper _mapper;

        public AlbumService(ITrackRepository trackRepository, IMapper mapper, IAlbumRepository albumRepository, IAddedTracksRepository addedTracksRepository, IMusicianRepository musicianRepository, IStatisticsRepository statisticsRepository)
        {
            _trackRepository = trackRepository;
            _mapper = mapper;
            _albumRepository = albumRepository;
            _addedTracksRepository = addedTracksRepository;
            _musicianRepository = musicianRepository;
            _statisticsRepository = statisticsRepository;
        }

        public async Task<OperationResult> AddAlbumToPerson(int albumId, int personId)
        {
            var addAlbum = new AddedAlbums { AlbumId = albumId, PersonId = personId };
            await _albumRepository.AddAlbumToPerson(addAlbum);
            return new OperationResult(OperationCode.Ok, $"Альбом добавлен");
        }

        public async Task<OperationResult<bool>> AlbumIsAdded(int albumId, int personId)
        {
            var album = await _albumRepository.AlbumIsAdded(albumId, personId);
            return new OperationResult<bool>(album);
        }

        public async Task<OperationResult<int>> CreateAlbumAsync(AlbumCreateReqeust request)
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
            if ( request.Cover != null ) {
                using (var memoryStream = new MemoryStream())
                {
                    request.Cover.CopyTo(memoryStream);
                    var data = memoryStream.ToArray();
                    album.Cover = data;
                } 
            }
            //else return new OperationResult(OperationCode.Error, $"Необходимо загрузить обложку");

            album.Musicians = musicians;
            var albumId = await _albumRepository.CreateAsync(album);
            return new OperationResult<int>(albumId);
        }

        public async Task<OperationResult> DeleteAddedAlbumFromPerson(int albumId, int personId)
        {
            await _albumRepository.DeleteAddedAlbumFromPerson(albumId, personId);
            return OperationResult.OK;
        }

        public async Task<OperationResult> DeleteAlbum(int albumId)
        {
            await _albumRepository.DeleteAsync(albumId);
            return OperationResult.OK;
        }

        public async Task<OperationResult<IEnumerable<AlbumResponse>>> GetAllAddedAlbumsByPersonId(int personId)
        {
            var album = await _albumRepository.GetAllAddedAlbumsByPersonId(personId);
            var response = _mapper.Map<IEnumerable<AlbumResponse>>(album);
            return new OperationResult<IEnumerable<AlbumResponse>>(response);
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
          
            foreach ( var albumResponse in response )
            {
                foreach ( var item in albumResponse.Tracks)
                {
                    item.AuditionsCount = await _statisticsRepository.GetAuditionsTrackCountAsync(item.Id);
                    item.SavesCount = await _statisticsRepository.GetSavesCountTrackByMusicianForAlbum(item.Id);
                }
                albumResponse.SavesCount = albumResponse.Tracks.Sum(x => x.SavesCount);
                albumResponse.AuditionsCount = albumResponse.Tracks.Sum(x => x.AuditionsCount);
            }
            return new OperationResult<IEnumerable<AlbumResponse>>(response);
        }

        public async Task<OperationResult<IEnumerable<GenreResponse>>> GetAllGenres()
        {
            var genres = await _albumRepository.GetAllGenres();
            var response = _mapper.Map<IEnumerable<GenreResponse>>(genres);
            return new OperationResult<IEnumerable<GenreResponse>>(response);
        }

        public async Task<OperationResult<IEnumerable<AlbumResponse>>> GetLastAlbumByMusicianId(int musicianId)
        {
            var album = await _albumRepository.GetLastAlbumByMusicianId(musicianId);
            var response = _mapper.Map<IEnumerable<AlbumResponse>>(album);
            return new OperationResult<IEnumerable<AlbumResponse>>(response);
        }

        public async Task<OperationResult<IEnumerable<AlbumResponse>>> GetNoPublishedAlbumsByMusician(int musicianId)
        {
            var album = await _albumRepository.GetNoPublishedAlbumsByMusician(musicianId);
            var response = _mapper.Map<IEnumerable<AlbumResponse>>(album);
            return new OperationResult<IEnumerable<AlbumResponse>>(response);
        }

        public async Task<OperationResult<IEnumerable<TrackResponse>>> GetTracksFromAlbumId(int albumId)
        {
            var tracks = await _albumRepository.GetTracksFromAlbumId(albumId);
            var response = _mapper.Map<IEnumerable<TrackResponse>>(tracks);
            return new OperationResult<IEnumerable<TrackResponse>>(response);
        }

        public async Task<OperationResult> PublishAlbum(int albumId)
        {
            var tracks = await _albumRepository.GetTracksFromAlbumId(albumId);
            if (!tracks.Any())
            {
                return new OperationResult(OperationCode.Error, $"Необходимо добавить треки к альбому");
            }
            await _albumRepository.PublishAlbum(albumId);
            return new OperationResult(OperationCode.Ok, $"Альбом успешно опубликован"); ;
        }
    }
}
