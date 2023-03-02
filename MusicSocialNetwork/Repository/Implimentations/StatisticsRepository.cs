using Microsoft.EntityFrameworkCore;
using MusicSocialNetwork.Database;
using MusicSocialNetwork.Dto.Graph;
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

        public async Task<IEnumerable<GraphResponse>> GetGraphDataByMusicianAsync(int MusicianId)
        {
            var tracks = await _context.Tracks.Where(x => x.Musicians.Any(x => x.Id == MusicianId)).ToListAsync();
            var graphData = new List<GraphResponse>();
            int temp = 0;

            foreach (var track in tracks)
            {
                temp = await _context.ListenPerson.GroupBy()
                //foreach (var Date in await _context.ListenPerson.Where(x => x.DateTime > DateTime.UtcNow.AddDays(-7) && x.DateTime < DateTime.UtcNow).ToListAsync())
                //{
                //temp += await _context.ListenPerson.CountAsync(x => x.TrackId == track.Id);     
                //};
                graphData.Add(new GraphResponse
            {
                AuditionsCountOfDay = temp,
                DateTime = DateTime.UtcNow
            });
            }
            
            return graphData;
        }

        public async Task<IEnumerable<Track>> GetPopularTracksAsync()
        {
            //return await _context.
            throw new NotImplementedException();
        }
    }
}
