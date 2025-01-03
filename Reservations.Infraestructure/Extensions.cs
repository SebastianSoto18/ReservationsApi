using System.Globalization;
using System.Security.Claims;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Reservations.Application.Services;
using Reservations.Domain;
using Reservations.Infraestructure.Data;
using Reservations.Infraestructure.Data.Repositories;
using Reservations.Infraestructure.Services;

namespace Reservations.Infraestructure;

public static class Extensions
{
    public static void AddApplicationDbContext(this IServiceCollection services, string connectionString)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
        {
            options.UseSqlServer(connectionString);
        });
    }
    
    public static void AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IReservationRepository, ReservationRepository>();
        services.AddScoped<IPlaceRepository, PlaceRepository>();
    }
    
    public static void AddServices(this IServiceCollection services)
    {
        services.AddScoped<IEncryptService, EncryptService>();
        services.AddScoped<ITokenService, TokenService>();
    }
    
    public static DateTime ParseDate(this string date, string? format = null)
    {
        return DateTime.ParseExact(date, format ?? "dd/MM/yyyy", CultureInfo.InvariantCulture);
    }

    public static TimeSpan ParseHour(this string hour)
    {
        return TimeSpan.Parse(hour, CultureInfo.InvariantCulture);
    }
}