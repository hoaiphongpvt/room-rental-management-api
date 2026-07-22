using Microsoft.Extensions.DependencyInjection;
using RoomRentalManagement.Application.Rooms;
using RoomRentalManagement.Application.Users;

namespace RoomRentalManagement.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<IRoomService, RoomService>();
            services.AddScoped<IUserService, UserService>();

            return services;
        }
    }
}
