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
        private readonly IAddedTracksRepository _addedTracksRepository;
        private readonly IMusicianRepository _musicianRepository;
        private readonly IStatisticsRepository _statisticsRepository;
        private readonly IMapper _mapper;

        public TrackService(ITrackRepository trackRepository, IMapper mapper, IAlbumRepository albumRepository, IAddedTracksRepository addedTracksRepository, IMusicianRepository musicianRepository, IStatisticsRepository statisticsRepository)
        {
            _trackRepository = trackRepository;
            _mapper = mapper;
            _albumRepository = albumRepository;
            _addedTracksRepository = addedTracksRepository;
            _musicianRepository = musicianRepository;
            _statisticsRepository = statisticsRepository;   
        }

        public async Task<OperationResult> CreateAsync(TrackCreateRequest request)
        {
            var track = _mapper.Map<Track>(request);
            List<Musician> musicians = new List<Musician>();
            foreach (var author in request.Nicknames)
            {
                var musician = await _musicianRepository.GetByNicknameAsync(author);
                if (musician != null)
                {
                     musicians.Add(musician);
                } else
                {
                    musicians.Add(new Musician
                    {
                        Nickname = author,
                    });
                }

            }
            track.AlbumId = request.AlbumId;
            track.Musicians = musicians;
            //await _trackRepository.CreateAsync(track);
            var tracksFiles = request.TrackFiles;
            var createdId = await _trackRepository.CreateAsync(track);

            var stream = tracksFiles.OpenReadStream();
            using var fileStream = File.Create($"C:\\Users\\shpackyous\\Desktop\\Tracks\\{createdId}.mp3");
            stream.Seek(0, SeekOrigin.Begin);
            stream.CopyTo(fileStream);

            return new OperationResult(OperationCode.Ok, $"Трек успешно создан");
        }

        public async Task<OperationResult<TrackResponse>> GetById(int id)
        {
            var track = await _trackRepository.GetAsync(id);
            var response = _mapper.Map<TrackResponse>(track);

            if (response == null) 
                return OperationResult<TrackResponse>.Fail(OperationCode.EntityWasNotFound, "Трек не найден");

            return new OperationResult<TrackResponse>(response);
        }
        // Перенести в отдельный сервис
        public async Task<OperationResult> CreateAlbumAsync(AlbumCreateReqeust request)
        {
            var album = _mapper.Map<Album>(request);
            await _albumRepository.CreateAsync(album);
            return new OperationResult(OperationCode.Ok, "Альбом успешно создан");
        }
        //
        //public async Task CreateTrackFile(AlbumCreateReqeust request)
        //{
        //    var tracksDtoList = request.Tracks;
        //    var tracksFiles = request.TrackFiles;

        //    for(int i = 0; i < request.Tracks.Count; i++)
        //    {
        //        var track = _mapper.Map<Track>(tracksDtoList[i]);
        //        var createdId = await _trackRepository.CreateAsync(track);

        //        var stream = tracksFiles[i].OpenReadStream();
        //        using var fileStream = File.Create($"C:\\Users\\shpackyous\\Desktop\\{createdId}.m4a");
        //        stream.Seek(0, SeekOrigin.Begin);
        //        stream.CopyTo(fileStream);
        //    }
        //}



        public async  Task<Stream> GetTrackFileAsync(int id)
        {
            var path = $"C:\\Users\\shpackyous\\Desktop\\Tracks\\{id}.mp3";
            var stream = File.OpenRead(path);
            return stream;
        }

        public async Task<OperationResult<IEnumerable<TrackResponse>>> GetTracks(string searchText)
        {
            var tracks = await _trackRepository.GetAllTracksAsync(searchText);
            var response = _mapper.Map<IEnumerable<TrackResponse>>(tracks);
            return new OperationResult<IEnumerable<TrackResponse>>(response);
        }

         public async Task<OperationResult> AddTrackToPerson(int personId, int trackId)
        {
            var track = new AddedTracks { PersonId = personId, TrackId = trackId };
            await _addedTracksRepository.AddTracksAsync(track);
            return OperationResult.OK;
        }

        public async Task<OperationResult<IEnumerable<TrackResponse>>> GetAllAddedTracksToPerson(int personId)
        {
            var tracks = await _trackRepository.GetAddedTracksPerson(personId);
            if (tracks == null || !tracks.Any())
            {
                return OperationResult<IEnumerable<TrackResponse>>.Fail(OperationCode.EntityWasNotFound, "Не найдено ни одного трека");
            }
           
            var response = _mapper.Map<IEnumerable<TrackResponse>>(tracks);
            return new OperationResult<IEnumerable<TrackResponse>>(response);
        }

        public async Task<OperationResult> DeleteAddedTrackToPerson(int personId, int trackId)
        {
            await _addedTracksRepository.DeleteTrackAsync(personId,trackId);
            return OperationResult.OK;  
        }

        public async Task<OperationResult<IEnumerable<TrackResponse>>> GetAllTracksToMusician(int musicianId)
        {
            var tracks = await _trackRepository.GetAllTracksToMusician(musicianId);
            var response = _mapper.Map<IEnumerable<TrackResponse>>(tracks);
            foreach (var item in response) {

                    item.AuditionsCount = await _statisticsRepository.GetAuditionsTrackCountAsync(item.Id);
                    var saves = await _statisticsRepository.GetSavesCountTrackByMusician(item.Id); 
                    item.SavesCount = saves.Count;
            }

            return new OperationResult<IEnumerable<TrackResponse>>(response);
        }

        public async Task<OperationResult<IEnumerable<TrackResponse>>> GetRandomTrackAsync()
        {
            var tracks = await _trackRepository.GetRandomTrackAsync();

            var response = _mapper.Map < IEnumerable<TrackResponse>>(tracks);
            return new OperationResult<IEnumerable<TrackResponse>>(response);
        }

        public async Task<OperationResult> ListenTrackAsync(int trackId, int personId)
        {
            var listenPerson = new ListenPerson { TrackId = trackId, PersonId = personId, DateTime = DateTime.UtcNow.Date };
            await _trackRepository.ListenTrackAsync(listenPerson);
            return OperationResult.OK;
        }

        public async Task<OperationResult<IEnumerable<TrackResponse>>> GetTrackGenreAsync(int genreId)
        {
            var tracks = await _trackRepository.GetTrackGenreAsync(genreId);  
            var response = _mapper.Map<IEnumerable<TrackResponse>>(tracks); 
            return new OperationResult<IEnumerable<TrackResponse>>(response);
        }

        public async Task<OperationResult<bool>> TrackIsAdded(int trackId, int personId)
        {
            var track = await _trackRepository.TrackIsAdded(trackId, personId);
            return new OperationResult<bool>(track);
        }
    }
}
