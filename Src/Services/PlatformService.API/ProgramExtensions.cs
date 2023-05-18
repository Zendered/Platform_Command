using Microsoft.EntityFrameworkCore;

namespace PlatformService.API
{
    public static class ProgramExtensions
    {
        public static void AddCustomDataBase(this WebApplicationBuilder builder)
        {
            builder.Services.AddDbContext<DbContext>(opt =>
                opt.UseInMemoryDatabase("InMem"));
        }
        public static void AddCustomRequestPipeLine(this WebApplication app)
        {
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
        }
    }
}
