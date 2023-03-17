using Microsoft.EntityFrameworkCore;
using MusicSocialNetwork.Database;
using MusicSocialNetwork.Entities;
using MusicSocialNetwork.Repository.Interfaces;

namespace MusicSocialNetwork.Repository.Implimentations
{
    public class PlaylistRepository : IPlaylistRepository
    {

        private ApplicationDbContext _context;

        public PlaylistRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddTrackToPlaylist(PlaylistTrack playlistTrack)
        {
            await _context.AddAsync(playlistTrack);
            await _context.SaveChangesAsync();
        }

        public async Task<int> CreateAsync(Playlist playlist)
        {
            await _context.AddAsync(playlist);
            await _context.SaveChangesAsync();
            return playlist.Id;
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Playlist>> GetPlaylistsByPersonAsync(int personId)
        {
            return await _context.Playlists.Where(x => x.PersonId == personId)
                .Include(x => x.Person).ToListAsync();


        }

        public async Task<IEnumerable<Track>> GetTracksByPlaylistId(int playlistId)
        {
            return await _context.Tracks.Where(x => x.PlaylistAddedTracks.Any(x => x.playlistId == playlistId))
                .Include(x => x.Musicians)
                .Include(x => x.Album)
                .ToListAsync();
        }

        public Task UpdateAsync(Playlist playlist)
        {
            throw new NotImplementedException();
        }
    }
}
