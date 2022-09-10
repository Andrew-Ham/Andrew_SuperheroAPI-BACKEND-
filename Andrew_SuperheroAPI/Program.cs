global using Andrew_SuperheroAPI.Data;
global using Microsoft.EntityFrameworkCore;
using Andrew_SuperheroAPI;
using Andrew_SuperheroAPI.Contracts;
using Andrew_SuperheroAPI.Repositories;
using Andrew_SuperheroAPI.Service;
using Andrew_SuperheroAPI.Services;
using AspNetCoreRateLimit;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args); // This provides default configuration for the app in highest ot lowest priorty

// Add services to the container.

//builder.Services.AddControllers();
builder.Services.AddControllers(config =>
{
    config.CacheProfiles.Add("120SecondsDuration", new CacheProfile
    {
        Duration = 120
    });
});
 
builder.Services.AddMemoryCache(); // Memory cache keeps track who requested what and how many times it was requested - Throttling
builder.Services.ConfigureRateLimiting(); //This is the method we configured in ServiceExtension for throttling (rateLimitRUles)
builder.Services.AddHttpContextAccessor(); //This gives access to actual controller when needed

builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});
//builder.Services.AddResponseCaching(); //Use Caching
//builder.Services.ConfigureHttpCacheHeaders();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddHttpClient("pokeapi", configureClient: client =>
{
    client.BaseAddress = new Uri("https://pokeapi.co/api/v2/");
});
    
builder.Services.AddHttpClient("superHeroapi", configureClient: client =>
{
    client.BaseAddress = new Uri("https://localhost:7064/");
});



//Inject Dependencies -services
builder.Services.AddScoped<ICharacterAssemble, CharacterAssemble>();
builder.Services.AddScoped<IPokemon, Pokemon>();
builder.Services.AddScoped<ISuperHero, SuperHero>();
builder.Services.AddScoped<ICharacterRepository, CharacterRepository>();

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

//app.UseResponseCaching(); //Use Caching
//app.UseHttpCacheHeaders(); //Caching
app.UseIpRateLimiting(); // 


app.UseAuthorization();

app.MapControllers();

app.Run();
