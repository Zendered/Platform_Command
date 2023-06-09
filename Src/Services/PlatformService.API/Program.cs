using PlatformService.API;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.AddCustomDependencyInjection();
builder.AddCustomAutoMapper();
builder.AddCustomDataBase();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.AddCustomRequestPipeLine();

app.Run();