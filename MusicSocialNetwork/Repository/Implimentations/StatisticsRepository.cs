using Microsoft.EntityFrameworkCore;
using MusicSocialNetwork.Common;
using MusicSocialNetwork.Database;
using MusicSocialNetwork.Dto.Graph;
using MusicSocialNetwork.Dto.SavesResponse;
using MusicSocialNetwork.Entities;
using MusicSocialNetwork.Repository.Interfaces;

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

        public async Task<IEnumerable<Track>> GetPopularTracksAsync()
        {
            //return await _context.
            throw new NotImplementedException();
        }

        public async Task<CountResponse> GetSavesCountTrackByMusician(int musicianId, int trackId)
        {

            return await _context.AddedTracks.Where(x => x.Track.Musicians
            .Any(x => x.Id == musicianId && x.Tracks
            .Any(x => x.Id == trackId)))
                .GroupBy(x => x.PersonId == x.PersonId)
                .Select(x => new CountResponse { Count = x.Count() }).FirstOrDefaultAsync();
                
            

            //.Select(x => new GraphResponse { DateTime = DateTime.UtcNow, AuditionsCountOfDay = x.Count() })



        }
    }
}
