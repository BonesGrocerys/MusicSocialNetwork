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
                .AddScoped<IAuthService, AuthService>();
        }

        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            return services
                .AddScoped<ITrackRepository, TrackRepository>()
                .AddScoped<IAlbumRepository, AlbumRepository>()
                .AddScoped<IRoleRepository, RoleRepository>()
                .AddScoped<IPersonRepository, PersonRepository>()
                .AddScoped<IAddedTracksRepository, AddedTracksRepository>();
        }
    }
}
