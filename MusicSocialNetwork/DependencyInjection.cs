using MusicSocialNetwork.Repository.Implimentations;
using MusicSocialNetwork.Repository.Interfaces;
using MusicSocialNetwork.Services.Implementation;
using MusicSocialNetwork.Services.Interfaces;

namespace MusicSocialNetwork
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            return  services
                .AddScoped<ITrackService, TrackService>()
                .AddScoped<IAuthService, AuthService>()
                .AddScoped<IAlbumService, AlbumService>()
                .AddScoped<IStatisticsService, StatisticsService>();
        }

        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            return services
                .AddScoped<ITrackRepository, TrackRepository>()
                .AddScoped<IAlbumRepository, AlbumRepository>()
                .AddScoped<IRoleRepository, RoleRepository>()
                .AddScoped<IPersonRepository, PersonRepository>()
                .AddScoped<IMusicianRepository, MusicianRepository>()
                .AddScoped<IAddedTracksRepository, AddedTracksRepository>()
                .AddScoped<IStatisticsRepository, StatisticsRepository>();
                
        }
    }
}
