using MongoDB.Driver;
using RickAndMortyApi.Repository;
using RickAndMortyApi.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddHttpClient<CharacterService>(client =>
    client.BaseAddress = new Uri("https://rickandmortyapi.com/api/"));

var connectionString = builder.Configuration.GetConnectionString("MongoDb");
var databaseName = builder.Configuration.GetValue<string>("RickAndMorty");

builder.Services.AddSingleton<IMongoClient>(sp =>
{
    return new MongoClient(connectionString);
});

builder.Services.AddScoped<IMongoDatabase>(sp => {
    var client = sp.GetRequiredService<IMongoClient>();
    return client.GetDatabase("RickAndMorty");
});

builder.Services.AddScoped<CharacterRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
