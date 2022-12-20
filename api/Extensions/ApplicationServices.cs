using api.Helper;
using core;
using core.Entities.ServiceEntities;
using core.Interfaces;
using infrastructure.Database.Generic;
using infrastructure.Database.StoreContext;
using infrastructure.Database.UnitOfWork;
using infrastructure.Services;
using Microsoft.EntityFrameworkCore;

namespace api.Extensions
{
    public static class ApplicationServices
    {
        public static IServiceCollection AddDataBaseServices(this IServiceCollection services, IConfiguration _config)
        {
            services.AddAutoMapper(typeof(AutoMapperProfiles).Assembly);


            services.Configure<DatabaseSettings>( _config.GetSection("DatabaseSettings"));
            services.AddDbContext<DataContext>(options => {
                 string mySqlConnectionStr = _config.GetConnectionString("DefaultConnection");
                options.UseMySql(mySqlConnectionStr, ServerVersion.AutoDetect(mySqlConnectionStr), 
            optionsBuilder => optionsBuilder.MigrationsAssembly("api"));
            });

            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            
            return services;
        }

        public static IServiceCollection AddCloudServices(this IServiceCollection services, IConfiguration _config)
        {

            services.Configure<CloudinarySettings>(_config.GetSection("CloudinarySettings"));
            services.AddScoped<IPhotoService, PhotoService>();
            return services;
        }
    }
}