using Microsoft.EntityFrameworkCore;
using MusicSocialNetwork.Common;
using MusicSocialNetwork.Database;
using MusicSocialNetwork.Dto.Graph;
using MusicSocialNetwork.Dto.SavesResponse;
using MusicSocialNetwork.Entities;
using MusicSocialNetwork.Repository.Interfaces;
using System.Runtime.InteropServices;

namespace MusicSocialNetwork.Repository.Implimentations
{
    public class StatisticsRepository : IStatisticsRepository
    {
        private readonly ApplicationDbContext _context;

        public StatisticsRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> GetAuditionsTrackCountAsync(int id)
        {
            return await _context.ListenPerson.CountAsync(x => x.TrackId == id);
        }

        public async Task<IEnumerable<GraphResponse>> GetGraphDataByMusicianListenCountAsync(int musicianId, DayInterval interval)
        {
            
            var groupedData = await _context.ListenPerson.Where(x =>
            x.Track.Musicians.Any(x => x.Id == musicianId))
            .GroupBy(x => x.DateTime)
            .Select(x => new GraphResponse { DateTime = x.Key, AuditionsCountOfDay = x.Count() })
            .ToDictionaryAsync(x => x.DateTime, x => x.AuditionsCountOfDay);

            var result = new List<GraphResponse>();
            var intervalDate = interval.GetDate();
            for (var date = intervalDate.StartDate; date <= intervalDate.EndDate; date = date.AddDays(1))
            {
                var resp = new GraphResponse { DateTime = date };
                if (groupedData.TryGetValue(date, out var count))
                    resp.AuditionsCountOfDay = count;
                else
                    resp.AuditionsCountOfDay = 0;

                result.Add(resp);
            }
            return result;
        }

        public async Task<IEnumerable<GraphResponse>> GetGraphDataByMusicianListenersCountAsync(int musicianId, DayInterval interval)
        {
            var groupedData = await _context.ListenPerson.Where(x =>
            x.Track.Musicians.Any(x => x.Id == musicianId))
            .Select(x => new { x.PersonId, x.DateTime })
            .Distinct()
            .GroupBy(x => x.DateTime)
            .Select(x => new GraphResponse { DateTime = x.Key, AuditionsCountOfDay = x.Count() })
            .ToDictionaryAsync(x => x.DateTime, x => x.AuditionsCountOfDay);

            var result = new List<GraphResponse>();
            var intervalDate = interval.GetDate();
            for (var date = intervalDate.StartDate; date <= intervalDate.EndDate; date = date.AddDays(1))
            {
                var resp = new GraphResponse { DateTime = date };
                if (groupedData.TryGetValue(date, out var count))
                    resp.AuditionsCountOfDay = count;
                else
                    resp.AuditionsCountOfDay = 0;

                result.Add(resp);
            }
            return result;
        }

        public async Task<int> GetMusicianMonthlyListeners(int musicianId)
        {
            var maxDate = DateTime.UtcNow.AddDays(-28);
            return await _context.ListenPerson.Where(x => x.DateTime >= maxDate &&
            x.Track.Musicians
            .Any(x => x.Id == musicianId))
            .Select(x => new { x.PersonId, x.DateTime })
            .Distinct()
            .CountAsync();
        }

        public async Task<IEnumerable<Track>> GetPopularTracksAsync()
        {
            var maxDate = DateTime.UtcNow.AddDays(-8);

            var popularTracks = await _context.ListenPerson
                .Where(lp => lp.DateTime >= maxDate)
                .Include(x => x.Track)
                //.ThenInclude(x => x.Album)
                .ThenInclude(x => x.Musicians)
                .GroupBy(lp => lp.TrackId)
                .OrderByDescending(group => group.Count())
                .Select(group => group.First().Track)               
                .Take(100)
                .ToListAsync();

            return popularTracks;
        }

        public async Task<IEnumerable<Track>> GetPopularTracksByGenreAsync(int genreId)
        {
            var maxDate = DateTime.UtcNow.AddDays(-8);

            var popularTracks = await _context.ListenPerson
                .Where(lp => lp.DateTime >= maxDate && lp.Track.Album.GenreId == genreId)
                //.Where(x => x.Track.Album.GenreId == genreId)
                .Include(x => x.Track)
                //.ThenInclude(x => x.Album)
                .ThenInclude(x => x.Musicians)
                .GroupBy(lp => lp.TrackId)
                .OrderByDescending(group => group.Count())
                .Select(group => group.First().Track)
                .Take(100)
                .ToListAsync();

            return popularTracks;
        }

        public async Task<CountResponse> GetSavesCountAllTracksByMusician(int musicianId)
        {
            var count = await _context.AddedTracks
            .Where(x => x.Track.Musicians.Any(m => m.Id == musicianId))
            .CountAsync();

            return new CountResponse { Count = count };
        }

        public async Task<CountResponse> GetSavesCountTrackByMusician(int trackId)
        {
            var count = await _context.AddedTracks.CountAsync(x => x.TrackId == trackId);
            return new CountResponse { Count = count };
        }
    }
}
