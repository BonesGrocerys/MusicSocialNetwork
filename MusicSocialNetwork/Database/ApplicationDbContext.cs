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

        public DbSet<Genre> Genres { get; set; }

        public DbSet<Album> Albums { get; set; }

        public DbSet<AddedTracks> AddedTracks { get; set; }

        public DbSet<Role> Roles { get; set; }

        //public DbSet<MusicianAlbum> MusicianAlbum { get; set; }
        //public DbSet<MusicianTracks> MusicianTracks { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>().HasData(new Role[]
            {
                new Role
                {
                    Id= 1,
                    Title = "User"
                },
                new Role
                {
                    Id= 2,
                    Title = "Admin"
                },
            });
        }
    }
}
