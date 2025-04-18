﻿using ArtSystem.Application.Contracts.Persistance;
using ArtSystem.Application.Contracts.Persistance.Identity;
using ArtSystem.Identity.Services;
using ArtSystem.Persistance.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ArtSystem.Persistance
{
    public static class InterfaceServiceRegistration
    {
        public static IServiceCollection AddInterfaceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ArtDbContext>(options =>
             options.UseSqlServer(configuration.GetConnectionString("ArtWebAPIConnString"))
             );
            services.AddScoped<IArtworksRepository, ArtworksRepository>();
            services.AddScoped<IAuthService, AuthService>();

            return services;
        } 
       
    }
}
