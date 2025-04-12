using ArtSystem.Identity.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ArtSystem.Identity
{
    public static  class IdentityServiceRegistration
    {
        public static IServiceCollection AddIdentityServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ArtIdentityDbContext>(options => {
                options.UseSqlServer(configuration.GetConnectionString("ArtWebAPIConnString"));
                //options.ConfigureWarnings(warnings => { warnings.Log(Microsoft.EntityFrameworkCore.Diagnostics.RelationalEventId.PendingModelChangesWarning); });
            });
            services.AddIdentity<ApplicationUser, IdentityRole>().AddEntityFrameworkStores<ArtIdentityDbContext>().AddDefaultTokenProviders();
            return services;  
        }
    }
}
