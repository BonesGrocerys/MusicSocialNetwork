using MusicSocialNetwork.Entities;
using Microsoft.EntityFrameworkCore;

namespace MusicSocialNetwork.Database
{
    public class ApplicationDbContext : DbContext
    {     
        public DbSet<Person> Persons { get; set; }
        public DbSet<Musician> Musicians { get; set; }
        public DbSet<Publications> Publications { get; set; }
        public DbSet<Track> Tracks { get; set; }
        public DbSet<Subscriptions> Subscriptions { get; set; }
        public DbSet<Playlists> Playlists { get; set; }
        public DbSet<AddedPlaylists> AddedPlaylists { get; set; }
        public DbSet<Genre> Genre { get; set; }
        public DbSet<Album> Album { get; set; }
   


        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }



    }
}
