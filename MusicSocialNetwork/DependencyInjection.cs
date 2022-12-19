using MusicSocialNetwork.Repository.Implimentations;
using MusicSocialNetwork.Repository.Interfaces;
using MusicSocialNetwork.Services.Implementation;
using MusicSocialNetwork.Services.Interfaces;

namespace MusicSocialNetwork
{
    public static class DependencyInjection
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<ITrackService, TrackService>();
        }

        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<ITrackRepository, TrackRepository>();
            services.AddScoped<IAlbumRepository, AlbumRepository>();
            services.AddScoped<IAddedTracksRepository, AddedTracksRepository>();
        }
    }
}
