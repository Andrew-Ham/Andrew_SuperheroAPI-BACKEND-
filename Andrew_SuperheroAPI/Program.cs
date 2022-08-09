using Andrew_SuperheroAPI.Contracts;
using Andrew_SuperheroAPI.Service;
using Andrew_SuperheroAPI.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
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

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
