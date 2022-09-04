using MusicSocialNetwork.Entities;
using Microsoft.EntityFrameworkCore;

namespace MusicSocialNetwork.Database
{
    public class ApplicationDbContext : DbContext
    {     
        public DbSet<Musician> Musicians { get; set; }
        public DbSet<Publications> Publications { get; set; }
        public DbSet<Track> Tracks { get; set; }
   


        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }



    }
}
