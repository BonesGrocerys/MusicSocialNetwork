using Microsoft.EntityFrameworkCore;
using MusicSocialNetwork;
using MusicSocialNetwork.Database;
using MusicSocialNetwork.Repository.Implimentations;
using MusicSocialNetwork.Repository.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseNpgsql(
    builder.Configuration.GetConnectionString("MusicSocialNetworkDb")));

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddServices();
builder.Services.AddRepositories();

builder.Services.AddCors(options => options.AddDefaultPolicy(build =>
build.AllowAnyOrigin()));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}



app.UseCors(builder => {
    builder.AllowAnyOrigin();
    builder.AllowAnyHeader();
    builder.AllowAnyMethod();
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
