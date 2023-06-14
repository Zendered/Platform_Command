using Microsoft.EntityFrameworkCore;
using PlatformService.API.Data;
using PlatformService.API.Data.Repository;

namespace PlatformService.API
{
    public static class ProgramExtensions
    {
        public static void AddCustomDependencyInjection(this WebApplicationBuilder builder)
        {
            builder.Services.AddScoped<IPlatformRepo, PlatformRepo>();
        }
        public static void AddCustomAutoMapper(this WebApplicationBuilder builder)
        {
            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        }

        public static void AddCustomDataBase(this WebApplicationBuilder builder)
        {
            builder.Services.AddDbContext<AppDBContext>(opt =>
                opt.UseInMemoryDatabase("InMem"));
        }

        public static void AddCustomRequestPipeLine(this WebApplication app)
        {
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            PrepDB.PrepPopulation(app);

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();
        }
    }
}
