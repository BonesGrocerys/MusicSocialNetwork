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

        public async Task AddPlaylistToPerson(AddedPlaylists addedPlaylists)
        {
            await _context.AddAsync(addedPlaylists);
            await _context.SaveChangesAsync();
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

        public async Task DeleteAddedPlaylistFromPerson(int playlistId, int personId)
        {
            var playlist = await _context.AddedPlaylists.Where(x => x.PlaylistId == playlistId && x.PersonId == personId).ToListAsync();
            if (playlist != null)
            {
                 _context.RemoveRange(playlist);
            }
            await _context.SaveChangesAsync();
        }

        public async Task DeletePlaylistAsync(int id)
        {
            var playlist = await _context.Playlists.Where(x => x.Id == id).ToListAsync();
            if (playlist != null)
            {
                _context.RemoveRange(playlist);
            }
            await _context.SaveChangesAsync();
        }

        public async Task DeleteTrackFromPlaylistAsync(int playlistId, int trackId)
        {
            var playlist = await _context.PlaylistTrack.Where(x => x.playlistId == playlistId && x.trackId == trackId).ToListAsync();
            if (playlist != null)
            {
                _context.RemoveRange(playlist);
            }
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Playlist>> GetAllAddedPlaylistsByPersonAsync(int personId)
        {
            return await _context.Playlists.Where(x => x.AddedPlaylists.Any(x => x.PersonId == personId)).ToListAsync();
        }

        public async Task<IEnumerable<Playlist>> GetPlaylistsByPersonAsync(int personId)
        {
            return await _context.Playlists.Where(x => x.PersonId == personId)
                .Include(x => x.Person).OrderByDescending(x => x.Id).ToListAsync();
        }

        public async Task<IEnumerable<Track>> GetTracksByPlaylistId(int playlistId)
        {
            return await _context.Tracks.Where(x => x.PlaylistAddedTracks.Any(x => x.playlistId == playlistId))
                .Include(x => x.Musicians)
                .Include(x => x.Album)
                .ToListAsync();
        }

        public async Task<bool> PlaylistBelongsToUser(int playlistId, int personId)
        {
            var playlist = await _context.Playlists.FirstOrDefaultAsync(x => x.Id == playlistId && x.PersonId == personId);
            return playlist != null;
        }

        public async Task<bool> UpdatePlaylistImage(Playlist playlist)
        {
            var updatedPlaylist = _context.Playlists.FirstOrDefault(x => x.Id == playlist.Id);
            if (playlist == null)
            {
                return false;
            }
            updatedPlaylist.PlaylistImage = playlist.PlaylistImage;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdatePlaylistName(Playlist playlist)
        {
            var updatedPlaylist =  _context.Playlists.FirstOrDefault(x => x.Id == playlist.Id);
            if (playlist == null)
            {
                return false;
            }
            updatedPlaylist.Name = playlist.Name;
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
