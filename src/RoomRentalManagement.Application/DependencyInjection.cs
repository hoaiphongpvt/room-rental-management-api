using Microsoft.Extensions.DependencyInjection;
using RoomRentalManagement.Application.Auth;
using RoomRentalManagement.Application.Contracts;
using RoomRentalManagement.Application.InvoiceDetails;
using RoomRentalManagement.Application.Invoices;
using RoomRentalManagement.Application.Pictures;
using RoomRentalManagement.Application.Rooms;
using RoomRentalManagement.Application.ServiceDetails;
using RoomRentalManagement.Application.Services;
using RoomRentalManagement.Application.Users;

namespace RoomRentalManagement.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<IRoomService, RoomService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IContractService, ContractService>();
            services.AddScoped<IInvoiceService, InvoiceService>();
            services.AddScoped<IInvoiceDetailService, InvoiceDetailService>();
            services.AddScoped<IPictureService, PictureService>();
            services.AddScoped<IServiceService, ServiceService>();
            services.AddScoped<IServiceDetailService, ServiceDetailService>();

            return services;
        }
    }
}
